using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IMetaconfigCache 
    {
        Task<IList<Metaconfig>> GetAll(string languageId);
        Task<bool> StringSet(IList<Metaconfig> models, string languageId);
    }
}
