using System;

namespace MeSoftware.OrderManagement.ViewModels
{
    public class AuthorizedRoleViewModel
    {
        public Guid UserId { get; set; }
        public int RoleLevel { get; set; }
        public string[] Module { get; set; }
        public bool Authorized { get; set; }
    }
}
