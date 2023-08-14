﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class ProductTypeGroup
    {
        public ProductTypeGroup()
        {
            ProductType = new HashSet<ProductType>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string TitleJa { get; set; }
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
        public int DisplayOrder { get; set; }
        public long? PriceGe { get; set; }
        public long? PriceCn { get; set; }
        public long? Oregon { get; set; }
        public long? Cali { get; set; }
        public long? Kr { get; set; }
        public long? Uk { get; set; }
        public long? De { get; set; }
        public long? Pcsjp { get; set; }
        public long? Hpc { get; set; }
        public long? Jchiba { get; set; }
        public long? Jchiba2 { get; set; }
        public long? Wkrysl { get; set; }
        public long? Wrk01 { get; set; }
        public decimal? PercentOregon { get; set; }
        public decimal? PercentCali { get; set; }
        public decimal? PercentKr { get; set; }
        public decimal? PercentUk { get; set; }
        public decimal? PercentDe { get; set; }
        public decimal? PercentPcsjp { get; set; }
        public decimal? PercentHpc { get; set; }
        public decimal? PercentJchiba { get; set; }
        public decimal? PercentJchiba2 { get; set; }
        public decimal? PercentWkrysl { get; set; }
        public decimal? PercentWrk01 { get; set; }
        public long? Rkr { get; set; }
        public decimal? PercentWrkr { get; set; }

        public virtual ICollection<ProductType> ProductType { get; set; }
    }
}