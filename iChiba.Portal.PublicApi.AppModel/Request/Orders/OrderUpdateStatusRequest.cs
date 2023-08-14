using Core.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderUpdateStatusRequest
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }
}
