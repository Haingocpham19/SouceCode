using System.Collections.Generic;
using System.Linq;
using iChiba.DC.Model;
using iChiba.DC.Repository.Interface;
using iChiba.DC.Service.Interface;

namespace iChiba.DC.Service.Implement
{
    public class OrderTypeService : IOrderTypeService
    {
        private readonly IOrderTypeRepository _orderTypeRepository;
        public OrderTypeService(
            IOrderTypeRepository orderTypeRepository)
        {
            _orderTypeRepository = orderTypeRepository;
        }

        public OrderType Add(OrderType model)
        {
            return _orderTypeRepository.Add(model);
        }

        public void Update(OrderType model)
        {
            _orderTypeRepository.Update(model);
        }

        public void Delete(OrderType model)
        {
            _orderTypeRepository.Delete(model);
        }

        IList<OrderType> IOrderTypeService.Gets()
        {
            return _orderTypeRepository.Find().ToList();
        }
    }
}
