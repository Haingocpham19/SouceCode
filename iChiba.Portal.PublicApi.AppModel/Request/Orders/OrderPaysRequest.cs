using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderPaysRequest
    {
        public IList<int> OrderIds { get; set; }
        public int MinPayment { get; set; }
        public string PaymentForm { get; set; }
        public int? OrderPaymentType { get; set; }
        public string OrderPaymentBankNumber { get; set; }
    }
}
