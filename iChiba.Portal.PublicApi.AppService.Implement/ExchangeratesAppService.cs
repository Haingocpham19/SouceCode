using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Interface;
using Core.AppModel.Response;
using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class ExchangeratesAppService : BaseAppService, IExchangeratesAppService
    {
        private readonly IExchangeratesService exchangeratesService;

        public ExchangeratesAppService(ILogger<ExchangeratesAppService> logger,
            IExchangeratesService exchangeratesService
            )
            : base(logger)
        {
            this.exchangeratesService = exchangeratesService;
        }


        public async Task<BaseEntityResponse<IList<Exchangerates>>> GetAll()
        {
            var response = new BaseEntityResponse<IList<Exchangerates>>();
            await TryCatchAsync(async () =>
            {
                var data = await exchangeratesService.GetAll();

                var responseData = data.Select(m => m.ToModel()).ToList();
                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;
        }
    }
}
