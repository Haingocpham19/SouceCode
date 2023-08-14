﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace iChiba.DC.Model
{
    public partial class ProductTypeGroup
    {
        public ProductTypeGroup()
        {
            ProductType = new HashSet<ProductType>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long? PriceWeight { get; set; }
        public long? PriceQuantity { get; set; }
        public long? PriceStandard { get; set; }
        public string Note { get; set; }
        public string Code { get; set; }
        public long? PriceJp { get; set; }
        public long? PriceUs { get; set; }
        public long? PriceKr { get; set; }
        public long? PriceAu { get; set; }

        public virtual ICollection<ProductType> ProductType { get; set; }
    }
}