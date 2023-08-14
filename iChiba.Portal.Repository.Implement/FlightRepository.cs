using Core.Repository.Abstract;
using iChiba.WH.DbContext;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;

namespace iChiba.WH.Repository.Implement
{
    public class FlightRepository : BaseRepository<WarehouseDBContext, Flight>, IFlightRepository
    {
        public FlightRepository(WarehouseDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
