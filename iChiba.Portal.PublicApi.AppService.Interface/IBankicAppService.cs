using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IBankicAppService
    {
        Task<BaseEntityResponse<IList<Bankic>>> GetListAll(BaseApiRequest baseApi);
        Task<BaseEntityResponse<Bankic>> GetById(int id, BaseApiRequest baseApi);
        Task<BaseEntityResponse<Bankic>> GetByAccountNumber(string accountNumber, BaseApiRequest baseApi);
        Task<BaseEntityResponse<Bankic>> GetByBankName(string bankName, BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<Bankic>>> GetListActiveDeposit(BaseApiRequest baseApi);
    }
}
