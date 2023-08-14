using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class WebLinkAdapter
    {
        public static AppModel.Model.WebLink ToModel(this WebLink model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<WebLink, AppModel.Model.WebLink>(model);
        }
    }
}
