using System.Collections.Generic;
using Core.Repository.Interface;
using iChiba.OM.Model;

namespace iChiba.OM.Repository.Interface
{
    public interface IOrderDetailRepository : IRepository<Orderdetail>
    {
        IList<Orderdetail> GetReSyncPurchaseReport();
        IList<Orderdetail> GetOrderNotInPurchaseReport();
        Customer GetCustomerByAccountId(string accountId);
        void DetachedRange(IList<Orderdetail> orders);
        void Detached(Orderdetail order);
    }
}