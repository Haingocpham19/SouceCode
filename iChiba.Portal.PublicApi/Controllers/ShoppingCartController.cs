using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartAppService shoppingCartAppService;

        public ShoppingCartController(ILogger<ShoppingCartController> logger,
            IShoppingCartAppService shoppingCartAppService)
            : base(logger)
        {
            this.shoppingCartAppService = shoppingCartAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<ShoppingCart>))]
        public async Task<IActionResult> GetCurrent(ShoppingCartGetCurrentRequest request)
        {
            var response = await shoppingCartAppService.GetCurrent(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<string>))]
        public async Task<IActionResult> Add(ShoppingCartAddRequest request)
        {
            var response = await shoppingCartAppService.Add(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> AddTemp(ShoppingCartAddTempRequest request)
        {
            var response = await shoppingCartAppService.AddTemp(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> AddTemps(ShoppingCartAddTempMultiItemRequest request)
        {
            var response = await shoppingCartAppService.AddTemps(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Remove(ShoppingCartRemoveItemRequest request)
        {
            var response = await shoppingCartAppService.Remove(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Removes(ShoppingCartRemovesItemRequest request)
        {
            var response = await shoppingCartAppService.Removes(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Merge(ShoppingCartMergeRequest request)
        {
            var response = await shoppingCartAppService.Merge(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<ShoppingCart>))]
        public async Task<IActionResult> OrderConfirm(ShoppingCartOrderConfirmRequest request)
        {
            var response = await shoppingCartAppService.OrderConfirm(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<ShoppingCart>))]
        public async Task<IActionResult> OrderConfirmByListProductId(ShoppingCartOrderConfirmRequest request)
        {
            var response = await shoppingCartAppService.OrderConfirmByListProductId(request.ProductIds);

            return Ok(response);
        }
    }
}