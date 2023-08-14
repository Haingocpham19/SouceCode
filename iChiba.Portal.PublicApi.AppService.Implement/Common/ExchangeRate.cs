using iChiba.Portal.Common;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Implement.Common
{
    public class ExchangeRate
    {
        private readonly IExchangeratesService exchangerateService;

        public ExchangeRate(IExchangeratesService exchangerateService)
        {
            this.exchangerateService = exchangerateService;
        }

        public Task<decimal> GetJPRate()
        {
            return exchangerateService.GetRateByCode(Constant.CODE_EXCHANGERATES_JPY);
        }

        public Task<decimal> GetUSDRate()
        {
            return exchangerateService.GetRateByCode(Constant.CODE_EXCHANGERATES_USD);
        }

        public Task<decimal> GetRate(string code)
        {
            return exchangerateService.GetRateByCode(code);
        }

        public decimal ChangePriceVNDByRate(decimal price, decimal rate)
        {
            return Math.Round(price * rate, MidpointRounding.AwayFromZero);
        }
    }
}