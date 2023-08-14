﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class OrderComGroup
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Cấu hình 1 COM = N% doanh thu công mua đơn ECOM
        /// </summary>
        public double? EcBuyFee { get; set; }
        /// <summary>
        /// Tổng tiền COM công mua ECOM
        /// </summary>
        public long? EcBuyFeeMoney { get; set; }
        /// <summary>
        /// Cấu hình 1 COM = N% doanh thu vận chuyển đơn ECOM
        /// </summary>
        public double? EcTranFee { get; set; }
        /// <summary>
        /// Tổng tiền COM doanh thu vận chuyển đơn ECOM
        /// </summary>
        public long? EcTranFeeMoney { get; set; }
        /// <summary>
        /// Cấu hình 1 COM = N% doanh thu đơn vận chuyển
        /// </summary>
        public double? IctFee { get; set; }
        /// <summary>
        /// Tổng tiền COM doanh thu vận chuyển đơn vận chuyển
        /// </summary>
        public long? IctFeeMoney { get; set; }
        /// <summary>
        /// Cấu hình 1 COM = N% doanh thu nhập kho đơn ECOM
        /// </summary>
        public double? EcOpImport { get; set; }
        /// <summary>
        /// Tổng tiền COM nhập kho đơn ECOM
        /// </summary>
        public long? EcOpImportMoney { get; set; }
        /// <summary>
        /// Cấu hình 1 COM = N% doanh thu xuất kho đơn ECOM
        /// </summary>
        public double? EcOpExport { get; set; }
        /// <summary>
        /// Tổng tiền COM xuất kho đơn ECOM
        /// </summary>
        public long? EcOpExportMoney { get; set; }
        /// <summary>
        /// Cấu hình 1 COM = N% doanh thu nhập kho đơn vận chuyển
        /// </summary>
        public double? IctOpImport { get; set; }
        /// <summary>
        /// Tổng tiền COM nhập kho đơn vận chuyển
        /// </summary>
        public long? IctOpImportMoney { get; set; }
        /// <summary>
        /// Cấu hình 1 COM = N% doanh thu xuất kho đơn vận chuyển
        /// </summary>
        public double? IctOpExport { get; set; }
        /// <summary>
        /// Tổng tiền COM xuất kho đơn vận chuyển
        /// </summary>
        public long? IctOpExportMoney { get; set; }
        /// <summary>
        /// Tổng tối thiểu giá trị hàng đơn ECOM  để được tính COM
        /// </summary>
        public long? EcMinimum { get; set; }
        /// <summary>
        /// Tổng tối thiểu giá trị doanh thu đơn vận chuyển  để được tính COM
        /// </summary>
        public long? IctMinimum { get; set; }
        /// <summary>
        /// Tổng tối thiểu giá trị doanh thu vận chuyển
        /// </summary>
        public long? OpMinimum { get; set; }
    }
}