using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Repository.Implement
{
    public class OrderServiceMappingRepository : BaseRepository<CustomerDBContext, OrderServiceMapping>, IOrderServiceMappingRepository
    {
        public OrderServiceMappingRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllByOrderId(IList<OrderServiceMapping> models)
        {
            models.ToList()
                .ForEach(m => Delete(m));
        }

        public void AddRange(IList<OrderServiceMapping> models)
        {
            models.ToList()
                .ForEach(m => Add(m));
        }
    }
}
