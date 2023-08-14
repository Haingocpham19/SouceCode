using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class CustomerWalletRepository : BaseRepository<CustomerDBContext, CustomerWallet>, ICustomerWalletRepository
    {
        public CustomerWalletRepository(CustomerDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
