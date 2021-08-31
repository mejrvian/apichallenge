using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeSoftware.OrderManagement.Contexts;
using MeSoftware.OrderManagement.DTO;
using MeSoftware.OrderManagement.Models;
using MeSoftware.OrderManagement.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace MeSoftware.OrderManagement.Extensions
{
    public static class MeStartupExtensions
    {
        public static IServiceCollection AddMeBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMeDbContext(configuration.GetConnectionString("DefaultConnection"));

            services.AddMeIdentity();

            services.AddMeAuthentication(
                services.ConfigureSecretKeySettings(configuration.GetSection("JwtAppSettings")));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();

            services.AddScoped<IIdentityService, IdentityService>();

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MeSoftware.OrderManagement", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseMeConfiguration(this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }

        public static IServiceCollection AddMeDbContext(this IServiceCollection services, string cnnStr)
            => services.AddDbContext<MeContext>(options => options
                .UseSqlServer(cnnStr)
                .UseLazyLoadingProxies());

        public static IServiceCollection AddMeIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, UserRole>()
               .AddEntityFrameworkStores<MeContext>();
            return services;
        }

        public static byte[] ConfigureSecretKeySettings(this IServiceCollection services, IConfigurationSection appSettingsSection)
        {
            services.Configure<JwtAppSettings>(
                x => x.Secret = appSettingsSection.Get<JwtAppSettings>().Secret);

            var jwtSettings = appSettingsSection.Get<JwtAppSettings>();
            return Encoding.ASCII.GetBytes(jwtSettings.Secret);
        }

        public static IServiceCollection AddMeAuthentication(this IServiceCollection services, byte[] key)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = Guid.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });

            return services;
        }
    }
}
