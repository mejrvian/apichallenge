using System;
using System.Collections.Generic;
using MediatR;
using MeSoftware.OrderManagement.ViewModels;

namespace MeSoftware.OrderManagement.MediatR
{
    public class ProductReportQueries
    {
        public class ReportLinesQuery : IRequest<IEnumerable<ProductReportViewModel>>
        {
            public ReportLinesQuery(DateTime begDate, DateTime endDate)
            {
                BeginDate = begDate;
                EndDate = endDate;
            }

            public DateTime BeginDate { get; }
            public DateTime EndDate { get; }
        }
    }
}
