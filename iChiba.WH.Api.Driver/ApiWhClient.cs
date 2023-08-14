using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AppModel.Response;
using Core.Resilience.Http;
using iChiba.IS4.Api.Driver;
using iChiba.WH.Api.Driver;
using Ichiba.WH.Api.Driver.Request;
using Ichiba.WH.Api.Driver.Response;
//using iChiba.Portal.PrivateApi.AppModel.Responses;
namespace iChiba.WH.Api.Driver
{
    public class WhApiConfig
    {
        public string ReviewOrderPriceQuotes { get; set; }
        public string SearchOrderPriceQuotes { get; set; }
    }

    public class ApiWhClient : WH.Api.Driver.BaseClient
    {
        private readonly WhApiConfig _whApiConfig;

        public ApiWhClient(IHttpClient httpClient,
            IAuthorizeClient authorizeClient,
            WhApiConfig whApiConfig)
            : base(httpClient, authorizeClient)
        {
            _whApiConfig = whApiConfig;
        }

        public async Task<OrderPriceQuotesDeliveryBillCodeListResponse> SearchOrderPriceQuotes(WareHouseFormClientRequest request)
        {
            var url = _whApiConfig.SearchOrderPriceQuotes;
            var response = await PostAsync<OrderPriceQuotesDeliveryBillCodeListResponse, WareHouseFormClientRequest>(url, request);
            return response;
        }

        public async Task<ReviewOrderPriceQuotesResponse> ReviewOrderPriceQuotes(WareHouseClientExportRequest request)
        {
            var url = _whApiConfig.ReviewOrderPriceQuotes;
            var response = await PostAsync<ReviewOrderPriceQuotesResponse, WareHouseClientExportRequest>(url, request);
            return response;
        }

    }
}
