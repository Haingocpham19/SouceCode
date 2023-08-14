using Core.Specification.Abstract;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Service.Interface;
using System.Collections.Generic;

namespace iChiba.WH.Service.Implement
{
    public class ShippingRouteWarehouseService : IShippingRouteWarehouseService
    {
        private readonly IShippingRouteWarehouseRepository _shippingRouteWarehouseRepository;

        public ShippingRouteWarehouseService(IShippingRouteWarehouseRepository shippingRouteWarehouseRepository)
        {
            _shippingRouteWarehouseRepository = shippingRouteWarehouseRepository;
        }

        public IEnumerable<ShippingRouteWarehouse> GetByShippingRouteCode(string route)
        {
            var spec = new Specification<ShippingRouteWarehouse>(m => !string.IsNullOrEmpty(route) && m.ShippingRouteCode == route);
            return _shippingRouteWarehouseRepository.Find(spec);
        }
    }
}
