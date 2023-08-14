using System.Collections.Generic;
using Core.Common;
using iChiba.WH.Model;

namespace iChiba.WH.Service.Interface
{
    public interface IServiceChargeService
    {
        IList<ServiceCharge> GetAll();
    }
}
