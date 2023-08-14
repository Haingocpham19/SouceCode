﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class Payment
    {
        public Payment()
        {
            PaymentMessage = new HashSet<PaymentMessage>();
        }

        public int Id { get; set; }
        /// <summary>
        /// Ví tiền
        /// </summary>
        public string WalletId { get; set; }
        public string AccountId { get; set; }
        public long Amount { get; set; }
        public string RefCode { get; set; }
        public string Ref { get; set; }
        /// <summary>
        /// ORDER
        /// </summary>
        public string RefType { get; set; }
        /// <summary>
        /// PAY_ORDER | CANCEL_ORDER
        /// </summary>
        public string PaymentType { get; set; }
        /// <summary>
        /// Hình thức thanh toán  WALLET, ATM, BANKING, CASH
        /// </summary>
        public string PaymentForm { get; set; }
        /// <summary>
        /// 0. Chờ xử lý  1. Đã thanh toán  2. Huỷ thanh toán 3.Duyệt thanh toán
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Ghi chú thay đổi trạng thái
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Mô tả (hệ thống tạo)
        /// </summary>
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ProcessDate { get; set; }
        public byte[] Version { get; set; }
        public string Hash { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ApproveBy { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public bool? Refund { get; set; }
        public bool? Priority { get; set; }
        public bool? SystemPriority { get; set; }
        public int? PayCount { get; set; }

        public virtual Wallet Wallet { get; set; }
        public virtual ICollection<PaymentMessage> PaymentMessage { get; set; }
    }
}