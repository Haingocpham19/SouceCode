using Core.Repository.Abstract;
using iChiba.WH.DbContext;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;

namespace iChiba.WH.Repository.Implement
{
    public class ShipmentStatusHistoryRepository : BaseRepository<WarehouseDBContext, ShipmentStatusHistory>, IShipmentStatusHistoryRepository
    {
        public ShipmentStatusHistoryRepository(WarehouseDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
