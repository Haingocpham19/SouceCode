﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace iChiba.DC.Model
{
    public partial class Localeresources
    {
        public int Id { get; set; }
        public string LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual Languages Language { get; set; }
    }
}