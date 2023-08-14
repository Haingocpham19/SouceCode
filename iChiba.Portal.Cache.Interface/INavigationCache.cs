using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface INavigationCache : IBaseHashCache<Navigation, int>
    {
        Task<IList<Navigation>> GetAll(string languageId);
        Task<bool> StringSet(IList<Navigation> models, string languageId);
    }
}
