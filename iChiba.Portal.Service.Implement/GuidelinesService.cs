using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class GuidelinesService : IGuidelinesService
    {

        private readonly IGuidelinesCache guidelinesCache;

        public GuidelinesService(IGuidelinesCache guidelinesCache)
        {
            this.guidelinesCache = guidelinesCache;
        }

        public Task<IList<Guidelines>> GetAll(string languageId)
        {
            return guidelinesCache.GetAll(languageId);
        }
    }
}
