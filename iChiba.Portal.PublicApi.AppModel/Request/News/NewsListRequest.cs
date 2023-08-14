using Core.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class NewsListRequest : PagingRequest
    {
        public int CategoryId { get; set; }
        public string Keyword { get; set; }
        public string LanguageId { get; set; }
    }
}
