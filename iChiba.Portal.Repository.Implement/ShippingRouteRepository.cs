using Core.Repository.Abstract;
using iChiba.WH.DbContext;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.WH.Repository.Implement
{
    public class ShippingRouteRepository : BaseRepository<WarehouseDBContext, ShippingRoute>, IShippingRouteRepository
    {
        public ShippingRouteRepository(WarehouseDBContext dbContext) : base(dbContext)
        {
        }
    }
}
