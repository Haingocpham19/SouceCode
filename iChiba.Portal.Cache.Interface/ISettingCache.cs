using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface ISettingCache : IBaseHashCache<Settings, string>
    {
        Task<IList<Settings>> GetAll(string languageId);
        Task<bool> HashSet(Settings model, string languageId);
    }
}
