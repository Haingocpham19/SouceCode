using Core.AppModel.Response;
using Core.Resilience.Http;
using Ichiba.Partner.Api.Driver.Request;
using Ichiba.Partner.Api.Driver.Response;
using PCS.Partner.Api.AppModel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ichiba.Partner.Api.Driver
{
    public class ProductFromUrlConfig
    {
        public string Detail { get; set; }
        public string ShipquocteTopNews { get; set; }
    }

    public class ProductFromUrlClient : BaseClient
    {
        private readonly ProductFromUrlConfig productFromUrlConfig;

        public ProductFromUrlClient(IHttpClient httpClient,
            IAuthorizeClient authorizeClient,
            ProductFromUrlConfig productFromUrlConfig)
            : base(httpClient, authorizeClient)
        {
            this.productFromUrlConfig = productFromUrlConfig;
        }

        public async Task<BaseEntityResponse<ProductDetail>> Detail(ProductDetailFromUrlRequest request)
        {
            var url = productFromUrlConfig.Detail;
            var response = await PostAsync<BaseEntityResponse<ProductDetail>, ProductDetailFromUrlRequest>(url, request);
            return response;
        }

        public async Task<BaseEntityResponse<IList<ShipquocteNews>>> TopNews(int limit)
        {
            var url = productFromUrlConfig.ShipquocteTopNews + limit;
            var response = await PostAsync<BaseEntityResponse<IList<ShipquocteNews>>, object>(url, null);
            return response;
        }
    }
}
