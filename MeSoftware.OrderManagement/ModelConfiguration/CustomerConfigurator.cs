using MeSoftware.OrderManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace MeSoftware.OrderManagement.ModelConfiguration
{
    public class CustomerConfigurator : ConfiguratorBase<Customer>
    {
        public CustomerConfigurator(ModelBuilder modelBuilder) 
            : base(modelBuilder, "Customers")
        {
        }
    }
}
