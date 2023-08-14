using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class OrderResponse : PagingResponse<OrderViewModel>
    {
        public OrderResponse()
        {
            Data = new OrderViewModel();
        }
    }
    public class OrderBuyForYouAddResponse : BaseEntityResponse<List<OrderBuyForYouAddRequest>>
    {
        public OrderBuyForYouAddResponse()
        {
            Data = new List<OrderBuyForYouAddRequest>();
        }
    }
}
