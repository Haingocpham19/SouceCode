using Core.AppModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IBankinfoAppService
    {
        Task<BaseEntityResponse<IList<Bankinfo>>> GetListAll(BaseApiRequest baseApi);
        Task<BaseEntityResponse<Bankinfo>> GetById(int id, BaseApiRequest baseApi);
        Task<BaseEntityResponse<Bankinfo>> GetByAccountNumber(string accountNumber, BaseApiRequest baseApi);
        Task<BaseEntityResponse<Bankinfo>> GetByBankName(string bankName, BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<Bankinfo>>> GetListByForDepositOrDrawal(BaseApiRequest baseApi, string bankType);
    }
}
