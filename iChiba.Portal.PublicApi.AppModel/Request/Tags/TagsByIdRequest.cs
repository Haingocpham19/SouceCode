using Core.AppModel.Request;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class TagsByIdRequest
    {
        public IList<int> TagsId { get; set; }
        public string LanguageId { get; set; }
    }
}
