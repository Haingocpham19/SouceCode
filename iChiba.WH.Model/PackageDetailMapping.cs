﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.WH.Model
{
    public partial class PackageDetailMapping
    {
        public int PackageId { get; set; }
        public int PackageDetailId { get; set; }

        public virtual Package Package { get; set; }
        public virtual PackageDetail PackageDetail { get; set; }
    }
}