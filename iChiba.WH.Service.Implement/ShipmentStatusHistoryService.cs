using Core.Specification.Abstract;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Service.Interface;
using System.Collections.Generic;

namespace iChiba.WH.Service.Implement
{
    public class ShipmentStatusHistoryService : IShipmentStatusHistoryService
    {
        private readonly IShipmentStatusHistoryRepository _shipmentStatusHistoryRepository;

        public ShipmentStatusHistoryService(IShipmentStatusHistoryRepository shipmentStatusHistoryRepository)
        {
            _shipmentStatusHistoryRepository = shipmentStatusHistoryRepository;
        }

        public IEnumerable<ShipmentStatusHistory> GetByPackageDetaiQuoteId(List<int> packageDetailQuoteIds)
        {
            var spec = new Specification<ShipmentStatusHistory>(m => packageDetailQuoteIds.Contains(m.ShipmentId.Value));
            return _shipmentStatusHistoryRepository.Find(spec);
        }
    }
}
