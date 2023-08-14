using Core.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class NewsTopRequest
    {
        public int? CategoryId { get; set; }
        public int Limit { get; set; }
        public string LanguageId { get; set; }
    }
}
