using Core.Specification.Abstract;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Service.Interface;
using iChiba.WH.Specification.Implement;
using System.Collections.Generic;

namespace iChiba.WH.Service.Implement
{
    public class PackageDetailService : IPackageDetailService
    {
        private readonly IPackageDetailRepository _packageDetailRepository;

        public PackageDetailService(IPackageDetailRepository packageDetailRepository)
        {
            _packageDetailRepository = packageDetailRepository;
        }

        public IEnumerable<PackageDetail> GetByDeliveryBillCode(List<string> billCodes)
        {
            var spec = new Specification<PackageDetail>(m => billCodes.Contains(m.DeliveryBillCode));
            return _packageDetailRepository.Find(spec);
        }

        public IEnumerable<PackageDetail> GetByDeliveryBillCode(string billCode)
        {
            var spec = new Specification<PackageDetail>(m => m.DeliveryBillCode == billCode);
            return _packageDetailRepository.Find(spec);
        }
		
		public IEnumerable<PackageDetail> GetByOrderCodes(List<string> orderCodes)
        {
            var specification = new Specification<PackageDetail>(m => true)
                .AndIf(orderCodes != null, () => new PackageDetailByOrderCodes(orderCodes));

            return _packageDetailRepository.Find(specification);
        }
    }
}
