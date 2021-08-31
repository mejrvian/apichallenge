using MeSoftware.OrderManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace MeSoftware.OrderManagement.ModelConfiguration
{
    public class ModuleConfigurator : ConfiguratorBase<Module>
    {
        public ModuleConfigurator(ModelBuilder modelBuilder) 
            : base(modelBuilder, "Modules")
        {
        }
    }
}
