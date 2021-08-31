using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MeSoftware.Core;
using MeSoftware.Exceptions.Api;
using MeSoftware.OrderManagement.Contexts;
using MeSoftware.OrderManagement.Models;
using MeSoftware.OrderManagement.Services;
using MeSoftware.OrderManagement.ViewModels;

namespace MeSoftware.OrderManagement.MediatR
{
    public class POHandler 
        : IRequestHandler<POQueries.AddCommand, PurchaseOrderViewModel>
    {
        private readonly MeContext context;
        private readonly IIdentityService identityService;

        public Guid UserId { get; }

        public POHandler(MeContext context, IIdentityService identityService)
        {
            this.identityService = identityService;
            UserId = Guid.Parse(this.identityService.UserName);
            this.context = context;
            this.context.CurrentUserId = UserId;
        }

        public async Task<PurchaseOrderViewModel> Handle(POQueries.AddCommand request, CancellationToken cancellationToken)
        {
            var role = await identityService.GetUserRoleAsync(3, new int[] { 1 });

            if (role.IsNull())
            {
                throw new MeAuthorizeException("Forbidden.");
            }

            var order = await context.PurchaseOrders.AddAsync(new PurchaseOrder
            {
                PurchaseOrderNo = request.ViewModel.PurchaseOrderNo,
                Date = request.ViewModel.Date,
                Total = request.ViewModel.Total,
                CustomerId = request.ViewModel.CustomerId
            }, cancellationToken);

            order.Entity.PurchaseOrderDetails = new HashSet<PurchaseOrderItems>(request.ViewModel.Details.Select(n => new PurchaseOrderItems
            {
                Quantity = n.Quantity,
                TotalPrice = n.TotalPrice,
                ProductId = n.ProductId,
                PurchaseOrderId = order.Entity.Id
            }));

            await context.SaveChangesAsync(cancellationToken);

            request.ViewModel.Id = order.Entity.Id;

            return request.ViewModel;
        }
    }
}
