using System.Collections.Generic;
using Core.Repository.Interface;
using iChiba.OM.Model;

namespace iChiba.OM.Repository.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        IList<Order> GetReSyncPurchaseReport();
        IList<Order> GetOrderNotInPurchaseReport();
        Customer GetCustomerByAccountId(string accountId);
        void DetachedRange(IList<Order> orders);
        void Detached(Order order);
        void UpdateBulky();
        IList<string> CollectOrderType();
        HashSet<string> ExistsListTracking(IEnumerable<string> lstTracking);
    }
}