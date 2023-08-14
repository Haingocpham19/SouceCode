using System.Collections.Generic;
using Core.Specification.Abstract;
using iChiba.WH.Model;

namespace iChiba.WH.Specification.Implement
{
    public class PackageDetailByOrderCodes : SpecificationBase<PackageDetail>
    {

        public PackageDetailByOrderCodes(List<string> orderCodes) : base(m => orderCodes.Contains(m.OrderCode))
        {

        }
    }
}
