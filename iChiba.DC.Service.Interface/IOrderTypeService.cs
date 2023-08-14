using System.Collections.Generic;
using iChiba.DC.Model;

namespace iChiba.DC.Service.Interface
{
    public interface IOrderTypeService
    {
        IList<OrderType> Gets();
        OrderType Add(OrderType model);
        void Update(OrderType model);
        void Delete(OrderType model);
    }
}