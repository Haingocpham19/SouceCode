using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class DepositsRepository : BaseRepository<CustomerDBContext, Deposits>, IDepositsRepository
    {
        public DepositsRepository(CustomerDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
