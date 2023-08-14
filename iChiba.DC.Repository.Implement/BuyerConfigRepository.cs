using Core.Repository.Abstract;
using iChiba.DC.DbContext;
using iChiba.DC.Model;
using iChiba.DC.Repository.Interface;

namespace iChiba.DC.Repository.Implement
{
    public class BuyerConfigRepository : BaseRepository<DATA_COMMONContext, BuyerConfig>, IBuyerConfigRepository
    {
        public BuyerConfigRepository(DATA_COMMONContext dbContext) : base(dbContext)
        {
        }
    }
}
