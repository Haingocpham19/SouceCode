using System.Threading.Tasks;
using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class AspNetUserCache : BaseHashCache<AspNetUser, string>, IAspNetUserCache
    {
        private const string KEY = "AIM_ASPNETUSER";

        public AspNetUserCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public Task<bool> HashSet(AspNetUser model)
        {
            return redisStorage.HashSet(key, model.Id, model);
        }
    }
}
