﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.WH.Model
{
    public partial class VtpShippingState
    {
        public int Id { get; set; }
        public int PackageDetailQuoteId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderReference { get; set; }
        public DateTime OrderStatusDate { get; set; }
        public int OrderStatus { get; set; }
        public string StatusName { get; set; }
        public string LocationCurrently { get; set; }
        public string Note { get; set; }
        public decimal MoneyCollection { get; set; }
        public decimal MoneyFeeCod { get; set; }
        public decimal MoneyTotal { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string CreatedUid { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }
        public string UpdatedUid { get; set; }

        public virtual Shipment PackageDetailQuote { get; set; }
    }
}