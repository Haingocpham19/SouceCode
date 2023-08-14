using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.WH.Service.Implement
{
    public class LocationsNodeCacheService : ILocationsNodeCacheService
    {
        private readonly ILocationNodeCache _locationsNodeCache;

        public LocationsNodeCacheService(ILocationNodeCache locationsNodeCache)
        {
            _locationsNodeCache = locationsNodeCache;
        }

        public Task<IList<LocationNode>> GetAll()
        {
            return _locationsNodeCache.GetAll();
        }

        public Task<LocationNode> GetById(int id)
        {
            return _locationsNodeCache.GetById(id);
        }

        public Task<IList<LocationNode>> GetByIds(params int[] ids)
        {
            return _locationsNodeCache.GetByIds(ids);
        }

        public Task<bool> HashSet(LocationNode model)
        {
            return _locationsNodeCache.HashSet(model);
        }

        public Task HashDelete(int id)
        {
            return _locationsNodeCache.HashDelete(id);
        }
    }
}
