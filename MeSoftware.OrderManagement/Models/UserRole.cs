using System;
using System.Collections.Generic;
using MeSoftware.EntityComponentModel;
using Microsoft.AspNetCore.Identity;

namespace MeSoftware.OrderManagement.Models
{
    public class UserRole : IdentityRole<Guid>, IAuditableEntity
    {
        public UserRole()
        {
            Users = new HashSet<IdentityUserRole<Guid>>();
            Claims = new HashSet<IdentityRoleClaim<Guid>>();
        }

        public UserRole(string roleName) : base(roleName)
        {
            Users = new HashSet<IdentityUserRole<Guid>>();
            Claims = new HashSet<IdentityRoleClaim<Guid>>();
        }

        public UserRole(string roleName, string description)
            : this(roleName)
        {
            Description = description;
        }

        public string Description { get; set; }
        public int RoleLevel { get; internal set; }
        public string Modules { get; set; }
        public int SutId { get; internal set; }

        public virtual ICollection<IdentityUserRole<Guid>> Users { get; set; }

        public virtual ICollection<IdentityRoleClaim<Guid>> Claims { get; set; }

        public Guid? UserId { get; set; }
        public Guid? ModUserId { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
        public DateTimeOffset? LastModDate { get; set; }
        public Guid? ExternalId { get; set; }
        public string SourceDescription { get; set; }
        public DateTimeOffset? ImportDate { get; set; }
    }
}
