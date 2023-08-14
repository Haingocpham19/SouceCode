using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class MetaconfigService : IMetaconfigService
    {

        private readonly IMetaconfigCache metaconfigCache;

        public MetaconfigService(IMetaconfigCache metaconfigCache)
        {
            this.metaconfigCache = metaconfigCache;
        }

        public Task<IList<Metaconfig>> GetAll(string languageId)
        {
            return metaconfigCache.GetAll(languageId);
        }
    }
}
