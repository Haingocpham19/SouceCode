using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using Ichiba.Cdn.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Response;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IOrderTransportAppService
    {
        Task<BaseEntityResponse<IList<OrderServiceList>>> GetAllOrderService(BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<ProductTypeList>>> GetAllProductType(string keyword, BaseApiRequest baseApi);
        Task<PagingResponse<IList<OrderList>>> GetListByAccount(OrderTransportListRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<string>> Add(OrderTransportRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> Update(OrderTransportRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<OrderTransport>> GetDetail(int id, BaseApiRequest baseApi);
        Task<BaseEntityResponse<OrderTransport>> GetDetailByTrackingNumber(OrderTransportTrackRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<Warehouse>>> GetAllWarehouses(BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<Warehouse>>> GetAllWarehouseTransportActive(BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<Ddimport>>> GetAllTransportDDImports(BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<CountOrderTransport>>> CountOrderTranportList(OrderTransportCountRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<CountOrderTransportByStatus>>> CountOrderTranportListByStatus(OrderTransportByStatus request, BaseApiRequest baseApi);
        Task<FileUploadResponse> UploadToCdn(UploadToCdnRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> Delete(int orderId, BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<ShippingRoute>>> GetAllShippingRouteWarehouses(BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<PackageTrackingList>>> GetPackageTracking(PackageTrackingGetByTrackingRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<bool>> ExistsTracking(OrderTransportRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<bool>> ExistsTrackingForEdit(OrderTransportRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<bool>> CheckExitsTracking(OrderTransportRequest request, BaseApiRequest baseApi);
    }
}
