using System.Collections.Generic;
using System.Linq;
using Core.Common;
using iChiba.DC.Model;
using iChiba.DC.Repository.Interface;
using iChiba.DC.Service.Interface;
using iChiba.DC.Specification.Implement.BuyerConfig;

namespace iChiba.DC.Service.Implement
{
    public class BuyerConfigService : IBuyerConfigService
    {
        private readonly IBuyerConfigRepository buyerConfigRepository;
        public BuyerConfigService(IBuyerConfigRepository buyerConfigRepository)
        {
            this.buyerConfigRepository = buyerConfigRepository;
        }

        public IList<BuyerConfig> GetAll(string keyword, string orderType, string Buyers, string Routes, Sorts sorts, Paging paging)
        {
            return buyerConfigRepository.Find(new BuyerConfigGetBy(keyword, orderType, Buyers, Routes), sorts, paging).ToList();
        }

        public IList<BuyerConfig> Gets()
        {
            return buyerConfigRepository.Find().ToList();
        }

        public IList<string> GetOrderType()
        {
            return buyerConfigRepository.Find().Select(x => x.OrderType).Distinct().ToList();
        }

        public IList<BuyerConfig> GetOrderTypeByRoute(string Routes)
        {
            return buyerConfigRepository.Find(new BuyerConfigGetBy(Routes)).ToList();
        }

        public BuyerConfig GetDetail(int id)
        {
            return buyerConfigRepository.FindById(id);
        }

        public BuyerConfig Add(BuyerConfig bidConfig)
        {
            return buyerConfigRepository.Add(bidConfig);
        }

        public void Delete(BuyerConfig bidConfig)
        {
            buyerConfigRepository.Delete(bidConfig);
        }

        public void Update(BuyerConfig model)
        {
            buyerConfigRepository.Update(model);
        }
    }
}
