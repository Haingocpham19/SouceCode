using Core.AppModel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderServiceMappingUpdateRequest
    {
        public int OrderId { get; set; }
        public int OrderServiceId { get; set; }
        public long? PricePayment { get; set; }
        public string PricePaymentBy { get; set; }
        public long? Price { get; set; }
        public int? Status { get; set; }
        public string Currency { get; set; }
        public long? Exchange { get; set; }
    }
}
