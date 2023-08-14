using System.Collections.Generic;
using Core.Common;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface IOrderPackageService
    {
        OrderPackage Add(OrderPackage model);
        void Delete(OrderPackage model);
        OrderPackage GetById(int id);
        IList<OrderPackage> Gets(int? orderId);
        IList<OrderPackage> Gets(int? orderId, string searchKeyword, Sorts sorts, Paging paging);
        IList<OrderPackage> Gets(List<int> orderIds);
        void Update(OrderPackage model);
        OrderPackage GetDebitNote(int orderId);
        IList<OrderPackage> GetDebitNotes(int orderId);
        void DetachedRange(IList<OrderPackage> orderPackages);
    }
}