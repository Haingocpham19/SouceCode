using iChiba.OM.Model;
using System;
using System.Collections.Generic;

namespace iChiba.OM.Service.Interface
{
    public interface IOrderPurchaseLogService
    {
        OrderPurchaseLog Add(OrderPurchaseLog model);
        OrderPurchaseLog GetById(int id);
        void Update(OrderPurchaseLog model);
        void Delete(OrderPurchaseLog model);
        IList<OrderPurchaseLog> Gets();
        OrderPurchaseLog GetLastByOrderId(int orderId, int status, string actionType);
        bool IsExistingAfter(int id, int orderId, DateTime actionDate, string actionType);
        OrderPurchaseLog GetLastAfter(int id, int orderId, DateTime actionDate, string actionType);
        IList<OrderPurchaseLog> GetAfter(int id, int orderId, DateTime actionDate,
            params string[] actionTypes);
        OrderPurchaseLog GetLastAfter(int orderId, string actionType);
        IList<OrderPurchaseLog> GetAfter(int orderId, string actionType);
        bool IsExisting(int orderId, string actionType);
        IList<OrderPurchaseLog> GetByOrderId(int orderId);
        OrderPurchaseLog GetByActionType(int orderId, string actionType);
    }
}
