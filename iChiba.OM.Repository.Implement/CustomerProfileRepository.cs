using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class CustomerProfileRepository : BaseRepository<CustomerDBContext, CustomerProfile>, ICustomerProfileRepository
    {
        public CustomerProfileRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }
    }
}
