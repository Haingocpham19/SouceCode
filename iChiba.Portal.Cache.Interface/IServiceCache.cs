using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IServiceCache : IBaseHashCache<Service, int>
    {
        Task<IList<Service>> GetAll(string languageId);
        Task<bool> StringSet(IList<Service> models, string languageId);
    }
}
