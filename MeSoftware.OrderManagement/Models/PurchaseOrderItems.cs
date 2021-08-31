using System;
using MeSoftware.EntityComponentModel;

namespace MeSoftware.OrderManagement.Models
{
    public class PurchaseOrderItems : AuditableIdEntity
    {
        public decimal Quantity { get; set; }
        public decimal TotalPrice {  get; set; }

        public Guid PurchaseOrderId { get; set; }

        public Guid ProductId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}