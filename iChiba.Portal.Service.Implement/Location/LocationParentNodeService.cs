using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Implement
{
    public class LocationParentNodeService : ILocationParentNodeService
    {
        private readonly ILocationParentNodeCache locationParentNodeCache;

        public LocationParentNodeService(ILocationParentNodeCache locationParentNodeCache)
        {
            this.locationParentNodeCache = locationParentNodeCache;
        }

        public Task<LocationParentNode> GetById(int id)
        {
            return locationParentNodeCache.GetById(id);
        }


        public Task<IList<LocationParentNode>> GetByIds(params int[] ids)
        {
            return locationParentNodeCache.GetByIds(ids);
        }

        public Task<bool> HashSet(LocationParentNode model)
        {
            return locationParentNodeCache.HashSet(model);
        }

        public Task HashDelete(int id)
        {
            return locationParentNodeCache.HashDelete(id);
        }
    }
}
