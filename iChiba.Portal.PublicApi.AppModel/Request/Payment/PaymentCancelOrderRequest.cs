using Core.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class PaymentCancelOrderRequest
    {
        public string OrderId { get; set; }
    }
    public class PaymentListByRefRequest
    {
        public string Ref { get; set; }
    }

    public class PaymentListByAccountRequest : SortRequest
    {
        public bool? Refund { get; set; }
        public int? Status { get; set; }
    }

    public class PaymentListByPaymentTypeRequest : SortRequest
    {
        public string PaymentType { get; set; }
    }
}
