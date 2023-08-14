using System.Collections.Generic;
using System.Linq;
using Core.Common;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Service.Interface;

namespace iChiba.WH.Service.Implement
{
    public class ServiceChargeService : IServiceChargeService
    {
        private readonly IServiceChargeRepository _serviceChargeRepository;

        public ServiceChargeService(IServiceChargeRepository serviceChargeRepository)
        {
            _serviceChargeRepository = serviceChargeRepository;
        }

        public IList<ServiceCharge> GetAll()
        {
            return _serviceChargeRepository.Find().ToList();
        }

    }
}
