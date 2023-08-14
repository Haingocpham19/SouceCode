using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class CustomerAddressConfig
    {
        public string GetAddressByCustomer { get; set; }
        public string Add { get; set; }
        public string Update { get; set; }
        public string GetDetail { get; set; }
        public string Delete { get; set; }
        public string UpdateActive { get; set; }
    }

    [Authorize]
    public class CustomerAddressController : BaseController
    {
        private readonly IOptions<CustomerAddressConfig> customerAddressConfig;
        private readonly ICustomerAddressAppService customerAddressAppService;
        private readonly ILocationAppService locationAppService;

        public CustomerAddressController(ILogger<CustomerAddressController> logger,
             IOptions<CustomerAddressConfig> customerAddressConfig,
            ICustomerAddressAppService customerAddressAppService,
            ILocationAppService locationAppService)
            : base(logger)
        {
            this.customerAddressConfig = customerAddressConfig;
            this.customerAddressAppService = customerAddressAppService;
            this.locationAppService = locationAppService;
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<CustomerAddress>>))]
        public async Task<IActionResult> GetAddressByCustomer()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerAddressConfig.Value.GetAddressByCustomer;
            var request = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerAddressAppService.GetAddressByCustomer(request);
            response.Data.Select(m =>
            {
                var addressData = locationAppService.GetLocationsForAddressCustomer(new LocationForAddressCustomerRequest() { ProvinceName = m.Province, DistrictName = m.District }).GetAwaiter().GetResult();
                m.ProvinceList = addressData.ProvinceList;
                m.DistrictList = addressData.DisttrictList;
                m.WardList = addressData.WardList;
                return m;
            }).ToList();
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Add(CustomerAddressAddRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerAddressConfig.Value.Add;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerAddressAppService.Add(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Update(CustomerAddressUpdateRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerAddressConfig.Value.Update;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerAddressAppService.Update(request, baseApi);

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<CustomerAddress>))]
        public async Task<IActionResult> GetDetail(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerAddressConfig.Value.GetDetail;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerAddressAppService.GetDetail(id, baseApi);

            var addressData = locationAppService.GetLocationsForAddressCustomer(new LocationForAddressCustomerRequest()
            { ProvinceName = response.Data.Province, DistrictName = response.Data.District }).GetAwaiter().GetResult();
            response.Data.ProvinceList = addressData.ProvinceList;
            response.Data.DistrictList = addressData.DisttrictList;
            response.Data.WardList = addressData.WardList;

            return Ok(response);
        }

        [HttpPost("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerAddressConfig.Value.Delete;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerAddressAppService.Delete(id, baseApi);
            return Ok(response);
        }

        [HttpPost("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> UpdateActive(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerAddressConfig.Value.UpdateActive;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerAddressAppService.UpdateActive(id, baseApi);
            return Ok(response);
        }

        //[HttpGet]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.Forbidden)]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<CustomerAddress>>))]
        //public async Task<IActionResult> ListAddressByCustomer()
        //{
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");
        //    var url = customerAddressConfig.Value.GetAddressByCustomer;
        //    var request = new BaseApiRequest()
        //    {
        //        Accesstoken = accessToken,
        //        Url = url
        //    };
        //    var response = await customerAddressAppService.ListAddressByCustomer(request);
        //    if (response.Status)
        //    {
        //        response.Data.Select(m =>
        //        {
        //            var addressData = locationAppService.GetLocationsForAddressCustomer(new LocationsForAddressCustomerRequest() { ProvinceName = m.Province, DistrictName = m.District }).GetAwaiter().GetResult();
        //            m.ProvinceList = addressData.ProvinceList;
        //            m.DistrictList = addressData.DisttrictList;
        //            m.WardList = addressData.WardList;
        //            return m;
        //        }).ToList();
        //    }
        //    return Ok(response);
        //}
    }
}
