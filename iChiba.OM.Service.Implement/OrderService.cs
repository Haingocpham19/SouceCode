using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;

namespace iChiba.OM.Service.Implement
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetByAccountId(string accountId, Sorts sorts = null, Paging paging = null)
        {
            var specification = new Specification<Order>(m => !string.IsNullOrEmpty(m.AccountId) && !string.IsNullOrEmpty(accountId) && m.AccountId == accountId);
            return _orderRepository.Find(specification, sorts, paging);
        }

        public Order GetById(int id)
        {
            return _orderRepository.FindById(id);
        }

        public Order GetByCode(string orderCode)
        {
            var specification = new Specification<Order>(m => true)
                .AndIf(!string.IsNullOrEmpty(orderCode), () => new OrderGetByCode(orderCode));

            return _orderRepository.Find(specification).FirstOrDefault();
        }

        public Order GetByTrackingCode(string trackingCode)
        {
            var specification = new Specification<Order>(m => true)
                .AndIf(!string.IsNullOrEmpty(trackingCode), () => new OrderGetByTrackingCode(trackingCode));

            return _orderRepository.Find(specification).FirstOrDefault();
        }

        public IEnumerable<Order> GetByCode(List<string> orderCodes)
        {
            var specification = new Specification<Order>(m => true)
                .AndIf(orderCodes.Any, () => new OrderGetByCode(orderCodes));

            return _orderRepository.Find(specification);
        }

        public IEnumerable<Order> GetByIds(List<int> Ids)
        {
            var specification = new Specification<Order>(m => true)
                .AndIf(Ids.Any, () => new OrderGetById(Ids));

            return _orderRepository.Find(specification);
        }

        public IEnumerable<Order> GetByTracking(List<string> trackings)
        {
            var specification = new Specification<Order>(m => true)
                .AndIf(trackings.Any, () => new OrderGetByTracking(trackings));

            return _orderRepository.Find(specification);
        }

        public void Add(Order order)
        {
            _orderRepository.Add(order);
        }

        public void Update(Order item)
        {
            _orderRepository.Update(item);
        }

        public void Delete(Order item)
        {
            _orderRepository.Delete(item);
        }

        public IEnumerable<Order> GetByStatus(List<int> statuses)
        {
            var spec = new Specification<Order>(m => m.Status != null && statuses.Count > 0 && statuses.Contains((int)m.Status));
            return _orderRepository.Find(spec);
        }

        public void DetachedRangeOder(List<Order> orders)
        {
            _orderRepository.DetachedRange(orders);
        }

        public void DetachedOder(Order order)
        {
            _orderRepository.Detached(order);
        }

        public IEnumerable<Order> GetListOrder(string accountId, string orderType, string orderCode, string tracking, List<string> states, List<int> status, List<string> quoteCodes, Sorts sorts = null, Paging paging = null)
        {
            var specification = new Specification<Order>(m => !string.IsNullOrEmpty(accountId) && m.AccountId == accountId)
                .AndIf(!string.IsNullOrEmpty(orderCode), () => new OrderGetByCode(orderCode))
                .AndIf(!string.IsNullOrEmpty(tracking), () => new OrderGetByTrackingCode(tracking))
                .AndIf(!string.IsNullOrEmpty(orderType), () => new OrderGetByOrderType(orderType))
                .AndIf(quoteCodes != null && quoteCodes.Any(), () => new OrderGetByQuoteCode(quoteCodes))
                .AndIf(states != null && states.Any(), () => new OrderGetByState(states))
                .AndIf(status != null && status.Any(), () => new OrderGetByStatus(status));

            return _orderRepository.Find(specification, sorts, paging);
        }
        
        public IList<Order> GetByCodes(params string[] orderCodes)
        {
            return _orderRepository.Find(new OrderSearchGetByOrderCodes(orderCodes)).ToList();
        }
        public Order GetsByTracking(string tracking)
        {
            return _orderRepository.FindSingleBySpec(new GetByTracking(tracking));
        }
        public HashSet<string> ExistsListTracking(IEnumerable<string> lstTracking)
        {
            return _orderRepository.ExistsListTracking(lstTracking);
        }

        public Order GetByGuidId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
