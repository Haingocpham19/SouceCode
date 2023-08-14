using Core.Specification.Abstract;
using iChiba.OM.Model;
using System.Collections.Generic;

namespace iChiba.OM.Specification.Implement
{
    public class OrderServiceGetBy : SpecificationBase<OrderService>
    {
        public OrderServiceGetBy(string keyword)
          : base(m => string.IsNullOrEmpty(keyword) || m.Name.Contains(keyword) || m.Description.Contains(keyword))
        {

        }

        public OrderServiceGetBy(IList<int> ids)
       : base(m => ids.Contains(m.Id))
        {

        }
    }
}
