﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.WH.Model
{
    public partial class PcsShippingState
    {
        public int Id { get; set; }
        public int? PackageDetailQuoteId { get; set; }
        public string Status { get; set; }
        public string StatusName { get; set; }
        public string PoNumber { get; set; }
        public string WebhookKey { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}