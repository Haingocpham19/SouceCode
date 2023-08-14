using iChiba.WH.Model;
using System.Collections.Generic;

namespace iChiba.WH.Service.Interface
{
    public interface IShipmentStatusHistoryService
    {
        IEnumerable<ShipmentStatusHistory> GetByPackageDetaiQuoteId(List<int> packageDetailIQuoteId);
    }
}
