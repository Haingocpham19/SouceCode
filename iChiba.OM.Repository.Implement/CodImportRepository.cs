using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
   public class CodImportRepository : BaseRepository<CustomerDBContext, CodImport>, ICodImportRepository
    {
        public CodImportRepository(CustomerDBContext dbContext)
          : base(dbContext)
        {

        }
    }
}
