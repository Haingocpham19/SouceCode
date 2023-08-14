using Core.AppModel.Response;
using iChiba.Portal.Common;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System;
using System.Collections.Generic;

namespace Ichiba.WH.Api.Driver.Response
{
    public class ReviewOrderPriceQuotesResponse : BaseResponse
    {
        public IList<OrderPriceQuotesViewModel> Data { get; set; }
        public EnumDefine.ShippingType ShippingType { get; set; }
        public decimal? ShippingFee { get; set; }
        public EnumDefine.ExportTransportType ExportTransportType { get; set; }
        public EnumDefine.PackageDetailQuotesType PackageDetailQuotesType { get; set; }
        public EnumDefine.ShippingUnitType ShippingUnitType { get; set; }
        public DateTime? DataArrival { get; set; }
        public string CreatedWarehouseCode { get; set; }
        public string PoNumber { get; set; }
        public string Note { get; set; }
        public List<NotExploitPackageDetailViewModel> NotExploitedPackageDetail { get; set; }
    }


}
