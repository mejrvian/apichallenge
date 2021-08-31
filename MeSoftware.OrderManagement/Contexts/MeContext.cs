using System;
using System.Threading;
using System.Threading.Tasks;
using MeSoftware.EntityComponentModel.DbContextOnSaveServices;
using MeSoftware.OrderManagement.Extensions;
using MeSoftware.OrderManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeSoftware.OrderManagement.Contexts
{
    public class MeContext : IdentityDbContext<User, UserRole, Guid>
    {
        private IDbContextOnSaveServiceManager onSaveServiceManager;

        public MeContext()
        {
            InitServices();
        }

        public MeContext(DbContextOptions<MeContext> options)
            : base(options)
        {
            InitServices();
        }

        public Guid CurrentUserId { get; set; }

        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.MeConfigure();
        }

        public override int SaveChanges()
        {
            onSaveServiceManager.Execute(this, CurrentUserId);
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            onSaveServiceManager.Execute(this, CurrentUserId);
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            onSaveServiceManager.Execute(this, CurrentUserId);
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            onSaveServiceManager.Execute(this, CurrentUserId);
            return base.SaveChangesAsync(cancellationToken);
        }

        public void InitServices()
        {
            onSaveServiceManager = new DbContextOnSaveServiceManager()
                .Add(new ActiveFlagUpdateService())
                .Add(new AuditFieldsUpdateService())
                .Add(new SoftDeletableUpdateService())
                .Add(new SystemUpdateService())
                ;
        }
    }
}
