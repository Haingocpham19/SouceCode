using System.ComponentModel.DataAnnotations;

namespace iChiba.Portal.ExtensionApi.Configs
{
    public enum ConfigSettingDefine
    {
        [Display(Name = "ConnectionStrings:DbWarehouseConnectionString")]
        DbWarehouseConnectionString,

        [Display(Name = "ConnectionStrings:DbiChibaCustomerConnectionString")]
        DbiChibaCustomerConnectionString
    }
}
