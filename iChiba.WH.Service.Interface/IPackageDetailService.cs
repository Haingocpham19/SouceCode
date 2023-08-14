using iChiba.WH.Model;
using System.Collections.Generic;

namespace iChiba.WH.Service.Interface
{
    public interface IPackageDetailService
    {
        IEnumerable<PackageDetail> GetByDeliveryBillCode(string billCode);
        IEnumerable<PackageDetail> GetByDeliveryBillCode(List<string> billCodes);
        IEnumerable<PackageDetail> GetByOrderCodes(List<string> orderCodes);
    }
}
