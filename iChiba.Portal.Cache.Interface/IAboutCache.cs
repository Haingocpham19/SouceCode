using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IAboutCache : IBaseHashCache<About, int>
    {
        Task<IList<About>> GetAll(string languageId);
        Task<bool> StringSet(IList<About> models, string languageId);
    }
}
