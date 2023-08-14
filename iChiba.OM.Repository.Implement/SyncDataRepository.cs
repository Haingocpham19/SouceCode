using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class SyncDataRepository : BaseRepository<CustomerDBContext, SyncData>, ISyncDataRepository
    {
        public SyncDataRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }
    }
}
