using System;

namespace MeSoftware.OrderManagement.ViewModels
{
    public class LogInResponseViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }
        public string Token { get; set; }
    }
}
