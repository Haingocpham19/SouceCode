using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class ProductTypeGroupRepository : BaseRepository<CustomerDBContext, ProductTypeGroup>, IProductTypeGroupRepository
    {
        public ProductTypeGroupRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }
    }
}
