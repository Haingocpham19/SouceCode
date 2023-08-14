namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class CustomerLevel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Point { get; set; }
        public int? ShippingDiscount { get; set; }
        public int? BuyDiscount { get; set; }
        public int? Order { get; set; }
    }
}
