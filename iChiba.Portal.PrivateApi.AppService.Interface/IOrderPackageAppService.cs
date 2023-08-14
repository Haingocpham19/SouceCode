using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IOrderPackageAppService
    {
        Task<BaseResponse> Add(OrderPackageAddRequest request);
        Task<BaseResponse> Delete(int id);
        Task<BaseEntityResponse<OrderPackageList>> GetDetail(int id);
        Task<PagingResponse<IList<OrderPackageList>>> GetList(OrderPackageListRequest request);
        Task<BaseResponse> Update(OrderPackageUpdateRequest request);
        Task<OrderPackageImportResponse> ImportOrderPackage(OrderPackageImportRequest request);
        Task<ProductTypeListResponse> GetListProductType();
        Task<OrderListResponse> AddOrderTransport(List<OrderTransportAddRequest> request);
    }
}