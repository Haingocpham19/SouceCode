using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Service.Implement
{
    public class OrderPurchaseLogService : IOrderPurchaseLogService
    {
        private readonly IOrderPurchaseLogRepository orderPurchaseLogRepository;

        public OrderPurchaseLogService(IOrderPurchaseLogRepository orderPurchaseLogRepository)
        {
            this.orderPurchaseLogRepository = orderPurchaseLogRepository;
        }
        public OrderPurchaseLog Add(OrderPurchaseLog model)
        {
            return orderPurchaseLogRepository.Add(model);
        }

        public void Delete(OrderPurchaseLog model)
        {
            orderPurchaseLogRepository.Delete(model);
        }

        public OrderPurchaseLog GetById(int id)
        {
            return orderPurchaseLogRepository.FindById(id);
        }

        public IList<OrderPurchaseLog> Gets()
        {
            return orderPurchaseLogRepository.Find().ToList();
        }

        public void Update(OrderPurchaseLog model)
        {
            orderPurchaseLogRepository.Update(model);
        }

        public OrderPurchaseLog GetLastByOrderId(int orderId, int status, string actionType)
        {
            var spec = new Specification<OrderPurchaseLog>(m => true)
                .And(new OrderPurchaseLogGetByOrderId(orderId))
                .And(new OrderPurchaseLogGetByActionType(actionType))
                .And(new OrderPurchaseLogGetByStatus(status));

            return orderPurchaseLogRepository.Find(spec).OrderByDescending(m => m.ActionDate).FirstOrDefault();
        }

        public bool IsExistingAfter(int id,
            int orderId,
            DateTime actionDate,
            string actionType)
        {
            var spec = new Specification<OrderPurchaseLog>(m => true)
                .And(new OrderPurchaseLogGetByOrderId(orderId))
                .And(new OrderPurchaseLogGetByGTId(id))
                .And(new OrderPurchaseLogGetByActionType(actionType))
                .And(new OrderPurchaseLogGetByGTEActionDate(actionDate));

            return orderPurchaseLogRepository.Find(spec).Any();
        }

        public bool IsExisting(int orderId,
            string actionType)
        {
            var spec = new Specification<OrderPurchaseLog>(m => true)
                .And(new OrderPurchaseLogGetByOrderId(orderId))
                .And(new OrderPurchaseLogGetByActionType(actionType));

            return orderPurchaseLogRepository.Find(spec).Any();
        }

        public OrderPurchaseLog GetByActionType(int orderId, string actionType)
        {
            var spec = new Specification<OrderPurchaseLog>(m => true)
               .And(new OrderPurchaseLogGetByOrderId(orderId))
               .And(new OrderPurchaseLogGetByActionType(actionType));

            return orderPurchaseLogRepository.Find(spec).FirstOrDefault();
        }

        public OrderPurchaseLog GetLastAfter(int id,
            int orderId,
            DateTime actionDate,
            string actionType)
        {
            var spec = new Specification<OrderPurchaseLog>(m => true)
                .And(new OrderPurchaseLogGetByOrderId(orderId))
                .And(new OrderPurchaseLogGetByGTId(id))
                .And(new OrderPurchaseLogGetByActionType(actionType))
                .And(new OrderPurchaseLogGetByGTEActionDate(actionDate));

            return orderPurchaseLogRepository.Find(spec)
                .OrderByDescending(item => item.ActionDate)
                .FirstOrDefault();
        }

        public OrderPurchaseLog GetLastAfter(int orderId,
            string actionType)
        {
            var spec = new Specification<OrderPurchaseLog>(m => true)
                .And(new OrderPurchaseLogGetByOrderId(orderId))
                .And(new OrderPurchaseLogGetByActionType(actionType));

            return orderPurchaseLogRepository.Find(spec)
                .OrderByDescending(item => item.ActionDate)
                .FirstOrDefault();
        }

        public IList<OrderPurchaseLog> GetAfter(int id,
            int orderId,
            DateTime actionDate,
            params string[] actionTypes)
        {
            var spec = new Specification<OrderPurchaseLog>(m => true)
                .And(new OrderPurchaseLogGetByOrderId(orderId))
                .And(new OrderPurchaseLogGetByGTId(id))
                .And(new OrderPurchaseLogGetByGTEActionDate(actionDate))
                .AndIf(actionTypes != null && actionTypes.Length > 0, () => new OrderPurchaseLogGetByActionTypes(actionTypes));

            return orderPurchaseLogRepository.Find(spec)
                .ToList();
        }

        public IList<OrderPurchaseLog> GetAfter(int orderId,            
            string actionType)
        {
            var spec = new Specification<OrderPurchaseLog>(m => true)
                .And(new OrderPurchaseLogGetByOrderId(orderId))
                .AndIf(!string.IsNullOrWhiteSpace(actionType), () => new OrderPurchaseLogGetByActionType(actionType));

            return orderPurchaseLogRepository.Find(spec)
                .ToList();
        }

        public IList<OrderPurchaseLog> GetByOrderId(int orderId)
        {
            return orderPurchaseLogRepository.Find(new OrderPurchaseLogGetByOrderId(orderId))
                .ToList();
        }
    }
}
