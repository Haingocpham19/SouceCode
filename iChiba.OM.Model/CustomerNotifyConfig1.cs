﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class CustomerNotifyConfig1
    {
        public string Id { get; set; }
        /// <summary>
        /// Mã App (VD: ichiba-portal-web)
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// UserId SSO
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        public string NotifyConfigId { get; set; }
        public string NotifyConfigCode { get; set; }
        public int? NotifyGroupType { get; set; }
        public bool NotifyConfigActive { get; set; }
        public bool SendEmail { get; set; }
        public bool SendWeb { get; set; }
        public bool SendMobile { get; set; }
        public bool SendDesktop { get; set; }
    }
}