using iChiba.Portal.PrivateApi.AppService.Interface;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections.Generic;
using Core.AppModel.Response;

namespace iChiba.Portal.PrivateApi.Controllers
{
    public class OrderPackageController : BaseController
    {
        private readonly IOrderPackageAppService _orderPackageAppService;
        public OrderPackageController(
            ILogger<OrderPackageController> logger,
            IOrderPackageAppService orderPackageAppService)
            : base(logger)
        {
            _orderPackageAppService = orderPackageAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OrderPackageImportResponse))]
        public async Task<IActionResult> ImportOrderPackage()
        {
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                var requestFile = Request.Form.Files[0];

                var ms = new MemoryStream();
                requestFile.OpenReadStream().CopyTo(ms);
                byte[] fileContent = ms.ToArray();
                var uploadFileRequest = new OrderPackageImportRequest()
                {
                    FileData = fileContent,
                    FileName = requestFile.FileName
                };

                var response = await _orderPackageAppService.ImportOrderPackage(uploadFileRequest);

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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductTypeListResponse))]
        public async Task<IActionResult> GetListProductType()
        {
            try
            {
                var response = await _orderPackageAppService.GetListProductType();

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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OrderListResponse))]
        public async Task<IActionResult> AddOrderTransport(AddListOrderTransportRequest request)
        {
            try
            {
                var response = await _orderPackageAppService.AddOrderTransport(request.OrderTransportAddRequest);

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
