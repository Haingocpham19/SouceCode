using Core.AppModel.Request;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class OrderPackageListRequest : SortRequest
    {
        public int? OrderId { get; set; }
        public string Keyword { get; set; }
    }
}
