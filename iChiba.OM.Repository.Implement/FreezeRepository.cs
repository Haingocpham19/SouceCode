using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class FreezeRepository : BaseRepository<CustomerDBContext, Freeze>, IFreezeRepository
    {
        public FreezeRepository(CustomerDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
