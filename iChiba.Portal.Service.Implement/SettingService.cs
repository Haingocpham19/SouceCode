using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Implement
{
    public class SettingService : ISettingService
    {

        private readonly ISettingCache settingCache;

        public SettingService(ISettingCache settingCache)
        {
            this.settingCache = settingCache;
        }

        public Task<IList<Settings>> GetAll(string languageId)
        {
            return settingCache.GetAll(languageId);
        }
    }
}
