using System.Collections.Generic;
using Core.Common;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface IOrderServiceMappingService
    {
        void Add(OrderServiceMapping model);
        void AddRange(IList<OrderServiceMapping> models);
        void Delete(OrderServiceMapping model);
        void DeleteByOrderId(int orderId);
        OrderServiceMapping GetById(int orderId);
        IList<OrderServiceMapping> Gets(int orderId);
        IList<OrderServiceMapping> GetByOrderId(List<int> orderIds);
        void Update(OrderServiceMapping model);
        OrderServiceMapping GetBySingerOrderId(int id);
        OrderServiceMapping Gets(int orderId, int orderServiceId);
    }
}