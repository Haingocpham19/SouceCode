using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class ServiceService : IServiceService
    {

        private readonly IServiceCache serviceCache;

        public ServiceService(IServiceCache serviceCache)
        {
            this.serviceCache = serviceCache;
        }

        public Task<IList<iChiba.Portal.Cache.Model.Service>> GetAll(string languageId)
        {
            return serviceCache.GetAll(languageId);
        }
    }
}
