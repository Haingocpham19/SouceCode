using Core.Repository.Abstract;
using iChiba.WH.DbContext;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;

namespace iChiba.WH.Repository.Implement
{
    public class PackageRepository : BaseRepository<WarehouseDBContext, Package>, IPackageRepository
    {
        public PackageRepository(WarehouseDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
