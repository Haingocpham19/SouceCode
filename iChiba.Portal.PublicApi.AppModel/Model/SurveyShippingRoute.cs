namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public partial class SurveyShippingRoute
    {
        public string Id { get; set; }

        public int CustomerId { get; set; }

        public string UserId { get; set; }

        public int ShippingRouteId { get; set; }

        public string ShippingRouteCode { get; set; }

        public bool Active { get; set; }

        public int DisplayOrder { get; set; }

        public Customer Customer { get; set; }

        public ShippingRoute ShippingRoute { get; set; }
    }
}
