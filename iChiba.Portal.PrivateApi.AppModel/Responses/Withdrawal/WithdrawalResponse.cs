using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class WithdrawalHistoryResponse : PagingResponse<IList<WithdrawalHistoryViewModel>>
    {
        public WithdrawalHistoryResponse()
        {
            Data = new List<WithdrawalHistoryViewModel>();
        }
    }
}
