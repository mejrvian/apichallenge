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
    public class ProductsHandler
        : IRequestHandler<ProductQueries.ListQuery, IEnumerable<ProductViewModel>>
    {
        private readonly MeContext context;
        private readonly IIdentityService identityService;

        public Guid UserId { get; }

        public ProductsHandler(MeContext context, IIdentityService identityService)
        {
            this.identityService = identityService;
            UserId = Guid.Parse(this.identityService.UserName);
            this.context = context;
            this.context.CurrentUserId = UserId;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(ProductQueries.ListQuery request, CancellationToken cancellationToken)
        {
            var role = await identityService.GetUserRoleAsync(3, new int[] { 1 });

            if (role.IsNull())
            {
                throw new MeAuthorizeException("Forbidden.");
            }

            Func<Product, bool> predicate = request.NameFilter.HasValue() ?
                n => n.ProductName.Contains(request.NameFilter) :
                n => true;

            return await Task.Run(() => context.Products.Where(predicate)
                .Select(n => new ProductViewModel
                {
                    ProductName = n.ProductName,
                    SKU = n.SKU,
                    UnitPrice = n.UnitPrice
                }));
        }
    }
}
