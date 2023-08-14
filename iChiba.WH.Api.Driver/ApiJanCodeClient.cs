using System.Threading.Tasks;
using Core.Resilience.Http;
using iChiba.IS4.Api.Driver;

namespace iChiba.WH.Api.Driver
{
    public class JanCodeApiConfig
    {
        public string GetByJanCode { get; set; }
    }

    public class ApiJanCodeClient : BaseClient
    {
        private readonly JanCodeApiConfig _apiConfig;

        public ApiJanCodeClient(IHttpClient httpClient,
            IAuthorizeClient authorizeClient,
            JanCodeApiConfig apiConfig)
            : base(httpClient, authorizeClient)
        {
            _apiConfig = apiConfig;
        }

        //public async Task<ProductDetailByJanCodeResponse> GetByJanCode(ProductDetailByJanCodeRequest request)
        //{
        //    var response = await PostAsync<ProductDetailByJanCodeResponse, ProductDetailByJanCodeRequest> (_apiConfig.GetByJanCode, request);

        //    return response;
        //}
    }
}
