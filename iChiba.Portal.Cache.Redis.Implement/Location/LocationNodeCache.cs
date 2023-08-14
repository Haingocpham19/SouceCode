using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Cache.Redis.Implement;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class LocationNodeCache : BaseHashCache<LocationNode, int>, ILocationNodeCache
    {
        private const string KEY = "Locations-Node";

        public LocationNodeCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<bool> HashSet(LocationNode model)
        {
            return await redisStorage.HashSet(key, model.Id.ToString(), model);
        }
    }
}
