using iChibaShopping.Core.AppService.Implement;
using iChiba.Portal.PublicApi.AppModel.Request;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using Core.AppModel.Response;
using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class WebLinkGroupAppService : BaseAppService, IWebLinkGroupAppService
    {
        private readonly IWebLinkGroupService webLinkGroupService;
        private readonly IWebLinkService webLinkService;

        public WebLinkGroupAppService(ILogger<WebLinkGroupAppService> logger,
            IWebLinkGroupService webLinkGroupService,
            IWebLinkService WebLinkService
            )
            : base(logger)
        {
            this.webLinkGroupService = webLinkGroupService;
            this.webLinkService = WebLinkService;
        }

        public async Task<BaseEntityResponse<IList<WebLinkGroup>>> GetAll(WebLinkGroupRequest request)
        {
            var response = new BaseEntityResponse<IList<WebLinkGroup>>();

            await TryCatchAsync(async () =>
            {
                var webLinkGroupAll = await webLinkGroupService.GetAll(request.LanguageId);
                var webLinkGroupIds = webLinkGroupAll.Select(m => m.Id).ToArray();
                var webLinks = await webLinkService.GetByIds(webLinkGroupIds, request.LanguageId);
                var responseData = webLinkGroupAll.Select(m =>
                    {
                        var model = m.ToModel();
                        if (webLinks != null)
                        {
                            model.Weblinks = webLinks.SelectMany(x => x).Where(x => x != null && x.GroupId == m.Id)
                                .Select(x => x.ToModel()).OrderBy(x => x.Order).ToList();
                        }
                        return model;
                    }).OrderBy(m => m.Order)
                    .ToList();
                response.SetData(responseData)
                    .Successful();
                return response;
            }, response);
            return response;
        }

        public async Task<BaseEntityResponse<IList<WebLink>>> GetWebLinkByGroupId(WebLinkByGroupIdRequest request)
        {
            var response = new BaseEntityResponse<IList<WebLink>>();
            await TryCatchAsync(async () =>
            {
                var webLinks = await webLinkService.HashGet(request.GroupId, request.LanguageId);
                var responseData = webLinks.Select(m => m.ToModel()).OrderBy(m => m.Order).ToList();
                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;

        }

        public async Task<BaseEntityResponse<IList<WebLinkGroup>>> GetWebLinkGroup(WebLinkGroupRequest request)
        {
            var response = new BaseEntityResponse<IList<WebLinkGroup>>();
            await TryCatchAsync(async () =>
            {
                var data = await webLinkGroupService.GetAll(request.LanguageId);

                var responseData = data.Select(m => m.ToModel()).OrderBy(m => m.Order).ToList();
                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;
        }
        public async Task<BaseEntityResponse<IList<WebLinkGroup>>> GetWebLinkGroupTop(WebLinkGroupTopRequest request)
        {
            var response = new BaseEntityResponse<IList<WebLinkGroup>>();
            await TryCatchAsync(async () =>
            {
                var data = await webLinkGroupService.GetAll(request.LanguageId);

                var responseData = data.Select(m => m.ToModel()).OrderBy(m => m.Order).Take(request.Top).ToList();
                if (responseData?.FirstOrDefault() != null)
                {
                    var webLinks = await webLinkService.HashGet(responseData[0].Id, request.LanguageId);
                    responseData[0].Weblinks = webLinks.Select(m => m.ToModel()).ToList();
                }
                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;
        }

    }
}
