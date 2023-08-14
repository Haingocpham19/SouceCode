using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class MemberShipLevel
    {
        public string AccountId { get; set; }
        public string aucFeecancel { get; set; }
        public string aucMaxbidlink { get; set; }
        public string feebuy { get; set; }
        public string feebuy_mer { get; set; }
        public string feebuy_auc { get; set; }
        public string feetran { get; set; }
        public int level1 { get; set; }
        public string title { get; set; }
        public string ALLOW_BID_KEY { get; set; }
        public string LEVEL_TITLE_KEY { get; set; }
        public string feebuytran { get; set; }
        public string fee_standard { get; set; }
    }

    public class MemberShipLevelERP
    {
        public string AccountId { get; set; }
        public string FeebuyGe { get; set; }
        public string FeebuyUs { get; set; }
        public string FeebuyJp { get; set; }
        public string FeebuyKr { get; set; }
        public string FeebuyUk { get; set; }
        public string FeebuyCn { get; set; }
        public string FeebuyVc { get; set; }
        public string feetran { get; set; }
        public int level1 { get; set; }
        public string title { get; set; }
        public string ALLOW_BID_KEY { get; set; }
        public string LEVEL_TITLE_KEY { get; set; }
        public string fee_standard { get; set; }
        public string PercentBulky { get; set; }
        public string FeeTranBulky { get; set; }
    }
}
