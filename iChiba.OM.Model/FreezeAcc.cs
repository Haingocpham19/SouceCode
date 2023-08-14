﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class FreezeAcc
    {
        public int Id { get; set; }
        public string ObjectId { get; set; }
        public string ObjectCode { get; set; }
        public string WalletId { get; set; }
        public long Amount { get; set; }
        /// <summary>
        /// BID_VIP,BID,PAY
        /// </summary>
        public string Type { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 1: đang tạm giữ, 0 huỷ tạm giữ
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// AUC_PRODUCT
        /// </summary>
        public string RefType { get; set; }
        public int? Ref { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AccDebit { get; set; }
        public string AccCredited { get; set; }
        public int? SyncAccStatus { get; set; }
        public DateTime? SyncAccDate { get; set; }
        public string SyncAccNo { get; set; }
    }
}