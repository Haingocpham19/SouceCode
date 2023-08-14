namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class OrderServiceMappingViewModel
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public int OrderServiceId { get; set; }
        public long? PricePayment { get; set; }
    }
}
