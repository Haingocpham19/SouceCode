﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class OrderServiceMapping
    {
        public int OrderId { get; set; }
        public int OrderServiceId { get; set; }
        public long? Price { get; set; }
        public int? Status { get; set; }
        public long? PricePayment { get; set; }
        public string PricePaymentBy { get; set; }
        public string Currency { get; set; }
        public long? Exchange { get; set; }

        public virtual Order Order { get; set; }
        public virtual OrderService OrderService { get; set; }
    }
}