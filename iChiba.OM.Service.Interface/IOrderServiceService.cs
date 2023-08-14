using System.Collections.Generic;
using Core.Common;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface IOrderServiceService
    {
        OrderService GetByCode(string orderCode);
        IList<OrderService> GetById(int id);
        IList<OrderService> GetByIds(IList<int> ids);
        OrderService GetServiceById(int id);
        IList<OrderService> GetByWarehouseId(int warehouseId);
        IEnumerable<OrderService> GetByCode(List<string> codes);
    }
}