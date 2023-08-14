﻿using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class OrderPackageProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCustom { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public long? Price { get; set; }
        public long? PriceCustom { get; set; }
        public int PackageId { get; set; }
        public int? Weight { get; set; }
        public int? WeightOrigin { get; set; }
        public long? PriceWeight { get; set; }
        public long? PriceQuantity { get; set; }
        public long? PriceStandard { get; set; }
        public int? DataType { get; set; }
    }
}
