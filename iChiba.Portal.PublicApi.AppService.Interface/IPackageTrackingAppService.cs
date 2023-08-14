using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IPackageTrackingAppService
    {
        Task<BaseEntityResponse<IList<PackageTracking>>> GetsPackageTracking(string tracking, BaseApiRequest baseApi);
    }
}