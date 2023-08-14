using Core.Repository.Interface;
using iChiba.OM.Model;
using System.Collections.Generic;

namespace iChiba.OM.Repository.Interface
{
    public interface IOrderPackageProductRepository : IRepository<OrderPackageProduct>
    {
        void DeleteAllByPackageId(IList<OrderPackageProduct> models);
        void DetachedRange(IList<OrderPackageProduct> orderPackageProduct);
    }
}
