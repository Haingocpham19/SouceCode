using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface ICustomerAddressAppService
    {
        Task<BaseEntityResponse<IList<CustomerAddress>>> GetAddressByCustomer(BaseApiRequest baseApi);
        Task<BaseResponse> Add(CustomerAddressAddRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> Update(CustomerAddressUpdateRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<CustomerAddress>> GetDetail(int id, BaseApiRequest baseApi);
        Task<BaseResponse> Delete(int id, BaseApiRequest baseApi);
        Task<BaseResponse> UpdateActive(int id, BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<CustomerAddress>>> ListAddressByCustomer(BaseApiRequest baseApi);
    }
}
