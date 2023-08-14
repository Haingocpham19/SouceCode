using System.Collections.Generic;
using Core.Common;
using iChiba.DC.Model;

namespace iChiba.DC.Service.Interface
{
    public interface IBuyerConfigService
    {
        IList<BuyerConfig> GetAll(string keyword, string orderType, string Buyers, string shippingRoute, Sorts sorts, Paging paging);
        BuyerConfig Add(BuyerConfig buyerConfig);
        BuyerConfig GetDetail(int id);
        void Update(BuyerConfig model);
        void Delete(BuyerConfig bidConfig);
        IList<string> GetOrderType();
        IList<BuyerConfig> GetOrderTypeByRoute(string Routes);
        IList<BuyerConfig> Gets();
    }
}