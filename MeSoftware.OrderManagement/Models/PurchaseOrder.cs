using System;
using System.Collections.Generic;
using MeSoftware.EntityComponentModel;

namespace MeSoftware.OrderManagement.Models
{
    public class PurchaseOrder : AuditableIdEntity
    {
        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderItems>();
        }

        public string PurchaseOrderNo {  get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public virtual Guid CustomerId {  get; set; }

        public virtual Customer Customer {  get; set; }

        public virtual ICollection<PurchaseOrderItems> PurchaseOrderDetails {  get; set;}
    }
}
