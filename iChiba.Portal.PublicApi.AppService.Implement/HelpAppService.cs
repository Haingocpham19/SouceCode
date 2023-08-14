using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChiba.Portal.Service.Interface;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class HelpAppService : BaseAppService, IHelpAppService
    {
        private readonly IGroupGuidelinesService _groupGuidelinesService;
        private readonly IGuidelinesService _guidelinesService;
        public HelpAppService(
            ILogger<HelpAppService> logger,
            IGroupGuidelinesService groupGuidelinesService,
            IGuidelinesService guidelinesService)
            : base(logger)
        {
            _guidelinesService = guidelinesService;
            _groupGuidelinesService = groupGuidelinesService;
        }
        public async Task<BaseEntityResponse<IList<GroupGuidelines>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<GroupGuidelines>>();
            await TryCatchAsync(async () =>
            {
                var groupGuidelines = await _groupGuidelinesService.GetAll(languageId);
                var groupGuidelinesData = groupGuidelines.Select(m => m.ToModel()).OrderBy(m => m.Order).ToList();
                var groupGuidelineses = groupGuidelinesData.Where(g => g.Parent == null).ToList();

                var guidelines = await _guidelinesService.GetAll(languageId);
                var guidelinesData = guidelines.Select(m => m.ToModel()).OrderBy(m => m.Order).ToList();

                if (!groupGuidelinesData.Any())
                {
                    response.Status = false;
                    return response;
                }

                if (!guidelinesData.Any())
                {
                    response.Status = false;
                    return response;
                }

                foreach (var item in groupGuidelineses)
                {
                    GenerateRecursiveTreeView(item, groupGuidelinesData, guidelinesData);
                }

                if (groupGuidelineses.Any())
                {
                    response.SetData(groupGuidelineses)
                        .Successful();

                }

                return response;
            }, response);

            return response;
        }

        private void GenerateRecursiveTreeView(GroupGuidelines item, IList<GroupGuidelines> listData,
            IList<Guidelines> guidelineList)
        {
            var guidelines = guidelineList.Where(g => g.GroupId == item.Id && g.Status == 1)
                .OrderByDescending(g => g.CreatedDate).ToList();

            item.GuidelinesList = guidelines;

            var result = listData.Where(m => m.Parent == item.Id).ToList();

            if (result.Any())
            {
                foreach (var ite in result)
                {
                    item.Children.Add(ite);
                    GenerateRecursiveTreeView(ite, listData, guidelineList);
                }
            }
        }
    }
}
