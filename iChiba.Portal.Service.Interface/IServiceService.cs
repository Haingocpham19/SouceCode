using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface IServiceService
    {
        Task<IList<iChiba.Portal.Cache.Model.Service>> GetAll(string languageId);
    }
}
