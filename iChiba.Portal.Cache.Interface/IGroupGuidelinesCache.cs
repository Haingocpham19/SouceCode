using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IGroupGuidelinesCache : IBaseHashCache<GroupGuidelines, int>
    {
        Task<IList<GroupGuidelines>> GetAll(string languageId);
        Task<bool> StringSet(IList<GroupGuidelines> models, string languageId);
    }
}
