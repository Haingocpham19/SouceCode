using Core.AppModel.Response;
using iChiba.Portal.Common;

namespace iChiba.Portal.PublicApi.AppModel.Response
{
    public class CustomerElectronicContractResponse : BaseEntityResponse<CustomerElectronicContract>
    {

    }

    public class CustomerElectronicContract
    {
        public string Signture { get; set; }
        public string ContractFile { get; set; }
        public string ContractFileFullUrl
        {
            get
            {
                return Utility.CreateFullFileUrl(ContractFile);
            }
        }
        public string SigntureFullUrl
        {
            get
            {
                return Utility.CreateFullFileUrl(Signture);
            }
        }
    }
}
