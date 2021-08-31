using MeSoftware.OrderManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeSoftware.OrderManagement.ModelConfiguration
{
    public class PurchaseOrderConfigurator : ConfiguratorBase<PurchaseOrder>
    {
        public PurchaseOrderConfigurator(ModelBuilder modelBuilder) 
            : base(modelBuilder, "PurchaseOrders")
        {
        }

        public override void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            base.Configure(builder);

            builder.HasOne(n => n.Customer)
                .WithMany(n => n.PurchaseOrders)
                .HasForeignKey(n => n.CustomerId);
        }
    }
}
