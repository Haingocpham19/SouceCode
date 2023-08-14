using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string YACode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? TransportStatus { get; set; }
        public string PostalCode { get; set; }
        public string Currency { get; set; }
        public string Terms { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ShipName { get; set; }

        public IList<ShippingRoute_Warehouse> ShippingRoute_Warehouses { get; set; }

        public Warehouse()
        {
            ShippingRoute_Warehouses = new List<ShippingRoute_Warehouse>();
        }
    }
}
