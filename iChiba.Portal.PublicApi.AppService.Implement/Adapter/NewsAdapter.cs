using AutoMapper;
using iChiba.Portal.Index.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class NewsAdapter
    {
        public static AppModel.Model.News ToModel(this News model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<News, AppModel.Model.News>(model);
        }
    }
}
