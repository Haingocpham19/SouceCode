using Core.Specification.Abstract;
using iChiba.OM.Model;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Specification.Implement
{
    public class OrderPackageProductGetBy : SpecificationBase<OrderPackageProduct>
    {
        public OrderPackageProductGetBy(int orderPackageId, string keyword)
          : base(m => m.PackageId == orderPackageId
          && (string.IsNullOrEmpty(keyword) || m.Name.Contains(keyword) || m.NameCustom.Contains(keyword)))
        {

        }
        public OrderPackageProductGetBy(List<int> orderPackageIds)
          : base(m => orderPackageIds.Contains(m.PackageId))
        {

        }


        public OrderPackageProductGetBy(IList<int> ids)
        : base(m => ids.Contains(m.Id))
        {

        }
    }
}
