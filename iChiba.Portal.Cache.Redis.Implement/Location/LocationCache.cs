using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Cache.Redis.Implement;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class LocationCache : BaseHashCache<Location, int>, ILocationCache
    {
        private const string KEY = "Locations";

        public LocationCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<bool> HashSet(Location model)
        {
            return await redisStorage.HashSet(key, model.Id.ToString(), model);
        }
    }
}
