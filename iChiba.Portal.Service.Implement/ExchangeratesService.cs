using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class ExchangeratesService : IExchangeratesService
    {

        private readonly IExchangeratesCache exchangeratesCache;
        private List<string> CURRENCY_CODE_NOT_ROUND = new List<string> { "KRW" };

        public ExchangeratesService(IExchangeratesCache exchangeratesCache)
        {
            this.exchangeratesCache = exchangeratesCache;
        }

        public Task<IList<Exchangerates>> GetAll()
        {
            return exchangeratesCache.GetAll();
        }
        public async Task<Exchangerates> GetByCode(string code)
        {
            var exchangerate = await GetAll();
            var exchange = exchangerate.FirstOrDefault(m => string.CompareOrdinal(m.Code, code) == 0);

            return exchange;
        }

        public async Task<decimal> GetRateByCode(string code)
        {
            var exchange = await GetByCode(code);
            var add = exchange.Add == null ? 1 : (decimal)exchange.Add;
            var sell = exchange.Sell == null ? 1 : (decimal)exchange.Sell;
            //var rate = Math.Round(add * sell + 0.1m, MidpointRounding.AwayFromZero);
            //return rate;

            var rate = add * sell;
            if (CURRENCY_CODE_NOT_ROUND.Contains(code))
            {
                return Math.Round(rate, 0, MidpointRounding.AwayFromZero);
            }
            return RoundExchangeRate(rate);
        }

        private decimal RoundExchangeRate(decimal? value)
        {
            if (value == null || value == 0) return 0;
            if (value >= 1000)
            {
                var surplus = value % 100;
                if (surplus == 0) return (decimal)value;
                else if (surplus < 50) return ((int)(value / 100)) * 100;
                else return ((int)(value / 100) + 1) * 100;
            }
            else
            {
                var surplus = (decimal)(value - (int)value);
                if (surplus == 0) return (decimal)value;
                else return (decimal)((int)value + 1);
            }
        }
    }
}
