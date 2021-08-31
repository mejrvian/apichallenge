using System;
using System.Collections.Generic;

namespace MeSoftware.OrderManagement.ViewModels
{
    public class PurchaseOrderViewModel
    {
        public Guid Id { get; set; }
        public string PurchaseOrderNo { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public Guid CustomerId { get; set; }
        public IEnumerable<PurchaseOrderItemsViewModel> Details { get; set; }
    }
}
