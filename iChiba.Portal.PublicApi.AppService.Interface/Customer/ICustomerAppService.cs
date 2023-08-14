using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface ICustomerAppService
    {
        Task<BaseResponse> Add(string group, BaseApiRequest request);
        Task<BaseResponse> Update(BaseApiRequest request);
        Task<BaseEntityResponse<Customer>> GetDetail(BaseApiRequest request);
        Task<BaseEntityResponse<Customer>> GetDetailActivateTransport(BaseApiRequest request);
        Task<Dictionary<string, string>> GetCustomerLevel(BaseApiRequest request);
        Task<BaseResponse> UpdateIdImages(CustomerVerifyUpdateRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> ActivateTransport(ActivateTransportRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> UpdateSurvey(UpdateSurveyRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> AddProfile(CustomerProfileRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> UpdateProfile(CustomerProfileRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<CustomerProfileDetail>> GetProfileByKey(string key, BaseApiRequest request);
        Task<BaseEntityResponse<int>> GetBuyFee(BaseApiRequest request);
        Task<BaseEntityResponse<CustomerWallet>> GetWallet(CustomerRequest request);
        Task<BaseEntityResponse<long>> GetCashAvailable(BaseApiRequest request);
        Task<BaseEntityResponse<CustomerDebt>> GetDebt(BaseApiRequest request);
    }
}
