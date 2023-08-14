namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public partial class OrderServiceMapping
    {
        public int OrderId { get; set; }
        public int OrderServiceId { get; set; }
        public long? Price { get; set; }
        public int? Status { get; set; }
        public long? PricePayment { get; set; }
        public virtual OrderService OrderService { get; set; }
    }
}
