using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class OrderPackageAddRequest
    {
        public string Tracking { get; set; }
        public int? Weight { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Length { get; set; }
        public List<OrderPackageProductAddRequest> PackageProducts { get; set; }
        public OrderPackageAddRequest()
        {
            PackageProducts = new List<OrderPackageProductAddRequest>();
        }
    }
}
