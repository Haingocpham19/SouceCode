using System;

namespace Ichiba.WH.Api.Driver.Model.Warehouse
{
    public class WarehouseList
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string YACode { get; set; }
        public int? Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string CustomerName { get; set; }
        public bool CustomerWareActive { get; set; }
        public string ShipName { get; set; }
        public string Region { get; set; }
    }
}
