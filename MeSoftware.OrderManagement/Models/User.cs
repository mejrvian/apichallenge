using System;
using System.Collections.Generic;
using MeSoftware.EntityComponentModel;
using Microsoft.AspNetCore.Identity;

namespace MeSoftware.OrderManagement.Models
{
    public class User : IdentityUser<Guid>, IActiveFlagEntity, IAuditableEntity
    {
        public User()
        {
            Roles = new HashSet<IdentityUserRole<Guid>>();
            Claims = new HashSet<IdentityUserClaim<Guid>>();
        }

        public bool IsLockedOut => LockoutEnabled && LockoutEnd >= DateTimeOffset.UtcNow;

        public virtual ICollection<IdentityUserRole<Guid>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; }

        public bool? ActiveFlag { get; set; }

        public DateTimeOffset? ActivationDate { get; internal set; }

        public DateTimeOffset? DeactivationDate { get; internal set; }

        public Guid? UserId { get; set; }
        public Guid? ModUserId { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
        public DateTimeOffset? LastModDate { get; set; }
        public Guid? ExternalId { get; set; }
        public string SourceDescription { get; set; }
        public DateTimeOffset? ImportDate { get; set; }
    }
}
