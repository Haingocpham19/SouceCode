using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class WithdrawalRepository : BaseRepository<CustomerDBContext, Withdrawal>, IWithdrawalRepository
    {
        public WithdrawalRepository(CustomerDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
