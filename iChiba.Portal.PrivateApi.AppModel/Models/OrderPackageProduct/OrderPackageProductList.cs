using System;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public partial class OrderPackageProductList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCustom { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public long? Price { get; set; }
        public long? PriceCustom { get; set; }
        public int? Weight { get; set; }
        public int PackageId { get; set; }
        public long? PriceWeight { get; set; }
        public string ProductType { get; set; }
        public long? priceStandard { get; set; }
        public long PriceStandardConvert => GetValueOrDefault(priceStandard);
        public long TotalPriceStandard => PriceStandardConvert * Qty;
        public int? DataType { get; set; }
        private TValue GetValueOrDefault<TValue>(TValue? value, TValue defaultValue = default) where TValue : struct
        {
            var _value = value.HasValue ? value.Value : defaultValue;

            return _value;
        }
    }
}
