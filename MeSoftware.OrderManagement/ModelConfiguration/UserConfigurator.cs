using MeSoftware.OrderManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeSoftware.OrderManagement.ModelConfiguration
{
    public class UserConfigurator : ConfiguratorBase<User>
    {
        public UserConfigurator(ModelBuilder modelBuilder) 
            : base(modelBuilder, "Users")
        {
        }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.HasIndex(n => n.UserName)
                .IsUnique();
            builder.HasMany(n => n.Claims)
                .WithOne()
                .HasForeignKey(n => n.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Roles)
                .WithOne()
                .HasForeignKey(r => r.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
