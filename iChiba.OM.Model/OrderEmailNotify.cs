﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class OrderEmailNotify
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public int OrderStatus { get; set; }
        public string OrderStatusText { get; set; }
        public int? TrackingStatus { get; set; }
        public string TrackingStatusText { get; set; }
        public int? OrderStatusOld { get; set; }
        public int? TrackingStatusOld { get; set; }
        public int Sended { get; set; }
        public DateTime? SendDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Receiver { get; set; }
        public string ReceiverName { get; set; }
        public string AccountId { get; set; }
    }
}