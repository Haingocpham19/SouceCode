using Core.Specification.Abstract;
using iChiba.WH.Model;
using System.Collections.Generic;

namespace iChiba.WH.Specification.Implement
{
   public class ShippingRouteGetBy : SpecificationBase<ShippingRoute>
    {
        public ShippingRouteGetBy(List<string> routes)
        : base(m => routes == null || routes.Contains(m.Code))
        {

        }
    }
}
