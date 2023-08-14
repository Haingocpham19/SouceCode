using Core.Specification.Abstract;
using iChiba.OM.Model;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Specification.Implement
{
    public class OrderMessageGetByOrderId : SpecificationBase<OrderMessage>
    {
        public OrderMessageGetByOrderId(int orderId)
           : base(m => m.OrderId == orderId)
        {
        }

        public OrderMessageGetByOrderId(List<int> orderId)
          : base(m => orderId.Contains(m.OrderId))
        {
        }
    }
}
