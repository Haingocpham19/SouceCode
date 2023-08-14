using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.WH.Service.Implement
{
    public class LocationsParentNodeCacheService : ILocationsParentNodeCacheService
    {
        private readonly ILocationParentNodeCache _locationsParentNodeCache;

        public LocationsParentNodeCacheService(ILocationParentNodeCache locationsParentNodeCache)
        {
            _locationsParentNodeCache = locationsParentNodeCache;
        }

        public Task<LocationParentNode> GetById(int id)
        {
            return _locationsParentNodeCache.GetById(id);
        }


        public Task<IList<LocationParentNode>> GetByIds(params int[] ids)
        {
            return _locationsParentNodeCache.GetByIds(ids);
        }

        public Task<bool> HashSet(LocationParentNode model)
        {
            return _locationsParentNodeCache.HashSet(model);
        }

        public Task HashDelete(int id)
        {
            return _locationsParentNodeCache.HashDelete(id);
        }
    }
}
