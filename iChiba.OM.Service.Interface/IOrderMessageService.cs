using iChiba.OM.Model;
using System.Collections.Generic;

namespace iChiba.OM.Service.Interface
{
    public interface IOrderMessageService
    {
        IList<OrderMessage> Gets(int orderId);
        IList<OrderMessage> Gets(List<int> orderId);
    }
}
