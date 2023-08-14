using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Interface;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using Core.CQRS.Model.Implements;
using Core.CustomException;
using iChiba.Portal.CustomException;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class ContactAppService : BaseAppService, IContactAppService
    {
        private readonly PortalCommandAppService portalCommandAppService;

        public ContactAppService(ILogger<ContactAppService> logger,
            PortalCommandAppService portalCommandAppService)
            : base(logger)
        {
            this.portalCommandAppService = portalCommandAppService;
        }


        public async Task<BaseResponse> Add(Contact model)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var modelCommand = model.ToModel();
                var result = await portalCommandAppService.SendAndReceiveResult<CommandResult>(modelCommand);

                if (!result.IsSucess)
                {
                    throw new ErrorCodeException(ErrorCodeDefine.CONTACT_ADD_FAIL);
                }

                response.Successful();

                return response;
            }, response);

            return response;
        }
    }
}
