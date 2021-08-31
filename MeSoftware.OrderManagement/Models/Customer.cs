using System.Collections.Generic;
using MeSoftware.EntityComponentModel;

namespace MeSoftware.OrderManagement.Models
{
    public class Customer : AuditableActivableSystemIdEntity
    {
        public Customer()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public string CustomerName { get; set; }
        public string CustomerDetails { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; private set; }
    }
}
