using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;
namespace Ichiba.WH.Api.Driver.Response
{
    public class OrderPriceQuotesDeliveryBillCodeListResponse : PagingResponse<IList<DeliveryBillCodeViewModel>>
    {
        public OrderPriceQuotesDeliveryBillCodeListResponse()
        {
            Data = new List<DeliveryBillCodeViewModel>();
        }
    }

    public class OrderPriceQuotesDeliveryBillCodeResponse : BaseEntityResponse<DeliveryBillCodeViewModel>
    {
        public OrderPriceQuotesDeliveryBillCodeResponse()
        {
            Data = new DeliveryBillCodeViewModel();
        }
    }
}
