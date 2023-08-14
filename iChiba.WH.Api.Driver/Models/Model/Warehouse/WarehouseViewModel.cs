using System;

namespace Ichiba.WH.Api.Driver.Model.Warehouse
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int VendorId { get; set; }
        public short Type { get; set; }
        public string Holidays { get; set; }
        public string WorkingTimes { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Status { get; set; }
        public int? TransportStatus { get; set; }
        public string Region { get; set; }
        public string Yacode { get; set; }
        public int? Order { get; set; }
        public int? Province { get; set; }
        public int? District { get; set; }
        public int? Wards { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string WardsName { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string LastCode { get; set; }
        public string Currency { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Terms { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ShipName { get; set; }
    }
}
