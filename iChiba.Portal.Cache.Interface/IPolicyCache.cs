using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IPolicyCache : IBaseHashCache<Policy, int>
    {
        Task<IList<Policy>> GetAll(string languageId);
        Task<bool> StringSet(IList< Policy> models, string languageId);
    }
}
