using iChiba.OM.Service.Interface;
using iChiba.Portal.PrivateApi.AppService.Interface;
using iChiba.Portal.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
   public class ExchangeratesAppService : IExchangeratesAppService
    {
        private readonly IExchangeratesService exchangeratesService;
        public ExchangeratesAppService(IExchangeratesService exchangeratesService)
        {
            this.exchangeratesService = exchangeratesService;
        }
        public async Task<decimal> GetRateByCode(string code)
        {
            var exchange = await exchangeratesService.GetRateByCode(code);
            return exchange;
        }
    }
}
