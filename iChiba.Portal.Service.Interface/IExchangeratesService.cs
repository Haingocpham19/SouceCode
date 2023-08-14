using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface IExchangeratesService
    {
        Task<IList<Exchangerates>> GetAll();
        Task<Exchangerates> GetByCode(string code);
        Task<decimal> GetRateByCode(string code);
    }
}
