﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace iChiba.DC.Model
{
    public partial class Localizedproperties
    {
        public int Id { get; set; }
        public string LanguageId { get; set; }
        public int? EntityId { get; set; }
        public string LocaleKey { get; set; }
        public string LocaleGroup { get; set; }
        public string LocaleValue { get; set; }

        public virtual Languages Language { get; set; }
    }
}