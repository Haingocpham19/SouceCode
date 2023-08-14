using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class PolicyService : IPolicyService
    {

        private readonly IPolicyCache policyCache;

        public PolicyService(IPolicyCache policyCache)
        {
            this.policyCache = policyCache;
        }

        public Task<IList<Policy>> GetAll(string languageId)
        {
            return policyCache.GetAll(languageId);
        }
    }
}
