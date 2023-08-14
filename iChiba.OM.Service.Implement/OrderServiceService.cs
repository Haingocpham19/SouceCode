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
    public class OrderServiceService : IOrderServiceService
    {
        private readonly IOrderServiceRepository _orderServiceRepository;

        public OrderServiceService(IOrderServiceRepository orderServiceRepository)
        {
            _orderServiceRepository = orderServiceRepository;
        }

        public Model.OrderService GetByCode(string orderCode)
        {
            var specification = new Specification<Model.OrderService>(m => true)
                .AndIf(!string.IsNullOrEmpty(orderCode), () => new OrderServiceGetByCode(orderCode));
            return _orderServiceRepository.Find(specification).FirstOrDefault();
        }

        public void Update(Model.OrderService item)
        {
            _orderServiceRepository.Update(item);
        }

        public IList<Model.OrderService> GetByWarehouseId(int warehouseId)
        {
            var specification = new Specification<Model.OrderService>(m => true)
                .And(() => new OrderServiceGetByWarehouseId(warehouseId));
            return _orderServiceRepository.Find(specification).ToList();
        }

        public IList<Model.OrderService> GetById(int id)
        {
            var specification = new Specification<Model.OrderService>(m => true)
                .And(() => new OrderServiceGetById(id));
            return _orderServiceRepository.Find(specification).ToList();
        }

        public IList<Model.OrderService> GetByIds(IList<int> ids)
        {
            return _orderServiceRepository.Find(new OrderServiceGetBy(ids)).ToList();
        }

        public Model.OrderService GetServiceById(int id)
        {
            var specification = new Specification<Model.OrderService>(m => true)
                .And(() => new OrderServiceGetById(id));
            return _orderServiceRepository.Find(specification).FirstOrDefault();
        }

        public IEnumerable<Model.OrderService> GetByCode(List<string> codes)
        {
            var spec = new Specification<Model.OrderService>(m => codes != null && codes.Count > 0 && codes.Contains(m.Code));
            return _orderServiceRepository.Find(spec);
        }
    }
}
