﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class OrderPurchase
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public DateTime? ActionDate { get; set; }
        public string ActionBy { get; set; }
        public string AccountId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductLink { get; set; }
        public string ProductImage { get; set; }
        public int? ExchangeRate { get; set; }
        public long? Price { get; set; }
        public long? Tax { get; set; }
        public long? ShippingFee { get; set; }
        public long? Surcharge { get; set; }
        public string SurchargeNote { get; set; }
        public string Type { get; set; }
        public int? SyncAccStatus { get; set; }
        public DateTime? SyncAccDate { get; set; }
        public string SyncAccNo { get; set; }
        public string AccDebit { get; set; }
        public string AccCredited { get; set; }
        public string ObjectTypeDebit { get; set; }
        public string ObjectCodeDebit { get; set; }
        public string ObjectTypeCredited { get; set; }
        public string ObjectCodeCredited { get; set; }
        public int? LogId { get; set; }
        public string Temp { get; set; }
        public bool? Fix { get; set; }
        public DateTime? CreatedBy { get; set; }
    }
}