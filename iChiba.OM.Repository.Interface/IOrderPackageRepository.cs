using System.Collections.Generic;
using Core.Repository.Interface;
using iChiba.OM.Model;

namespace iChiba.OM.Repository.Interface
{
    public interface IOrderPackageRepository : IRepository<OrderPackage>
    {
        void DetachedRange(IList<OrderPackage> orderPackage);
    }
}
