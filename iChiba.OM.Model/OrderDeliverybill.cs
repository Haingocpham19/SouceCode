﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class OrderDeliverybill
    {
        public int Id { get; set; }
        public string BillCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
        public string AccountId { get; set; }
        public DateTime? BillDate { get; set; }
        public string BillType { get; set; }
    }
}