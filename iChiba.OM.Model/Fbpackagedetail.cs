﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class Fbpackagedetail
    {
        public Fbpackagedetail()
        {
            Fbproduct = new HashSet<Fbproduct>();
        }

        public int Id { get; set; }
        public int? RefId { get; set; }
        public int? RefOrderId { get; set; }
        public int? PackageId { get; set; }
        public int? WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public string OrderCode { get; set; }
        public int? PackageDetailQuoteId { get; set; }
        public string DeliveryBillCode { get; set; }
        public string ImageBalanceScale { get; set; }
        public string OrderType { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Title { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalAdditional { get; set; }
        public int? BuyFee { get; set; }
        public decimal? ShippingUnitGlobal { get; set; }
        public decimal? ShippingFee { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Surcharge { get; set; }
        public string SurchargeNote { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public string CustomerId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal? CurrencyRate { get; set; }
        /// <summary>
        /// Người đặt hàng
        /// </summary>
        public string CustomerDistrict { get; set; }
        /// <summary>
        /// Địa chỉ nhận hàng
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// Số phone nhận hàng
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// Tên người nhận hàng
        /// </summary>
        public string CustomerName { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerWard { get; set; }
        public string History { get; set; }
        public string EmployeeHandling { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string Region { get; set; }
        public int? BinLocationId { get; set; }
        public string OrderStatus { get; set; }
        public int? Status { get; set; }
        public string ShippingRouteCode { get; set; }
        public int? ShippingRouteId { get; set; }

        public virtual Fbpackage Package { get; set; }
        public virtual ICollection<Fbproduct> Fbproduct { get; set; }
    }
}