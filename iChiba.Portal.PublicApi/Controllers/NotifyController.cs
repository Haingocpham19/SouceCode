using System;
using System.Net;
using System.Threading.Tasks;
using iChiba.Event.Api.AppModel.Model;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChiba.Portal.PublicApi.Driver.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace iChiba.Portal.PublicApi.Controllers
{
    [Authorize]
    public class NotifyController : BaseController
    {
        private readonly INotifyClient notifyClient;
        private readonly INotifyAppService notifyAppService;

        public NotifyController(
            ILogger<NotifyController> logger,
            INotifyClient notifyClient,
            INotifyAppService notifyAppService)
            : base(logger)
        {
            this.notifyClient = notifyClient;
            this.notifyAppService = notifyAppService;
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeToTopic(SubscribeNotifyModel m)
        {
            try
            {
                var response = await notifyClient.SubscribeToTopic(m);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return Ok(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UnsubscribeFromTopic(SubscribeNotifyModel m)
        {
            try
            {
                var response = await notifyClient.UnsubscribeFromTopic(m);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return Ok(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }


        //[HttpPost]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.Forbidden)]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GetNotifyGroupByAppIdResponse))]
        //public async Task<IActionResult> GetNotifyGroupByAppId(GetNotifyGroupByAppIdRequest request)
        //{
        //    var response = await notifyAppService.GetNotifyGroupByAppId(request);
        //    return Ok(response);
        //}

        //[HttpPost]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.Forbidden)]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AddOrUpdateCustomerNotifyConfigResponse))]
        //public async Task<IActionResult> AddOrUpdateCustomerNotifyConfig(AddOrUpdateCustomerNotifyConfigRequest request)
        //{
        //    var response = await notifyAppService.AddOrUpdateCustomerNotifyConfig(request);
        //    return Ok(response);
        //}
    }
}
