using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IGuidelinesCache : IBaseHashCache<Guidelines, int>
    {
        Task<IList<Guidelines>> GetAll(string languageId);
        Task<bool> StringSet(IList<Guidelines> models, string languageId);
    }
}
