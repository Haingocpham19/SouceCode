﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class CodImport
    {
        public int Id { get; set; }
        public string Tracking { get; set; }
        public string CustomerCode { get; set; }
        public decimal Cod { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string Supplier { get; set; }
        public DateTime? PayCodeDate { get; set; }
        public string OrderCode { get; set; }
        public string Note { get; set; }
        public string Mawb { get; set; }
        public string Warehouse { get; set; }
        public string CodeType { get; set; }
        public DateTime? ImportDate { get; set; }
        public string Currency { get; set; }
        public string DoneOrderCode { get; set; }
        public bool? Done { get; set; }
        public DateTime? DoneDate { get; set; }
    }
}