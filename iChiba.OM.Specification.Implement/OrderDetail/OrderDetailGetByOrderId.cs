using System.Collections.Generic;
using Core.Specification.Abstract;

namespace iChiba.OM.Specification.Implement
{
    public class OrderDetailGetByOrderId : SpecificationBase<Model.Orderdetail>
    {
        public OrderDetailGetByOrderId(List<int> orderIds)
        : base(m => orderIds.Contains(m.OrderId))
        {

        }
        public OrderDetailGetByOrderId(int orderId)
       : base(m => m.OrderId.Equals(orderId))
        {

        }
    }
}
