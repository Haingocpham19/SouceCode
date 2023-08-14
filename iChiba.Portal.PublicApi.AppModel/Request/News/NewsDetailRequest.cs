using Core.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class NewsDetailRequest
    {
        public int Id { get; set; }
        public string MetaTitle { get; set; }
        public string LanguageId { get; set; }
    }
}
