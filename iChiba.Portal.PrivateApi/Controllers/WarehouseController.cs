using iChiba.Portal.PrivateApi.AppService.Interface;
using Ichiba.WH.Api.Driver.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.Controllers
{
    public class WarehouseController : BaseController
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IWarehouseAppService _warehouseAppService;

        public WarehouseController(
            ILogger<CustomerController> logger,
            ICustomerAppService customerAppService,
            IWarehouseAppService warehouseAppService
            ) : base(logger)
        {
            _customerAppService = customerAppService;
            _warehouseAppService = warehouseAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WarehouseListResponse))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _warehouseAppService.GetAll();

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WarehouseListResponse))]
        public async Task<IActionResult> GetByRoute(string route)
        {
            try
            {
                var response = await _warehouseAppService.GetByRoute(route);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }
    }
}