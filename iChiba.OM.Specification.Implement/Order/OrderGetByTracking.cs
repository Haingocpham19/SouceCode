using System.Collections.Generic;
using Core.Specification.Abstract;

namespace iChiba.OM.Specification.Implement
{
    public class OrderGetByTracking : SpecificationBase<Model.Order>
    {
        public OrderGetByTracking(string tracking)
        : base(m => !string.IsNullOrEmpty(m.Tracking) && m.Tracking.Equals(tracking))
        {

        }

        public OrderGetByTracking(IList<string> trackings)
            : base(m => !string.IsNullOrEmpty(m.Tracking) && trackings.Contains(m.Tracking))
        {

        }
    }
}
