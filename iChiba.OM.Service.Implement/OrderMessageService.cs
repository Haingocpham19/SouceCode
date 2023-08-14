using System.Collections.Generic;
using System.Linq;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;

namespace iChiba.OM.Service.Implement
{
    public class OrderMessageService : IOrderMessageService
    {
        private readonly IOrderMessageRepository orderMessageRepository;


        public OrderMessageService(IOrderMessageRepository orderMessageRepository)
        {
            this.orderMessageRepository = orderMessageRepository;
        }

        public IList<OrderMessage> Gets(int orderId)
        {
            return orderMessageRepository.Find(new OrderMessageGetByOrderId(orderId)).ToList();
        }

        public IList<OrderMessage> Gets(List<int> orderId)
        {
            return orderMessageRepository.Find(new OrderMessageGetByOrderId(orderId)).ToList();
        }
    }
}
