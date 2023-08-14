using Core.Specification.Abstract;
using iChiba.OM.Model;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace iChiba.OM.Specification.Implement
{
    public class OrderServiceMappingGetByOrderId : SpecificationBase<OrderServiceMapping>
    {
        public OrderServiceMappingGetByOrderId(List<int> orderIds)
          : base(m => orderIds.Contains(m.OrderId))
        {

        }
    }
}
