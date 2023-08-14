using Core.Specification.Abstract;
using iChiba.OM.Model;

namespace iChiba.OM.Specification.Implement
{
    public class OrderServiceMappingGetBy : SpecificationBase<OrderServiceMapping>
    {
        public OrderServiceMappingGetBy(int orderId)
          : base(m => m.OrderId == orderId)
        {

        }

        public OrderServiceMappingGetBy(int orderId,int orderServiceId)
         : base(m => m.OrderId == orderId && m.OrderServiceId == orderServiceId)
        {

        }
    }
}
