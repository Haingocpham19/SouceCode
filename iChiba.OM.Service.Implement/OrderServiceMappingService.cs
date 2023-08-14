using System.Collections.Generic;
using System.Linq;
using Core.Common;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;

namespace iChiba.OM.Service.Implement
{
    public class OrderServiceMappingService : IOrderServiceMappingService
    {
        private readonly IOrderServiceMappingRepository orderServiceMappingRepository;

        public OrderServiceMappingService(IOrderServiceMappingRepository orderServiceMappingRepository)
        {
            this.orderServiceMappingRepository = orderServiceMappingRepository;
        }

        public void Add(OrderServiceMapping model)
        {
            orderServiceMappingRepository.Add(model);
        }

        public void AddRange(IList<OrderServiceMapping> models)
        {
            orderServiceMappingRepository.AddRange(models);
        }

        public void Delete(OrderServiceMapping model)
        {
            orderServiceMappingRepository.Delete(model);
        }

        public void DeleteByOrderId(int orderId)
        {
            var listServiceMappings = orderServiceMappingRepository.Find(new OrderServiceMappingGetBy(orderId)).ToList();
            orderServiceMappingRepository.DeleteAllByOrderId(listServiceMappings);
        }

        public OrderServiceMapping GetById(int id)
        {
            return orderServiceMappingRepository.FindById(id);
        }

        public OrderServiceMapping Gets(int orderId,int orderServiceId)
        {
            return orderServiceMappingRepository.FindSingleBySpec(new OrderServiceMappingGetBy(orderId, orderServiceId));
        }

        public OrderServiceMapping GetBySingerOrderId(int id)
        {
            return orderServiceMappingRepository.FindById(id);
        }

        public IList<OrderServiceMapping> Gets(int orderId)
        {
            return orderServiceMappingRepository.Find(new OrderServiceMappingGetBy(orderId)).ToList();
        }

        public IList<OrderServiceMapping> GetByOrderId(List<int> orderIds)
        {
            return orderServiceMappingRepository.Find(new OrderServiceMappingGetByOrderId(orderIds)).ToList();
        }

        public void Update(OrderServiceMapping model)
        {
            orderServiceMappingRepository.Update(model);
        }
    }
}
