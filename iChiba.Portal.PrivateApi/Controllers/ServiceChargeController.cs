using System;
using System.Net;
using System.Threading.Tasks;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PrivateApi.Controllers
{
    public class ServiceChargeController : BaseController
    {
        private readonly IServiceChargeAppService _serviceChargeAppService;
        public ServiceChargeController(
            ILogger<ServiceChargeController> logger,
            IServiceChargeAppService serviceChargeAppService)
            : base(logger)
        {
            _serviceChargeAppService = serviceChargeAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceChargeListResponse))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _serviceChargeAppService.GetAll();

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
