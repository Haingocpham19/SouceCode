﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.WH.Model
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public string JanCode { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Ingredients { get; set; }
        public string IngredientTranslate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CategoryId { get; set; }
    }
}