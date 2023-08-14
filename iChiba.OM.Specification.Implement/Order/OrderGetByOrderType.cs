using System.Collections.Generic;
using System.Linq;
using Core.Specification.Abstract;
using iChiba.Portal.Common;

namespace iChiba.OM.Specification.Implement
{
    public class OrderGetByOrderType : SpecificationBase<Model.Order>
    {
        public OrderGetByOrderType(string orderType)
        : base(m => !string.IsNullOrEmpty(orderType)
            && (
                (orderType == OrderCsType.TRANSPORT && m.OrderType == OrderCsType.TRANSPORT)
                || (orderType == OrderCsType.AUCTION && m.OrderType == OrderCsType.AUCTION)
                || (orderType != OrderCsType.AUCTION && m.OrderType != OrderCsType.AUCTION && orderType != OrderCsType.TRANSPORT && m.OrderType != OrderCsType.TRANSPORT)
            )
        )
        {

        }
    }

    public class OrderGetByState : SpecificationBase<Model.Order>
    {
        public OrderGetByState(List<string> states)
        : base(m => states.Any() && states.Contains(m.State))
        {

        }
    }

    public class OrderGetByStatus : SpecificationBase<Model.Order>
    {
        public OrderGetByStatus(List<int> status)
        : base(m => status.Any() && m.Status != null && status.Contains(m.Status.Value))
        {

        }
    }

    public class OrderGetByQuoteCode : SpecificationBase<Model.Order>
    {
        public OrderGetByQuoteCode(string quoteCode)
        : base(m => !string.IsNullOrEmpty(quoteCode) && m.QuoteCode == quoteCode)
        {

        }

        public OrderGetByQuoteCode(List<string> quoteCodes)
        : base(m => quoteCodes != null && quoteCodes.Count > 0 && quoteCodes.Contains(m.QuoteCode))
        {

        }
    }
}
