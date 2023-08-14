using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Cache.Redis.Implement;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class LocationParentNodeCache : BaseHashCache<LocationParentNode, int>, ILocationParentNodeCache
    {
        private const string KEY = "Locations-Parent-Node";

        public LocationParentNodeCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<bool> HashSet(LocationParentNode model)
        {
            return await redisStorage.HashSet(key, model.Id.ToString(), model);
        }
    }
}
