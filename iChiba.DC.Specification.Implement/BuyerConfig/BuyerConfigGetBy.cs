using Core.Specification.Abstract;

namespace iChiba.DC.Specification.Implement.BuyerConfig
{
    public class BuyerConfigGetBy : SpecificationBase<Model.BuyerConfig>
    {
        public BuyerConfigGetBy(string keyword, string orderType, string buyers, string routes)
          : base(m => (string.IsNullOrEmpty(keyword) || m.OrderType.Contains(keyword) || m.Buyer.Contains(keyword))
          && (string.IsNullOrEmpty(orderType) || m.OrderType.Contains(orderType))
          && (string.IsNullOrWhiteSpace(buyers) || m.Buyer.Contains(buyers))
          )
        {
        }

        public BuyerConfigGetBy(string Routes)
         : base(m => string.IsNullOrWhiteSpace(Routes)
         )
        {
        }
    }
}
