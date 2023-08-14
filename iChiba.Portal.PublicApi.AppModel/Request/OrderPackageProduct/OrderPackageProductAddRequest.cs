namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderPackageProductAddRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCustom { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public long? Price { get; set; }
        public long? PriceCustom { get; set; }
        public int PackageId { get; set; }
    }
}
