using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IExchangeratesCache
    {
        Task<IList<Exchangerates>> GetAll();
        Task<bool> StringSet(IList<Exchangerates> models);
    }
}
