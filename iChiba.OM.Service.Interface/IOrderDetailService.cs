using System.Collections.Generic;
using Core.Common;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface IOrderDetailService
    {
        List<Orderdetail> GetByOrderIds(List<int> orderId);
        List<Orderdetail> GetByOrderId(int orderId);
        void Add(Orderdetail orderdetail);
    }
}