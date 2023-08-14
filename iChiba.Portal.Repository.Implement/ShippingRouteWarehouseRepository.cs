using Core.Repository.Abstract;
using iChiba.WH.DbContext;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;

namespace iChiba.WH.Repository.Implement
{
    public class ShippingRouteWarehouseRepository : BaseRepository<WarehouseDBContext, ShippingRouteWarehouse>, IShippingRouteWarehouseRepository
    {
        public ShippingRouteWarehouseRepository(WarehouseDBContext dbContext) : base(dbContext)
        {
        }
    }
}
