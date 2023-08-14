using System.Collections.Generic;
using Core.Common;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface IOrderPackageProductService
    {
        OrderPackageProduct Add(OrderPackageProduct model);
        void Delete(OrderPackageProduct model);
        void DeleteAllByPackageId(int orderPackageId);
        OrderPackageProduct GetById(int id);
        IList<OrderPackageProduct> GetByIds(IList<int> ids);
        void DetachedRange(IList<OrderPackageProduct> orderPackage);
        IList<OrderPackageProduct> Gets(int orderPackageId);
        IList<OrderPackageProduct> Gets(int orderPackageId, string searchKeyword, Sorts sorts, Paging paging);
        IList<OrderPackageProduct> Gets(List<int> orderPackageIds);
        void Update(OrderPackageProduct model);
    }
}