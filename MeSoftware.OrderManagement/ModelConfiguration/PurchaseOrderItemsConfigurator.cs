using MeSoftware.OrderManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeSoftware.OrderManagement.ModelConfiguration
{
    public class PurchaseOrderItemsConfigurator : ConfiguratorBase<PurchaseOrderItems>
    {
        public PurchaseOrderItemsConfigurator(ModelBuilder modelBuilder) 
            : base(modelBuilder, "PurchaseOrderItems")
        {
        }

        public override void Configure(EntityTypeBuilder<PurchaseOrderItems> builder)
        {
            base.Configure(builder);

            builder.HasOne(n => n.PurchaseOrder)
                .WithMany(n => n.PurchaseOrderDetails)
                .HasForeignKey(n => n.PurchaseOrderId);

            builder.HasOne(n => n.Product)
                .WithMany(n => n.PurchaseOrderItems)
                .HasForeignKey(n => n.ProductId);
        }
    }
}
