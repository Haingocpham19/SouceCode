using iChiba.WH.Model;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class PackageDetailViewModel
    {
        public int Id { get; set; }
        public int? RefId { get; set; }
        public int RefOrderId { get; set; }
        public int? PackageId { get; set; }
        public int? WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public string OrderCode { get; set; }
        public string Images { get; set; }
        public string PreviewImage => !string.IsNullOrEmpty(Images)
                                      ? Images.Split(";")[0]
                                      : string.Empty;
        public string name { get; set; }
        public string url { get; set; }
        public string OrderType { get; set; }
        public string DeliveryBillCode { get; set; }
        public decimal? WeightQuote { get; set; }
        public bool? DeliveryPayType { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? ShippingFeeDomestic { get; set; }
        public long? BuyServiceFee { get; set; }
        public string OrderDateDisplay => OrderDate == null ? string.Empty : OrderDate.Value.ToLocalTime().ToString("dd/MM/yyyy HH:mm");
        public string Title { get; set; }
        public string Note { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalDisplay => ConvertTotal();
        public decimal? TotalAmount { get; set; }
        public decimal TotalShippingFree { get; set; }
        public decimal? TotalAdditional { get; set; }
        public int? BuyFee { get; set; }
        public decimal? ShippingUnitGlobal { get; set; }
        public decimal? ShippingFee { get; set; }
        public decimal? ShippingFeeDisplay => ConvertShippingFee();
        public decimal? Paid { get; set; }
        public decimal? Surcharge { get; set; }
        public decimal? SurchargeDisplay => ConvertSurcharge();
        public decimal? SurchargeVND { get; set; }
        public long? SurchargeByFee { get; set; }
        public string SurchargeNote { get; set; }
        public decimal? TotalPriceStandard { get; set; }
        public decimal? Weight { get; set; }
        public decimal? WeightOrigin { get; set; }
        public decimal? WeightWarehouse { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public string CustomerId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal? CurrencyRate { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerWard { get; set; }
        public int? BinLocationId { get; set; }
        public string Region { get; set; }
        public string ImageBalanceScale { get; set; }
        public string History { get; set; }
        public int? Status { get; set; }
        public string TrackingCode { get; set; }
        public string TrackingNote { get; set; }
        public int? QtyPerUnit { get; set; }
        public string NameBinLocation { get; set; }
        public long? DeliveryFee { get; set; }
        public bool PaymentStatus { get; set; }
        public int? ExchangeRate { get; set; }
        public long? TotalServiceFee { get; set; }
        public string FullAddress => $"{CustomerAddress}, {CustomerWard}, {CustomerDistrict}, {CustomerProvince}";
        public bool Crate { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<PackageViewModel> Packages { get; set; }
        public List<BinLocationViewModel> BinLocations { get; set; }
        public List<ServiceChargePackageViewModel> ServiceChargePackages { get; set; }
        public List<OrderServiceMappingViewModel> OrderServiceMappings { get; set; }
        public FlightViewModel Flight { get; set; }
        #region DataOM
        public string SurchargePay { get; set; }
        public string SurchargeBy { get; set; }
        public long? TotalPayment { get; set; }
        #endregion

        public bool? Bulky { get; set; }
        public decimal? WeightQuoteDisplay { get; set; }
        public decimal? WeightDisplay { get; set; }
        public decimal? WeightDim { get; set; }

        private decimal? ConvertShippingFee()
        {

            return ShippingFee;
        }

        private decimal? ConvertSurcharge()
        {
            return Surcharge;
        }
        private decimal? ConvertTotal()
        {
            return Total;
        }
    }
}
