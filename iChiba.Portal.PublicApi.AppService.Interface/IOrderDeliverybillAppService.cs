using Core.AppModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IOrderDeliverybillAppService
    {
        Task<PagingResponse<IList<OrderDeliverybillList>>> GetList(OrderDeliverybillListRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<OrderDeliverybillPayment>> TotalAmountTobePaidAllBillCode(OrderDeliverybillListRequest request, BaseApiRequest baseApi);
    }
}
