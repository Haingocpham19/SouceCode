namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class ShippingRoute_Warehouse
    {
        public int Id { get; set; }
        public int ShippingRouteId { get; set; }
        public int WarehouseId { get; set; }
        public string ShippingRouteCode { get; set; }
        public string WarehouseCode { get; set; }
        public bool Active { get; set; }
        public int DisplayOrder { get; set; }

        public ShippingRoute ShippingRoute { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
