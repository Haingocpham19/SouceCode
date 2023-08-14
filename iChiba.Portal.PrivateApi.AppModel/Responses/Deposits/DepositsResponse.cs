using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class DepositsHistoryResponse : PagingResponse<IList<DepositsHistoryViewModel>>
    {
        public DepositsHistoryResponse()
        {
            Data = new List<DepositsHistoryViewModel>();
        }
    }
}
