using System.Collections.Generic;

namespace Ichiba.Partner.Api.Driver.Request
{
    public class ProductDetailFromUrlRequest
    {
        public string Url { get; set; }
    }
    public class ProductDetailFromUrlListRequest
    {
        public List<string> Url { get; set; }
    }
}
