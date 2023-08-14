using Core.AppModel.Response;
using iChiba.Portal.Common;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class ReviewOrderPriceQuotesViewModelResponse : BaseResponse
    {
        public IList<OrderPriceQuotesViewModel> Data { get; set; }
        public EnumDefine.ShippingType ShippingType { get; set; }
        public decimal? ShippingFee { get; set; }
        public EnumDefine.ExportTransportType ExportTransportType { get; set; }
        public EnumDefine.PackageDetailQuotesType PackageDetailQuotesType { get; set; }
        public EnumDefine.ShippingUnitType ShippingUnitType { get; set; }
        public string PoNumber { get; set; }
        public string Note { get; set; }
        public List<NotExploitPackageDetailViewModel> NotExploitedPackageDetail { get; set; }
    }

    public class ReviewOrderPriceQuotesVCViewModelResponse
    {
        public List<ReviewOrderPriceQoutesModelResponse> Data { get; set; } = new List<ReviewOrderPriceQoutesModelResponse>();
        public List<NotExploitPackageDetailViewModel> NotExploitedPackageDetail { get; set; }
    }

    public class ReviewOrderPriceQoutesModelResponse
    {
        public string barCode { get; set; }
        public string tracking { get; set; }
        public string TrackingNote { get; set; }
        public decimal? weightQuote { get; set; }
        public long? TotalServiceFee { get; set; }
        public decimal? surcharge { get; set; }
        public decimal? currencyRate { get; set; }
        public long? deliveryFee { get; set; }
        public long? buyFee { get; set; }
        public decimal pwidth { get; set; }
        public decimal plength { get; set; }
        public decimal pheight { get; set; }
        public decimal? AmountVND { get; set; }
        public int? TotalProductDetails { get; set; }
        public List<productDetails> productDetails { get; set; }
        public string Note { get; set; }
        public ReviewOrderPriceQoutesModelResponse()
        {
            productDetails = new List<productDetails>();
        }
    }

    public class productDetails
    {
        public string nameCustomDisplay { get; set; }
        public int? amount { get; set; }
        public decimal? weight { get; set; }
        public decimal? OrderWeightQuote { get; set; }
        public long? priceWeight { get; set; }
        public decimal? TotalOrderWeightQuote => OrderWeightQuote * priceWeight;
        public long? priceStandard { get; set; }
    }
}
