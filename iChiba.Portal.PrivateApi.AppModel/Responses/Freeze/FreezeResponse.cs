using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class FreezeHistoryResponse : PagingResponse<IList<FreezeHistoryViewModel>>
    {
        public FreezeHistoryResponse()
        {
            Data = new List<FreezeHistoryViewModel>();
        }
    }
}
