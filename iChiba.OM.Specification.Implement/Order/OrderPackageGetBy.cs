using Core.Specification.Abstract;
using iChiba.OM.Model;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace iChiba.OM.Specification.Implement
{
    public class OrderPackageGetBy : SpecificationBase<OrderPackage>
    {
        public OrderPackageGetBy(int? orderId, string keyword)
          : base(m => (orderId == null || m.OrderId == orderId)
          && (string.IsNullOrEmpty(keyword) || m.Code.Contains(keyword)))
        {

        }

        public OrderPackageGetBy(List<int> orderIds)
          : base(m => m.OrderId != null && orderIds.Contains(m.OrderId.Value))
        {

        }

        public OrderPackageGetBy(int orderId)
         : base(m => m.OrderId == orderId)
        {

        }
    }
}
