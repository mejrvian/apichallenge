using MeSoftware.OrderManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeSoftware.OrderManagement.ModelConfiguration
{
    public class UserRoleConfigurator : ConfiguratorBase<UserRole>
    {
        public UserRoleConfigurator(ModelBuilder modelBuilder)
            : base(modelBuilder, "UserRoles")
        { }

        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);

            builder.HasMany(r => r.Claims)
                .WithOne()
                .HasForeignKey(c => c.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(r => r.Users)
                .WithOne()
                .HasForeignKey(r => r.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);   
        }
    }
}