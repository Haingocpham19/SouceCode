using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class EmployeeRepository : BaseRepository<CustomerDBContext, Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CustomerDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
