using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class PaymentTransactionHistoryListResponse : PagingResponse<IList<PaymentTransactionHistoryViewModel>>
    {
        public PaymentTransactionHistoryListResponse()
        {
            Data = new List<PaymentTransactionHistoryViewModel>();
        }
    }
}
