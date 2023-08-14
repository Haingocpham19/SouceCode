using System;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public int? RefId { get; set; }
        public string Code { get; set; }
        public string TrackingCode { get; set; }
        public int PackageDetailId { get; set; }
        public int? PackageId { get; set; }
        public int? CategoryId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string NameCustom { get; set; }
        public string NameCustomDisplay { get; set; }
        public decimal? WeightQuote { get; set; }
        public decimal? OrderWeightQuote { get; set; }
        public string Images { get; set; }
        public string PreviewImage => !string.IsNullOrEmpty(Images)
                                      ? Images.Split(";")[0]
                                      : string.Empty;
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceCustom { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TotalPrice => Price * QtyPerUnit;
        public string ManufacturerPartNumber { get; set; }
        public string UserAgreementText { get; set; }
        public decimal? Weight { get; set; }
        public decimal? WeightOrigin { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ProductUnit { get; set; }
        public int? QtyPerUnit { get; set; }
        public string CustomerNote { get; set; }
        public string AdminNote { get; set; }
        public int? Origin { get; set; }
        public string OriginName { get; set; }
        public string Url { get; set; }
        public long? PriceWeight { get; set; }
        public long? PriceQuantity { get; set; }
        public long? PriceStandard { get; set; }
        public int? DataType { get; set; }
    }
}
