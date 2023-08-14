using System;

namespace iChiba.Portal.PublicApi.AppService.Implement.Common
{
    public class BuyFeeDiscountConfig
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int BuyFeePercent { get; set; }
        public int MercariBuyFeePercent { get; set; }
    }
}
