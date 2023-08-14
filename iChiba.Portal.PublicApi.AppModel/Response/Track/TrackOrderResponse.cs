using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;

namespace iChiba.Portal.PublicApi.AppModel.Response
{
    public class TrackOrderResponse
    {
        public string OrderType { get; set; }

        public OrderTransport TransportOrder { get; set; }

        public Order EComOrder { get; set; }

        public Customer Customer { get; set; }

        public Warehouse FromWarehouse { get; set; }

        public Warehouse ToWarehouse { get; set; }

        public IList<ShippingRoute> ShippingRoutes { get; set; }

        public IList<ProductTypeList> ProductTypes { get; set; }

        public IList<OrderService> OrderServices { get; set; }

        public IList<Ddimport> DDImports { get; set; }

        public IList<PackageTrackingList> PackageTrackings { get; set; }

        public TrackOrderResponse()
        {
            ShippingRoutes = new List<ShippingRoute>();
            ProductTypes = new List<ProductTypeList>();
            OrderServices = new List<OrderService>();
            DDImports = new List<Ddimport>();
            PackageTrackings = new List<PackageTrackingList>();
        }
    }
}
