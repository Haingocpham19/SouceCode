using Core.AppModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface ICustomerBankinfoAppService
    {
        Task<BaseEntityResponse<IList<CustomerBankinfo>>> GetList(BaseApiRequest request);
        Task<BaseEntityResponse<CustomerBankinfo>> GetById(int id, BaseApiRequest request);
        Task<BaseResponse> Add(CustomerBankinfoAddRequest request, BaseApiRequest apiRequest);
        Task<BaseResponse> Update(CustomerBankinfoUpdateRequest request, BaseApiRequest apiRequest);
        Task<BaseResponse> Delete(int id, BaseApiRequest apiRequest);
    }
}
