using System.Collections.Generic;
using MediatR;
using MeSoftware.OrderManagement.ViewModels;

namespace MeSoftware.OrderManagement.MediatR
{
    public class ProductQueries
    {
        public class ListQuery : IRequest<IEnumerable<ProductViewModel>>
        {
            public ListQuery(string namefilter)
            {
                NameFilter = namefilter;
            }

            public string NameFilter { get; }
        }
    }
}
