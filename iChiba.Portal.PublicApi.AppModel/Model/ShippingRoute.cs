using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public partial class ShippingRoute
    {
        public ShippingRoute()
        {
            ShippingRoute_Warehouses = new List<ShippingRoute_Warehouse>();
            Warehouses = new List<Warehouse>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FromCountryId { get; set; }
        public int ToCountryId { get; set; }
        public bool Active { get; set; }
        public int DisplayOrder { get; set; }

        public IList<ShippingRoute_Warehouse> ShippingRoute_Warehouses { get; set; }
        public IList<Warehouse> Warehouses { get; set; }
    }
}
