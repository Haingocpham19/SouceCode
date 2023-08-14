using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class ProductFromUrlController : BaseController
    {
        private readonly IProductFromUrlAppService productFromUrlAppService;
        private readonly IMemoryCache memoryCache;
        public ProductFromUrlController(ILogger<ProductFromUrlController> logger, IMemoryCache memoryCache,
            IProductFromUrlAppService productFromUrlAppService)
            : base(logger)
        {
            this.productFromUrlAppService = productFromUrlAppService;
            this.memoryCache = memoryCache;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<ProductDetail>))]
        public async Task<IActionResult> Detail(ProductDetailFromUrlRequest request)
        {
            var cacheKey = $"ProductFromUrl_{request.Url}";
            var objectInMemory = memoryCache.Get<BaseEntityResponse<ProductDetail>>(cacheKey);
            if (objectInMemory?.Data != null)
                return Ok(objectInMemory);
            var response = await productFromUrlAppService.Detail(request);
            if (response?.Data != null)
                memoryCache.Set(
                    cacheKey, 
                    response, 
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(2)));
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<ShipquocteNews>>))]
        public async Task<IActionResult> TopNews(int limit)
        {
            var cacheKey = $"Shipquocte_news_top_{limit}";
            var objectInMemory = memoryCache.Get<BaseEntityResponse<IList<ShipquocteNews>>>(cacheKey);
            if (objectInMemory?.Data != null)
                return Ok(objectInMemory);
            var response = await productFromUrlAppService.TopNews(limit);
            if (response?.Data != null)
                memoryCache.Set(
                    cacheKey,
                    response,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
            return Ok(response);
        }
    }
}
