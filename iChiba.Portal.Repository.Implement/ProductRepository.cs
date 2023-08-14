using Core.Repository.Abstract;
using iChiba.WH.DbContext;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;

namespace iChiba.WH.Repository.Implement
{
    public class ProductRepository : BaseRepository<WarehouseDBContext, Product>, IProductRepository
    {
        public ProductRepository(WarehouseDBContext dbContext)
            : base(dbContext)
        {

        }
    }
}
