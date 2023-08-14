using Core.Specification.Abstract;

namespace iChiba.OM.Specification.Implement
{
    public class SyncDataGets : SpecificationBase<Model.SyncData>
    {
        public SyncDataGets() : base(m => m.Ignore != null && (bool)!m.Ignore)
        {

        }
    }
    public class SyncDataGetByDataType : SpecificationBase<Model.SyncData>
    {
        public SyncDataGetByDataType(int datType) : base(m => m.DataType.Equals(datType))
        {

        }
    }
    public class SyncDataGetByOrderCode : SpecificationBase<Model.SyncData>
    {
        public SyncDataGetByOrderCode(string orderCode) : base(m => m.OrderCode.Contains(orderCode))
        {

        }
    }
}
