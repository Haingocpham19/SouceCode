using Core.AppModel.Response;
using Ichiba.Partner.Api.Driver;
using iChibaShopping.Core.AppService.Implement;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class ProductFromUrlAppService : BaseAppService, IProductFromUrlAppService
    {
        private readonly ProductFromUrlClient productFromUrlClient;

        public ProductFromUrlAppService(ILogger<ProductFromUrlAppService> logger,
            ProductFromUrlClient productFromUrlClient)
            : base(logger)
        {
            this.productFromUrlClient = productFromUrlClient;
        }

        public async Task<BaseEntityResponse<ProductDetail>> Detail(ProductDetailFromUrlRequest request)
        {
            var response = new BaseEntityResponse<ProductDetail>();

            await TryCatchAsync(async () =>
            {
                var _request = new Ichiba.Partner.Api.Driver.Request.ProductDetailFromUrlRequest()
                {
                    Url = request.Url
                };
                var _response = await productFromUrlClient.Detail(_request);

                if (_response == null || !_response.Status)
                {
                    return response;
                }

                var responseData = _response.Data.ToModel();

                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<ShipquocteNews>>> TopNews(int limit)
        {
            var response = new BaseEntityResponse<IList<ShipquocteNews>>();

            await TryCatchAsync(async () =>
            {
                var _response = await productFromUrlClient.TopNews(limit);

                if (_response == null || !_response.Status)
                {
                    return response;
                }

                var responseData = _response.Data.ToModel();

                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;
        }

    }
}
