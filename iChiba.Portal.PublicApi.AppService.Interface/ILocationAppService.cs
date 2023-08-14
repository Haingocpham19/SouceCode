using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface ILocationAppService
    {
        Task<BaseEntityResponse<IList<Location>>> GetLocationsChild(int id);
        Task<LocationForAddressCustomerResponse> GetLocationsForAddressCustomer(LocationForAddressCustomerRequest request);
    }
}
