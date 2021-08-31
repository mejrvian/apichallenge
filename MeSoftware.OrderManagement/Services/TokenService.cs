using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MeSoftware.OrderManagement.DTO;
using MeSoftware.OrderManagement.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MeSoftware.OrderManagement.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUserService userService;
        private readonly JwtAppSettings appSettings;

        public TokenService(IUserService userService, IOptions<JwtAppSettings> appSettings)
        {
            this.userService = userService;
            this.appSettings = appSettings.Value;
        }

        public LogInResponseViewModel Authenticate(UserLoginViewModel userDto)
        {
            var user = userService.Authenticate(userDto.UserName, userDto.Password);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password)
            return new LogInResponseViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Active = user.ActiveFlag.GetValueOrDefault(),
                Token = tokenString
            };
        }
    }
}
