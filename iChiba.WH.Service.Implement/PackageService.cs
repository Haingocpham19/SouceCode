using Core.Specification.Abstract;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Service.Interface;
using System.Collections.Generic;

namespace iChiba.WH.Service.Implement
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public IEnumerable<Package> GetById(List<int> ids)
        {
            var spec = new Specification<Package>(m => ids != null && ids.Count > 0 && ids.Contains(m.Id));
            return _packageRepository.Find(spec);
        }

        public IEnumerable<Package> GetByParentId(List<int> parentIds)
        {
            var spec = new Specification<Package>(m => parentIds != null && parentIds.Count > 0 && m.ParentId != null && parentIds.Contains((int)m.ParentId));
            return _packageRepository.Find(spec);
        }

        public IEnumerable<Package> GetByTrackingCode(List<string> trackingCodes)
        {
            var spec = new Specification<Package>(m => trackingCodes != null && trackingCodes.Count > 0 && trackingCodes.Contains(m.TrackingCode));
            return _packageRepository.Find(spec);
        }
    }
}
