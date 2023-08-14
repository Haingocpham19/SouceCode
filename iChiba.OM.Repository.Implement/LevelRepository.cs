using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class LevelRepository : BaseRepository<CustomerDBContext, Level>, ILevelRepository
    {
        public LevelRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }
    }
}
