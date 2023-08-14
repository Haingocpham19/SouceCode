using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface ICategoryAboutCache 
    {
        Task<IList<CategoryAbout>> GetAll(string languageId);
        Task<bool> StringSet(IList<CategoryAbout> models, string languageId);
    }
}
