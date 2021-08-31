using MeSoftware.OrderManagement.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MeSoftware.OrderManagement.Extensions
{
    public static class ModelBuiderExtensions
    {
        public static ModelBuilder MeConfigure(this ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfiguration(new CustomerConfigurator(modelBuilder))
            .ApplyConfiguration(new ModuleConfigurator(modelBuilder))
            .ApplyConfiguration(new ProductConfigurator(modelBuilder))
            .ApplyConfiguration(new PurchaseOrderConfigurator(modelBuilder))
            .ApplyConfiguration(new PurchaseOrderItemsConfigurator(modelBuilder))
            .ApplyConfiguration(new UserConfigurator(modelBuilder))
            .ApplyConfiguration(new UserRoleConfigurator(modelBuilder));
    }
}
