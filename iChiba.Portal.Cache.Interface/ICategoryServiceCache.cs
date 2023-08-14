using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface ICategoryServiceCache : IBaseHashCache<CategoryService, int>
    {
        Task<IList<CategoryService>> GetAll(string languageId);
        Task<bool> StringSet(IList<CategoryService> models, string languageId);
    }
}
