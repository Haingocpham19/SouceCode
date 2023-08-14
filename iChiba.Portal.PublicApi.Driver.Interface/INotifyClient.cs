using iChiba.Event.Api.AppModel.Model;
using iChiba.Shared.Models;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Driver.Interface
{
    public interface INotifyClient
    {
        Task<IChibaResponse> Send(NotifyModel request);

        Task<IChibaResponse> SubscribeToTopic(SubscribeNotifyModel request);

        Task<IChibaResponse> UnsubscribeFromTopic(SubscribeNotifyModel request);
    }
}
