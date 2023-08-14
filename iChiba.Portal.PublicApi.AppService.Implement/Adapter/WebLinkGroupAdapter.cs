using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class WebLinkGroupAdapter
    {
        public static AppModel.Model.WebLinkGroup ToModel(this WebLinkGroup model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<WebLinkGroup, AppModel.Model.WebLinkGroup>(model);
        }
    }
}
