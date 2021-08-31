using System.Collections.Generic;
using MeSoftware.EntityComponentModel;

namespace MeSoftware.OrderManagement.Models
{
    public class Product : AuditableActivableSystemIdEntity
    {
        public Product()
        {
            PurchaseOrderItems = new HashSet<PurchaseOrderItems>();
        }

        public string ProductName { get; set; }
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual ICollection<PurchaseOrderItems> PurchaseOrderItems { get; private set; }
    }
}
