using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class OrderMessageRepository : BaseRepository<CustomerDBContext, OrderMessage>, IOrderMessageRepository
    {
        public OrderMessageRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }
    }
}
