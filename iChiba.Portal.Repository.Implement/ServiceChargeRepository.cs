using Core.Repository.Abstract;
using iChiba.WH.DbContext;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;

namespace iChiba.WH.Repository.Implement
{
    public class ServiceChargeRepository : BaseRepository<WarehouseDBContext, ServiceCharge>, IServiceChargeRepository
    {
        public ServiceChargeRepository(WarehouseDBContext dbContext) : base(dbContext)
        {
        }
    }
}
