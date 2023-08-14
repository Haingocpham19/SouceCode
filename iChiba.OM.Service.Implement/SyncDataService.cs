using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;

namespace iChiba.OM.Service.Implement
{
    public class SyncDataService : ISyncDataService
    {
        private readonly ISyncDataRepository _syncDataRepository;

        public SyncDataService(ISyncDataRepository syncDataRepository)
        {
            _syncDataRepository = syncDataRepository;
        }

        public IList<SyncData> Gets(Sorts sorts, Paging paging)
        {
            var specification = new Specification<SyncData>(m => true)
                .And(new SyncDataGets());
            return _syncDataRepository.Find(specification, sorts, paging).ToList();
        }
        public IList<SyncData> GetByDataType(int dataType, bool ignore)
        {
            var specification = new Specification<SyncData>(m => true)
                .And(new SyncDataGets())
                 .AndIf(dataType > 0, () => new SyncDataGetByDataType(dataType));
            return _syncDataRepository.Find(specification).ToList();
        }

        public void Delete(SyncData item)
        {
            _syncDataRepository.Delete(item);
        }
    }
}
