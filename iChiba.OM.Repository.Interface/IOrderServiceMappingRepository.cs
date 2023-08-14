using Core.Repository.Interface;
using iChiba.OM.Model;
using System.Collections.Generic;

namespace iChiba.OM.Repository.Interface
{
    public interface IOrderServiceMappingRepository : IRepository<OrderServiceMapping>
    {
        void DeleteAllByOrderId(IList<OrderServiceMapping> models);
        void AddRange(IList<OrderServiceMapping> models);
    }
}
