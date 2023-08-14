using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class OrderPriceQuotesDeliveryBillCodeListResponse : PagingResponse<IList<DeliveryBillCodeViewModel>>
    {
        public OrderPriceQuotesDeliveryBillCodeListResponse()
        {
            Data = new List<DeliveryBillCodeViewModel>();
        }
    }
}
