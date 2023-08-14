using Core.AppModel.Response;
using iChiba.Portal.ExtensionApi.AppModel.Model.ProductDetail;
using iChiba.Portal.ExtensionApi.AppService.Implement.Adapter.ProductDetailFrom;
using iChiba.Portal.ExtensionApi.AppService.Interface.ProductFromUrlAppService;
using iChiba.Portal.Service.Interface;
using Ichiba.Partner.Api.Driver;
using Ichiba.Partner.Api.Driver.Request;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.ExtensionApi.AppService.Implement
{
    public class ProductFromUrlAppService : BaseAppService, IProductFromUrlAppService
    {
        private readonly ProductFromUrlClient productFromUrlClient;
        private readonly IExchangeratesService _exchangeratesService;

        public ProductFromUrlAppService(ILogger<ProductFromUrlAppService> logger,
            ProductFromUrlClient productFromUrlClient,
            IExchangeratesService exchangeratesService)
            : base(logger)
        {
            this.productFromUrlClient = productFromUrlClient;
            _exchangeratesService = exchangeratesService;
        }

        public async Task<BaseEntityResponse<ProductDetailViewModel>> Detail(ProductDetailFromUrlRequest request)
        {
            var response = new BaseEntityResponse<ProductDetailViewModel>();

            await TryCatchAsync(async () =>
            {
                var _request = new ProductDetailFromUrlRequest()
                {
                    Url = request.Url
                };
                var _response = await productFromUrlClient.Detail(_request);

                if (_response == null || !_response.Status)
                {
                    return response;
                }

                var responseData = _response.Data.ToModel();
                if (responseData.currency != null)
                {
                    var exchangerates = _exchangeratesService.GetRateByCode(responseData.currency);
                    if (exchangerates != null)
                    {
                        responseData.Exchangerate = decimal.ToInt32(exchangerates.Result);
                    }
                }

                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<List<ProductDetailViewModel>>> GetListDetail(ProductDetailFromUrlListRequest request)
        {
            var response = new BaseEntityResponse<List<ProductDetailViewModel>>();

            await TryCatchAsync(async () =>
            {
                var listOrder = new List<ProductDetailViewModel>();
                foreach (var item in request.Url)
                {
                    var _request = new ProductDetailFromUrlRequest()
                    {
                        Url = item
                    };
                    var _response = await productFromUrlClient.Detail(_request);

                    if (_response == null || !_response.Status)
                    {
                        continue;
                    }

                    var responseData = _response.Data.ToModel();
                    listOrder.Add(responseData);
                }

                response.SetData(listOrder)
                    .Successful();

                return response;
            }, response);

            return response;
        }
    }
}
