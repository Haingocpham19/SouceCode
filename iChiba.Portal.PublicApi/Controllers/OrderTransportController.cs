using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Ichiba.Cdn.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Response;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class OrderTransportConfig
    {
        public string GetAllOrderService { get; set; }
        public string GetAllProductType { get; set; }
        public string GetListByAccount { get; set; }
        public string Add { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }
        public string GetDetail { get; set; }
        public string GetAllWarehouses { get; set; }
        public string GetAllWarehouseTransportActive { get; set; }
        public string GetAllTransportDDImports { get; set; }
        public string CountOrderTranportList { get; set; }
        public string UploadToCdn { get; set; }
        public string CountOrderTranportListByStatus { get; set; }
        public string GetAllShippingRouteWarehouses { get; set; }
        public string GetPackageTracking { get; set; }
        public string ExistsTracking { get; set; }
        public string ExistsTrackingForEdit { get; set; }
        public string GetDetailByTrackingNumber { get; set; }
        public string CheckExitsTracking { get; set; }
    }

    [Authorize]
    public class OrderTransportController : BaseController
    {
        private readonly IOptions<OrderTransportConfig> orderTransportConfig;
        private readonly IOrderTransportAppService orderTransportAppService;
        private readonly ILocationAppService locationAppService;

        public OrderTransportController(ILogger<OrderTransportController> logger,
             IOptions<OrderTransportConfig> orderTransportConfig,
            IOrderTransportAppService orderTransportAppService,
            ILocationAppService locationAppService)
            : base(logger)
        {
            this.orderTransportConfig = orderTransportConfig;
            this.orderTransportAppService = orderTransportAppService;
            this.locationAppService = locationAppService;
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<OrderServiceList>>))]
        public async Task<IActionResult> GetAllOrderService()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.GetAllOrderService;
            var request = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.GetAllOrderService(request);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<ProductTypeList>>))]
        public async Task<IActionResult> GetAllProductType(string keyword = default)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.GetAllProductType;
            var request = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.GetAllProductType(keyword, request);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<OrderList>>))]
        public async Task<IActionResult> GetListByAccount(OrderTransportListRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.GetListByAccount;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.GetListByAccount(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<string>))]
        public async Task<IActionResult> Add(OrderTransportRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.Add;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.Add(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Update(OrderTransportRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.Update;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.Update(request, baseApi);

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<OrderTransport>))]
        public async Task<IActionResult> GetDetail(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.GetDetail;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.GetDetail(id, baseApi);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetDetailByTrackingNumber(OrderTransportTrackRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.GetDetailByTrackingNumber;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.GetDetailByTrackingNumber(request, baseApi);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Warehouse>>))]
        public async Task<IActionResult> GetAllWarehouses()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.GetAllWarehouses;
            var request = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.GetAllWarehouses(request);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Warehouse>>))]
        public async Task<IActionResult> GetAllWarehouseTransportActive()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.GetAllWarehouseTransportActive;
            var request = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.GetAllWarehouseTransportActive(request);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Warehouse>>))]
        public async Task<IActionResult> GetAllTransportDDImports()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.GetAllTransportDDImports;
            var request = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.GetAllTransportDDImports(request);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<CountOrderTransport>>))]
        public async Task<IActionResult> CountOrderTranportList(OrderTransportCountRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.CountOrderTranportList;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.CountOrderTranportList(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<CountOrderTransport>>))]
        public async Task<IActionResult> CountOrderTranportListByStatus(OrderTransportByStatus request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.CountOrderTranportListByStatus;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.CountOrderTranportListByStatus(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(FileUploadResponse))]
        public async Task<IActionResult> UploadToCdn(UploadToCdnRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.UploadToCdn;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.UploadToCdn(request, baseApi);

            return Ok(response);
        }

        [HttpPost("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.Delete;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.Delete(id, baseApi);

            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> CheckExitsTracking(OrderTransportRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.CheckExitsTracking;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.CheckExitsTracking(request, baseApi);

            return Ok(response);
        }




        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<ShippingRoute>>))]
        public async Task<IActionResult> GetAllShippingRouteWarehouses()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.GetAllShippingRouteWarehouses;
            var request = new BaseApiRequest
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.GetAllShippingRouteWarehouses(request);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<PackageTrackingList>>))]
        public async Task<IActionResult> GetPackageTracking(PackageTrackingGetByTrackingRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.GetPackageTracking;
            var baseApi = new BaseApiRequest
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.GetPackageTracking(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<bool>))]
        public async Task<IActionResult> ExistsTracking(OrderTransportRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.ExistsTracking;
            var baseApi = new BaseApiRequest
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.ExistsTracking(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<bool>))]
        public async Task<IActionResult> ExistsTrackingForEdit(OrderTransportRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderTransportConfig.Value.ExistsTrackingForEdit;
            var baseApi = new BaseApiRequest
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderTransportAppService.ExistsTrackingForEdit(request, baseApi);

            return Ok(response);
        }
    }
}
