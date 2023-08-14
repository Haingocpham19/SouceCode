using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface IGuidelinesService
    {
        Task<IList<Guidelines>> GetAll(string languageId);
    }
}
