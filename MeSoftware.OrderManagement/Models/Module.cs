using MeSoftware.EntityComponentModel;

namespace MeSoftware.OrderManagement.Models
{
    public class Module : AuditableActivableSystemIdEntity
    {
        public int ModuleNo { get; set; }
        public string ModuleName { get; set; }
    }
}
