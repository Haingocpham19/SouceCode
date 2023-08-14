using Core.Repository.Abstract;
using iChiba.WH.DbContext;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;

namespace iChiba.WH.Repository.Implement
{
    public class PackageDetailQuoteRepository : BaseRepository<WarehouseDBContext, PackageDetailQuote>, IPackageDetailQuoteRepository
    {
        public PackageDetailQuoteRepository(WarehouseDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
