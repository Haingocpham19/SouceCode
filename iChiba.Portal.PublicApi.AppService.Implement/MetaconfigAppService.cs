using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Interface;
using Core.AppModel.Response;
using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class MetaconfigAppService : BaseAppService, IMetaconfigAppService
    {
        private readonly IMetaconfigService metaconfigService;

        public MetaconfigAppService(ILogger<MetaconfigAppService> logger,
            IMetaconfigService metaconfigService
            )
            : base(logger)
        {
            this.metaconfigService = metaconfigService;
        }


        public async Task<BaseEntityResponse<IList<Metaconfig>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<Metaconfig>>();
            await TryCatchAsync(async () =>
            {
                var data = await metaconfigService.GetAll(languageId);

                var responseData = data.Select(m => m.ToModel()).ToList();
                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;
        }
    }
}
