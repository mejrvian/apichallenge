using System;
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
    public class CustomersAddHandler
       : IRequestHandler<CustomersQueries.AddCommand, CustomerViewModel>
    {
        private readonly MeContext context;
        private readonly IIdentityService identityService;

        public Guid UserId { get; }

        public CustomersAddHandler(MeContext context, IIdentityService identityService)
        {
            this.identityService = identityService;
            UserId = Guid.Parse(this.identityService.UserName);
            this.context = context;
            this.context.CurrentUserId = UserId;
        }

        public async Task<CustomerViewModel> Handle(CustomersQueries.AddCommand request, CancellationToken cancellationToken)
        {
            var role = await identityService.GetUserRoleAsync(3, new int[] { 1 });

            if (role.IsNull())
            {
                throw new MeAuthorizeException("Forbidden.");
            }

            var customer = await context.Customers.AddAsync(new Customer
            {
                CustomerName = request.ViewModel.CustomerName,
                CustomerDetails = request.ViewModel.CustomerDetails
            }, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            request.ViewModel.Id = customer.Entity.Id;

            return request.ViewModel;
        }
    }
}
