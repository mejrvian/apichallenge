using MeSoftware.OrderManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace MeSoftware.OrderManagement.ModelConfiguration
{
    public class ProductConfigurator : ConfiguratorBase<Product>
    {
        public ProductConfigurator(ModelBuilder modelBuilder) 
            : base(modelBuilder, "Products")
        {
        }
    }
}
