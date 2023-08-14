using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class OrderPaymentDetail
    {
        public int Weight { get; set; }
        public int Width { get; set; }
        public int Hight { get; set; }
        public int Length { get; set; }
        public int ShippingUnitGlobal { get; set; }
        public long ShippingFee { get; set; }
        public long ShippingFeeVND { get; set; }
        public long Surcharge { get; set; }
        public long SurchargeVND { get; set; }
        public long BuyFee { get; set; }
        public long Total { get; set; }
        public long TotalVND { get; set; }
        public long PriceJP { get; set; }
        public decimal BuyFeeAmount { get; set; }
        public decimal BuyFeeAmountVND { get; set; }
        public decimal ShippingGlobalByWeightAmountVND { get; set; }
        public decimal SizeToWeight { get; set; }
        public decimal ShippingGlobalBySizeAmountVND { get; set; }
        public decimal ShippingGlobalVND { get; set; }
        public int ExchangeRateVND { get; set; }
        public long DeliveryFeeVND { get; set; }
        public long MinPaymentPrice { get; set; }
        public long MinPaymentPriceVND { get; set; }
        public long AmountVND { get; set; }
        public long TotalDepositVND { get; set; }
        public long DebtVND { get; set; }
        public bool IsPaid { get; set; }
        public bool Temp { get; set; }
        public IDictionary<int, long> PercentPayments { get; set; }
    }
}
