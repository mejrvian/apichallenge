using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MeSoftware.Core;
using MeSoftware.Exceptions.Api;
using MeSoftware.OrderManagement.Contexts;
using MeSoftware.OrderManagement.Services;
using MeSoftware.OrderManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeSoftware.OrderManagement.MediatR
{
    public class ProductReportHandler
        : IRequestHandler<ProductReportQueries.ReportLinesQuery, IEnumerable<ProductReportViewModel>>
    {
        private readonly MeContext context;
        private readonly IIdentityService identityService;

        public Guid UserId { get; }

        public ProductReportHandler(MeContext context, IIdentityService identityService)
        {
            this.identityService = identityService;
            UserId = Guid.Parse(this.identityService.UserName);
            this.context = context;
            this.context.CurrentUserId = UserId;
        }

        public async Task<IEnumerable<ProductReportViewModel>> Handle(ProductReportQueries.ReportLinesQuery request, CancellationToken cancellationToken)
        {
            var role = await identityService.GetUserRoleAsync(3, new int[] { 1 });

            if (role.IsNull())
            {
                throw new MeAuthorizeException("Forbidden.");
            }

            var orderlines = await Task.Run(() => context.PurchaseOrders
                .Where(n => n.Date >= request.BeginDate && n.Date <= request.EndDate)
                .Include(n => n.PurchaseOrderDetails)
                .ThenInclude(n => n.Product)
                .SelectMany(n => n.PurchaseOrderDetails)
                .ToArray());

            var productIds = orderlines.Select(n => n.ProductId)
                .Distinct();

            return await Task.Run(() => productIds.Select(n => new ProductReportViewModel
            {
                ProductName = orderlines.First(d => d.ProductId == n)
                    .Product.ProductName,
                UnitPrice = orderlines.First(d => d.ProductId == n)
                    .Product.UnitPrice,
                TotalQuantity = orderlines.Where(d => d.ProductId == n)
                    .Sum(d => d.Quantity),
                TotalPrice = orderlines.Where(d => d.ProductId == n)
                    .Sum(d => d.TotalPrice)
            })
            .OrderByDescending(n => n.TotalQuantity));
        }
    }
}
