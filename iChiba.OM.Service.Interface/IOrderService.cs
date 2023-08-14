using System;
using System.Collections.Generic;
using Core.Common;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetByAccountId(string accountId, Sorts sorts = null, Paging paging = null);
        IEnumerable<Order> GetListOrder(
            string accountId,
            string orderType,
            string orderCode,
            string tracking,
            List<string> states,
            List<int> status,
            List<string> quoteCodes,
            Sorts sorts = null,
            Paging paging = null);
        Order GetById(int orderId);
        Order GetByCode(string orderCode);
        Order GetByTrackingCode(string trackingCode);
        IEnumerable<Order> GetByCode(List<string> orderCodes);
        IEnumerable<Order> GetByIds(List<int> Ids);
        IEnumerable<Order> GetByTracking(List<string> trackings);
        void Add(Order order);
        void Update(Order item);
        void DetachedRangeOder(List<Order> orders);
        void DetachedOder(Order order);
        void Delete(Order item);
        IList<Order> GetByCodes(params string[] orderCodes);
        IEnumerable<Order> GetByStatus(List<int> statuses);
        Order GetsByTracking(string tracking);
        HashSet<string> ExistsListTracking(IEnumerable<string> lstTracking);
        Order GetByGuidId(Guid id);
    }
}