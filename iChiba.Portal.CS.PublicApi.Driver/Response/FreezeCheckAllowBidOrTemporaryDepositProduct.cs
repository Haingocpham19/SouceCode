namespace iChiba.Portal.CS.PublicApi.Driver.Response
{
    public class FreezeCheckAllowBidOrTemporaryDepositProduct
    {
        public bool IsVip { get; set; }
        public int? OldFreezeId { get; set; }
        public int NewFreezeId { get; set; }
    }
}
