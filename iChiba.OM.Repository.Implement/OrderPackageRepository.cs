using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using System.Collections.Generic;

namespace iChiba.OM.Repository.Implement
{
    public class OrderPackageRepository : BaseRepository<CustomerDBContext, OrderPackage>, IOrderPackageRepository
    {
        public OrderPackageRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }
        public void DetachedRange(IList<OrderPackage> orderPackages)
        {
            foreach (var orderPackage in orderPackages)
            {
                dbContext.Entry(orderPackage).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
    }
}
