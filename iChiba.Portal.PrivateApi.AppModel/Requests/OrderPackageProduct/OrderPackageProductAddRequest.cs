namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class OrderPackageProductAddRequest
    {
        public string Name { get; set; }
        public string NameCustom { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public long? Price { get; set; }
        public long? PriceWeight { get; set; }
        public long? Weight { get; set; }
        public long? PriceStandard { get; set; }
    }
}
