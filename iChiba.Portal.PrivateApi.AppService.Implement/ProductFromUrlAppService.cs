using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;
using iChiba.Portal.PrivateApi.AppService.Interface;
using iChiba.Portal.Service.Interface;
using Ichiba.Partner.Api.Driver;
using Ichiba.Partner.Api.Driver.Request;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Implement
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

        public async Task<BaseEntityResponse<ProductDetail>> Detail(ProductDetailFromUrlRequest request)
        {
            var response = new BaseEntityResponse<ProductDetail>();

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
                if(responseData.currency != null)
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

        public async Task<BaseEntityResponse<List<ProductDetail>>> GetListDetail(ProductDetailFromUrlListRequest request)
        {
            var response = new BaseEntityResponse<List<ProductDetail>>();

            await TryCatchAsync(async () =>
            {
                var listOrder = new List<ProductDetail>();
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
