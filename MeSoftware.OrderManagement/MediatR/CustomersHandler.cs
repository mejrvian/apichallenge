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
    public class CustomersHandler
        : IRequestHandler<CustomersQueries.ListQuery, IEnumerable<CustomerViewModel>>
    {
        private readonly MeContext context;
        private readonly IIdentityService identityService;

        public Guid UserId { get; }

        public CustomersHandler(MeContext context, IIdentityService identityService)
        {
            this.identityService = identityService;
            UserId = Guid.Parse(this.identityService.UserName);
            this.context = context;
            this.context.CurrentUserId = UserId;
        }

        public async Task<IEnumerable<CustomerViewModel>> Handle(CustomersQueries.ListQuery request, CancellationToken cancellationToken)
        {
            var role = await identityService.GetUserRoleAsync(3, new int[] { 1 });

            if (role.IsNull())
            {
                throw new MeAuthorizeException("Forbidden.");
            }

            Func<Customer, bool> predicate = request.NameFilter.HasValue() ?
                n => n.CustomerName.Contains(request.NameFilter) :
                n => true;

            return await Task.Run(() => context.Customers.Where(predicate)
                .Select(n => new CustomerViewModel
                {
                    CustomerName = n.CustomerName,
                    CustomerDetails = n.CustomerDetails
                }));
        }
    }
}
