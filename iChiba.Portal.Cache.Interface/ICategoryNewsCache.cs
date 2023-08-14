using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface ICategoryNewsCache : IBaseHashCache<CategoryNews, int>
    {
        Task<IList<CategoryNews>> GetAll(string languageId);
        Task<bool> StringSet(IList<CategoryNews> models, string languageId);
    }
}
