using Core.Common;
using iChiba.Portal.Common;
using System;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class ServiceChargeViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameJp { get; set; }
        public string NameEn { get; set; }
        public string Description { get; set; }
        public string DescriptionJp { get; set; }
        public string DescriptionEn { get; set; }
        public string Unit { get; set; }
        public string UnitEn { get; set; }
        public string UnitJp { get; set; }
        public decimal Price { get; set; }
        public decimal? SuggestPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public EnumDefine.CommonStatus Status { get; set; }
        public string StatusName => Status.GetDisplayName();
    }
    
    public class ServiceChargeModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public EnumDefine.CommonStatus Status { get; set; }
        public string StatusName => Status.GetDisplayName();
    }
}
