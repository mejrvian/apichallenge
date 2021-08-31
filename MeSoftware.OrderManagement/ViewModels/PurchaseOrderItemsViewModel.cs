using System;

namespace MeSoftware.OrderManagement.ViewModels
{
    public class PurchaseOrderItemsViewModel
    {
        public decimal Quantity { get; set; }
        public decimal UnitPrice {  get; set; }
        public decimal TotalPrice { get; set; }
        public Guid ProductId { get; set; }
    }
}
