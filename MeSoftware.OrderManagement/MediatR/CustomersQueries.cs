using System.Collections.Generic;
using MediatR;
using MeSoftware.OrderManagement.ViewModels;

namespace MeSoftware.OrderManagement.MediatR
{
    public class CustomersQueries
    {
        public class ListQuery : IRequest<IEnumerable<CustomerViewModel>>
        {
            public ListQuery(string namefilter)
            {
                NameFilter = namefilter;
            }

            public string NameFilter{ get; }
        }

        public class AddCommand : IRequest<CustomerViewModel>
        {
            public AddCommand(CustomerViewModel viewModel)
            {
                ViewModel = viewModel;
            }

            public CustomerViewModel ViewModel { get; }
        }
    }
}
