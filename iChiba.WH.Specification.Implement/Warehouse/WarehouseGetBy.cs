using Core.Specification.Abstract;
using iChiba.WH.Model;
using System.Linq;

namespace iChiba.WH.Specification.Implement
{
    public class WarehouseGetBy : SpecificationBase<Warehouse>
    {
        public WarehouseGetBy(string keyword)
             : base(m => string.IsNullOrWhiteSpace(keyword) || m.Description.Contains(keyword) || m.Address.Contains(keyword) || m.Code.Contains(keyword) || m.Description.Contains(keyword) || m.Name.Contains(keyword) || m.Description.Contains(keyword))
        {

        }
    }

    public class WarehouseGetByStatus : SpecificationBase<Warehouse>
    {
        public WarehouseGetByStatus(params int[] status)
             : base(m => status != null || (m.Status.HasValue && status.Contains(m.Status.Value)))
        {

        }
    }
    public class WarehouseJPGetByStatus : SpecificationBase<Warehouse>
    {
        public WarehouseJPGetByStatus(params int[] status)
             : base(m => (status != null || (m.Status.HasValue && status.Contains(m.Status.Value))) && m.PostalCode!=null && !string.IsNullOrEmpty(m.PostalCode) )
        {

        }
    }

    public class WarehouseForeign : SpecificationBase<Warehouse>
    {
        public WarehouseForeign(params int[] status)
             : base(m => (status != null || (m.Status.HasValue && status.Contains(m.Status.Value))) && m.PostalCode != null && !string.IsNullOrEmpty(m.PostalCode) && !m.Country.Equals("VIETNAM"))
        {

        }
    }


    public class WarehousePCSGetByStatus : SpecificationBase<Warehouse>
    {
        public WarehousePCSGetByStatus(params int[] status)
             : base(m => (status != null || (m.Status.HasValue && status.Contains(m.Status.Value))) && m.PostalCode != null && !string.IsNullOrEmpty(m.PostalCode))
        {

        }
    }

    public class WarehouseForPOPCSGetByStatus : SpecificationBase<Warehouse>
    {
        public WarehouseForPOPCSGetByStatus(int status,string country)
             : base(m => m.Status == status && m.PostalCode != null && !string.IsNullOrEmpty(m.PostalCode)
             && !m.Region.Equals("VN")
             && (string.IsNullOrWhiteSpace(m.Country) || m.Country.Equals(country)))
        {

        }
    }


    public class WarehouseGetByVN : SpecificationBase<Warehouse>
    {
        public WarehouseGetByVN()
             : base(m => m.Region.Equals("VN"))
        {

        }
    }


    public class WarehouseGetByCode : SpecificationBase<Warehouse>
    {
        public WarehouseGetByCode(string code)
             : base(m => m.Code.Equals(code))
        {

        }
    }

    public class WarehouseGetByCodes : SpecificationBase<Warehouse>
    {
        public WarehouseGetByCodes(params string[] codes)
             : base(m => codes.Contains(m.Code))
        {

        }
    }

    public class WarehouseGetByIds : SpecificationBase<Warehouse>
    {
        public WarehouseGetByIds(int[] warehouseIds)
            : base(m => (warehouseIds.Contains(m.Id)))
        {

        }
    }
}
