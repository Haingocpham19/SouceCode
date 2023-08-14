using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class GroupGuidelinesService : IGroupGuidelinesService
    {

        private readonly IGroupGuidelinesCache groupGuidelinesCache;

        public GroupGuidelinesService(IGroupGuidelinesCache groupGuidelinesCache)
        {
            this.groupGuidelinesCache = groupGuidelinesCache;
        }

        public Task<IList<GroupGuidelines>> GetAll(string languageId)
        {
            return groupGuidelinesCache.GetAll(languageId);
        }
    }
}
