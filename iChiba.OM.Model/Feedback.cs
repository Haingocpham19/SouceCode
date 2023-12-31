﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class Feedback
    {
        public Feedback()
        {
            Fbcomment = new HashSet<Fbcomment>();
            Fbhistory = new HashSet<Fbhistory>();
        }

        public int Id { get; set; }
        public int? FbType { get; set; }
        public string Reason { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Tracking { get; set; }
        public string OrderCode { get; set; }
        public string Images { get; set; }
        public string Note { get; set; }
        public string WarehouseCode { get; set; }
        public string Owner { get; set; }
        public string Supporter { get; set; }
        public string FlightCode { get; set; }
        public string ContainerName { get; set; }
        public string TrackingNote { get; set; }
        public string ShippingRouteCode { get; set; }
        public decimal? Weight { get; set; }

        public virtual ICollection<Fbcomment> Fbcomment { get; set; }
        public virtual ICollection<Fbhistory> Fbhistory { get; set; }
    }
}