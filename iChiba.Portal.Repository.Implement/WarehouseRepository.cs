using Core.Repository.Abstract;
using iChiba.WH.DbContext;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.WH.Repository.Implement
{
    public class WarehouseRepository : BaseRepository<WarehouseDBContext, Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(WarehouseDBContext dbContext) : base(dbContext)
        {
        }

        public void UpdateOrders(IList<Warehouse> models)
        {
            models.ToList()
              .ForEach(x => SetModified(x, m => m.Order));
        }
    }
}
