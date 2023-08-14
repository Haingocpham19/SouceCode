using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.Controllers
{
    public class PackageDetailQuoteController : BaseController
    {
        private readonly IPackageDetailQuoteAppService _packageDetailQuoteAppService;

        public PackageDetailQuoteController(
            ILogger<CustomerController> logger,
            IPackageDetailQuoteAppService packageDetailQuoteAppService) : base(logger)
        {
            _packageDetailQuoteAppService = packageDetailQuoteAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PackageDetailQuoteResponse))]
        public async Task<IActionResult> GetPackageDetailQuoteInfo(PackageDetailQuoteInfoRequest request)
        {
            try
            {
                var response = await _packageDetailQuoteAppService.GetPackageDetailQuoteInfo(request);

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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> ExportOrderPriceQuotes(PackageDetailQuoteInfoRequest request)
        {
            try
            {
                var response = new BaseResponse();
                using (var stream = await _packageDetailQuoteAppService.ExportOrderPriceQuotes(request))
                {
                    if (stream != null)
                    {
                        using (var buffer = stream as MemoryStream)
                        {
                            if (buffer != null)
                            {
                                return File(buffer.ToArray(),
                                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "save.xlsx");
                            }

                            response.Status = false;
                            return Ok(response);
                        }
                    }

                    response.Status = false;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

    }
}
