using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class CustomerAddressRepository : BaseRepository<CustomerDBContext, CustomerAddress>, ICustomerAddressRepository
    {
        public CustomerAddressRepository(CustomerDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
