using System.Collections.Generic;
using Core.Specification.Abstract;
using iChiba.WH.Model;

namespace iChiba.WH.Specification.Implement
{
    public class PackageDetailQuoteGetById : SpecificationBase<PackageDetailQuote>
    {
        public PackageDetailQuoteGetById(int id) : base(m => id.Equals(m.Id))
        {

        }

        public PackageDetailQuoteGetById(List<int> ids) : base(m => ids.Contains(m.Id))
        {

        }
    }
}
