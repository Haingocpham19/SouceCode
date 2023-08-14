using iChiba.Portal.Cache.Interface;
using iChiba.Portal.ExtensionApi.AppModel.Response;
using iChiba.Portal.ExtensionApi.AppService.Implement.Adapter;
using iChiba.Portal.ExtensionApi.AppService.Interface;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.ExtensionApi.AppService.Implement
{
    public class ExchangeratesService : BaseAppService, IExchangeratesService
    {
        private readonly IExchangeratesCache _exchangeratesCache;
        public ExchangeratesService(IExchangeratesCache exchangeratesCache, ILogger<ExchangeratesService> logger) : base(logger)
        {
            _exchangeratesCache = exchangeratesCache;
        }

        public async Task<ExchangratesResponsse> GetAllExchangrates()
        {
            var res = new ExchangratesResponsse();
            await TryCatchAsync(async () =>
            {
                var result = await _exchangeratesCache.GetAll();
                var listExchangerates = result.Select(x => x.ToViewModel()).ToList();
                res.SetData(listExchangerates).Successful();
            }, res);
            return res;
        }
    }
}
