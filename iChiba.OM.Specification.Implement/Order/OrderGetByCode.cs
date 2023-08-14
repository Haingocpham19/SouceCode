using System.Collections.Generic;
using Core.Specification.Abstract;

namespace iChiba.OM.Specification.Implement
{
    public class OrderGetByCode : SpecificationBase<Model.Order>
    {
        public OrderGetByCode(string code)
        : base(m => !string.IsNullOrEmpty(m.Code) && m.Code.Equals(code))
        {

        }

        public OrderGetByCode(IList<string> codes)
            : base(m => !string.IsNullOrEmpty(m.Code) && codes.Contains(m.Code))
        {

        }
    }

    public class OrderGetByTrackingCode : SpecificationBase<Model.Order>
    {
        public OrderGetByTrackingCode(string trackingCode)
            : base(m => !string.IsNullOrEmpty(m.Tracking) && m.Tracking.Contains(trackingCode))
        {

        }
    }
}
