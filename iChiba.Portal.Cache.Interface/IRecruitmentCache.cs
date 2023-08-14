using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IRecruitmentCache : IBaseHashCache<Recruitment, int>
    {
        Task<IList<Recruitment>> GetAll(string languageId);
        Task<bool> StringSet(IList< Recruitment> models, string languageId);
    }
}
