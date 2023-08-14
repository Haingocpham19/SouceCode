using System.Collections.Generic;
using Core.Specification.Abstract;

namespace iChiba.OM.Specification.Implement
{

    public class OrderPackageGetByCode : SpecificationBase<Model.OrderPackage>
    {
        public OrderPackageGetByCode(IList<string> trackingCodes)
            : base(m => !string.IsNullOrEmpty(m.Code) && trackingCodes.Contains(m.Code))
        {

        }
    }
}
