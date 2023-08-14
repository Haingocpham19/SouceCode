using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public partial class OrderPackageList
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? Weight { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Length { get; set; }
        public int? OrderId { get; set; }
        public string Image { get; set; }
        public IList<OrderPackageProductList> PackageProducts { get; set; }
        public OrderPackageList()
        {
            PackageProducts = new List<OrderPackageProductList>();
        }
    }
}
