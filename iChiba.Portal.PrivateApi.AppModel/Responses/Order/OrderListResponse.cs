using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class OrderListResponse : PagingResponse<IList<OrderViewModel>>
    {
        public OrderListResponse()
        {
            Data = new List<OrderViewModel>();
        }
    }
}
