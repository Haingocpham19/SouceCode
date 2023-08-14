using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppModel.Response;
using System;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IAccountAppService
    {
        Task<Object> CheckEmail(BaseApiRequest request, string email);
        Task<Object> CheckPhone(BaseApiRequest request, string phone);
        Task<bool> CheckUsername(BaseApiRequest request, string username);
        Task<int> AccessFailedCount(BaseApiRequest request, string username);
        Task<bool> LockoutEnabled(BaseApiRequest request, string username);
        Task<AccountProfileUpdateResponse> UpdateProfile(BaseApiRequest request, ProfileUpdateRequest model); 
        Task<AccountUpdatePasswordResponse> ChangePassword(BaseApiRequest request, ChangePasswordRequest model);  
    }
}
