using Core.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class NewsListByTagRequest : PagingRequest
    {
        public int TagId { get; set; }
        public string LanguageId { get; set; }
    }
}
