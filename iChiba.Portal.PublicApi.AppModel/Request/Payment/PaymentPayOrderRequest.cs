namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class PaymentPayOrderRequest
    {
        public string OrderId { get; set; }
        public long Amount { get; set; }
    }
}
