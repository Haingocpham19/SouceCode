using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
   public interface IExchangeratesAppService
    {
        Task<decimal> GetRateByCode(string code);
    }
}
