using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Service.Interface;
using iChiba.WH.Specification.Implement;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.WH.Service.Implement
{
    public class ShippingRouteService : IShippingRouteService
    {
        private readonly IShippingRouteRepository _shippingRouteRepository;

        public ShippingRouteService(IShippingRouteRepository shippingRouteRepository)
        {
            _shippingRouteRepository = shippingRouteRepository;
        }

        public ShippingRoute GetById(int Id)
        {
            return _shippingRouteRepository.FindById(Id);
        }

        public IList<ShippingRoute> GetAll()
        {
            return _shippingRouteRepository.Find().ToList();
        }

        public IList<ShippingRoute> GetByListCodes(List<string> listCodes)
        {
            return _shippingRouteRepository.Find(new ShippingRouteGetBy(listCodes)).ToList();
        }
    }
}
