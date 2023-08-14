using Core.Repository.Abstract;
using iChiba.WH.DbContext;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;

namespace iChiba.WH.Repository.Implement
{
    public class PackageDetailRepository : BaseRepository<WarehouseDBContext, PackageDetail>, IPackageDetailRepository
    {
        public PackageDetailRepository(WarehouseDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
