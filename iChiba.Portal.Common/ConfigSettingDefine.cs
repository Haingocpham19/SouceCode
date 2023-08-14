using System.ComponentModel.DataAnnotations;

namespace iChiba.Portal.Common
{
    public enum ConfigSettingDefine
    {
        [Display(Name = "ConnectionStrings:iChibaPortalCmsConnectionString")]
        iChibaPortalCmsConnectionString,
        [Display(Name = "ConnectionStrings:DbiChibaShoppingCmsConnectionString")]
        DbiChibaShoppingCmsConnectionString,
        [Display(Name = "ConnectionStrings:DbiChibaCustomerConnectionString")]
        DbiChibaCustomerConnectionString,
        [Display(Name = "ConnectionStrings:DbWarehouseConnectionString")]
        DbWarehouseConnectionString,
        [Display(Name = "ConnectionStrings:DbDataCommonConnectionString")]
        DbDataCommonConnectionString,
        [Display(Name = "ConnectionStrings:DbiChibaCustomerConnectionString")]
        DbiChibaAccConnectionString,
        [Display(Name = "FileStorage:CdnDomain")]
        CdnDomain
    }
}
