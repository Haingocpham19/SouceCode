using iChiba.WH.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.WH.Service.Interface
{
    public interface IShippingRouteService
    {
        ShippingRoute GetById(int Id);
        IList<ShippingRoute> GetByListCodes(List<string> listCodes);
        IList<ShippingRoute> GetAll();
    }
}
