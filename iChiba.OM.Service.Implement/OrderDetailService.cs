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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public List<Orderdetail> GetByOrderId(int orderId)
        {
            return _orderDetailRepository.Find(new OrderDetailGetByOrderId(orderId)).ToList();
        }

        public List<Orderdetail> GetByOrderIds(List<int> orderIds)
        {
            return _orderDetailRepository.Find(new OrderDetailGetByOrderId(orderIds)).ToList();
        }
        public void Add(Orderdetail orderdetail)
        {
            _orderDetailRepository.Add(orderdetail);
        }
    }
}
