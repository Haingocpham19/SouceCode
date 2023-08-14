using iChiba.WH.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.WH.Service.Interface
{
    public interface IShippingRouteWarehouseService
    {
        IEnumerable<ShippingRouteWarehouse> GetByShippingRouteCode(string route);
    }
}
