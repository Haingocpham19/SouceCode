using Core.Common;
using iChiba.WH.Model;
using System.Collections.Generic;

namespace iChiba.WH.Service.Interface
{
    public interface IWarehouseService
    {
        IEnumerable<Warehouse> GetAll();
        Warehouse GetByCode(string code);
        IEnumerable<Warehouse> GetByCodes(params string[] codes);
    }
}
