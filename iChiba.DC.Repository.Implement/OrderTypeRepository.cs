using Core.Repository.Abstract;
using iChiba.DC.DbContext;
using iChiba.DC.Model;
using iChiba.DC.Repository.Interface;

namespace iChiba.DC.Repository.Implement
{
    public class OrderTypeRepository : BaseRepository<DATA_COMMONContext, OrderType>, IOrderTypeRepository
    {
        public OrderTypeRepository(DATA_COMMONContext dbContext) : base(dbContext)
        {
        }
    }
}
