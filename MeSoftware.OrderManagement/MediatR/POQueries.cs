using MediatR;
using MeSoftware.OrderManagement.ViewModels;

namespace MeSoftware.OrderManagement.MediatR
{
    public class POQueries
    {
        public class AddCommand : IRequest<PurchaseOrderViewModel>
        {
            public AddCommand(PurchaseOrderViewModel viewModel)
            {
                ViewModel = viewModel;
            }

            public PurchaseOrderViewModel ViewModel { get; }
        }
    }
}
