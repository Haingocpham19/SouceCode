using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class WarehouseConfig
    {
        public string GetAllWarehouseActive { get; set; }
        public string GetDetail { get; set; }
        public string GetByCode { get; set; }
    }

    [Authorize]
    public class WarehouseController : BaseController
    {
        private readonly IOptions<WarehouseConfig> warehouseConfig;
        private readonly IWarehouseAppService warehouseAppService;

        public WarehouseController(ILogger<WarehouseController> logger,
             IOptions<WarehouseConfig> warehouseConfig,
            IWarehouseAppService warehouseAppService)
            : base(logger)
        {
            this.warehouseConfig = warehouseConfig;
            this.warehouseAppService = warehouseAppService;
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Warehouse>>))]
        public async Task<IActionResult> GetAllWarehouseActive()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = warehouseConfig.Value.GetAllWarehouseActive;
            var request = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await warehouseAppService.GetAllWarehouseActive(request);
            return Ok(response);
        }

        [HttpPost("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Warehouse>))]
        public async Task<IActionResult> GetDetail(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = warehouseConfig.Value.GetDetail;
            var request = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await warehouseAppService.GetDetail(request, id);
            return Ok(response);
        }

        [HttpPost("{code}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Warehouse>))]
        public async Task<IActionResult> GetByCode(string code)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = warehouseConfig.Value.GetByCode;
            var request = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await warehouseAppService.GetByCode(request, code);
            return Ok(response);
        }
    }
}
