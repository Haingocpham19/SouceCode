using iChiba.Portal.ExtensionApi.AppModel.Request;
using iChiba.Portal.ExtensionApi.AppModel.Response;
using iChiba.Portal.ExtensionApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.ExtensionApi.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(
            ILogger<AccessController> logger,
            IShoppingCartService shoppingCartService
            ) : base(logger)
        {
            _shoppingCartService = shoppingCartService;
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShoppingCarResponse))]
        public async Task<IActionResult> AddListToCart(ShoppingCartRequest request)
        {
            try
            {
                var response = await _shoppingCartService.AddToCart(request);

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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShoppingCartListItemResponse))]
        public async Task<IActionResult> AddItemToCart(ShoppingCartItemRequest request)
        {
            try
            {
                var response = await _shoppingCartService.AddItemToCart(request);

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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShoppingCarResponse))]
        public async Task<IActionResult> DeleteListIteamCard(ShoppingListIdRequest request)
        {
            try
            {
                var response = await _shoppingCartService.DeleteListItemCart(request);

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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShoppingCarResponse))]
        public async Task<IActionResult> DeleteIteamCard(ShoppingItemIdRequest request)
        {
            try
            {
                var response = await _shoppingCartService.DeleteItemCart(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShoppingCartListItemResponse))]
        public async Task<IActionResult> GetListItemShoppingCart()
        {
            try
            {
                var response = await _shoppingCartService.GetListShoppingCart();

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
