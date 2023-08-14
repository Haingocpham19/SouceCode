using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderPackageAddRequest
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? Weight { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Length { get; set; }
        public int? OrderId { get; set; }
        public string Image { get; set; }
        public IList<OrderPackageProductAddRequest> PackageProducts { get; set; }
        public OrderPackageAddRequest()
        {
            PackageProducts = new List<OrderPackageProductAddRequest>();
        }
    }
}
