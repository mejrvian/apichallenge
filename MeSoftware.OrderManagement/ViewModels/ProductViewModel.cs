using System;

namespace MeSoftware.OrderManagement.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id {  get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
