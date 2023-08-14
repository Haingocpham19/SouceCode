using System.Collections.Generic;
using Core.Specification.Abstract;

namespace iChiba.OM.Specification.Implement
{
    public class OrderGetById : SpecificationBase<Model.Order>
    {
        public OrderGetById(int id) : base(m => id.Equals(m.Id))
        {

        }

        public OrderGetById(List<int> ids) : base(m => ids.Contains(m.Id))
        {

        }
    }
}
