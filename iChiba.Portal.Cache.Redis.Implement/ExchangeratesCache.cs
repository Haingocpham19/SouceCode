using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class ExchangeratesCache : IExchangeratesCache
    {
        private const string KEY = "PortalExchangerates";
        private readonly IRedisStorage redisStorage;
        public ExchangeratesCache(IRedisStorage redisStorage)
        {
            this.redisStorage = redisStorage;
        }

        public async Task<IList<Exchangerates>> GetAll()
        {
            return await redisStorage.StringGet<IList<Exchangerates>>(KEY);
        }

        public async Task<bool> StringSet(IList<Exchangerates> models)
        {
            return await redisStorage.StringSet(KEY, models);
        }
    }
}
