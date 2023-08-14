using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Repository.Implement
{
    public class OrderPackageProductRepository : BaseRepository<CustomerDBContext, OrderPackageProduct>, IOrderPackageProductRepository
    {
        public OrderPackageProductRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllByPackageId(IList<OrderPackageProduct> models)
        {
            models.ToList()
                .ForEach(m => Delete(m));
        }

        public void DetachedRange(IList<OrderPackageProduct> orderPackageProduct)
        {
            foreach (var orderPackageProduc in orderPackageProduct)
            {
                dbContext.Entry(orderPackageProduc).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
    }
}
