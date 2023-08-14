using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Implement
{
    public class LocationNodeService : ILocationNodeService
    {
        private readonly ILocationNodeCache locationsNodeCache;

        public LocationNodeService(ILocationNodeCache locationsNodeCache)
        {
            this.locationsNodeCache = locationsNodeCache;
        }

        public Task<LocationNode> GetById(int id)
        {
            return locationsNodeCache.GetById(id);
        }

        public Task<IList<LocationNode>> GetByIds(params int[] ids)
        {
            return locationsNodeCache.GetByIds(ids);
        }

        public Task<bool> HashSet(LocationNode model)
        {
            return locationsNodeCache.HashSet(model);
        }

        public Task HashDelete(int id)
        {
            return locationsNodeCache.HashDelete(id);
        }
    }
}
