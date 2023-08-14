using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Service.Interface;
using iChiba.WH.Specification.Implement;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.WH.Service.Implement
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            this.warehouseRepository = warehouseRepository;
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return warehouseRepository.Find().ToList();
        }

        public Warehouse GetByCode(string code)
        {
            return warehouseRepository.FindSingleBySpec(new WarehouseGetByCode(code));
        }

        public IEnumerable<Warehouse> GetByCodes(params string[] codes)
        {
            return warehouseRepository.Find(new WarehouseGetByCodes(codes)).ToList();
        }
    }
}
