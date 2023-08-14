using System.Collections.Generic;
using Core.AppModel.Response;

namespace iChiba.Portal.CS.PublicApi.Driver.Response
{
    public class GetNotifyGroupByAppIdResponse : BaseEntityResponse<IList<NotifyConfigGroup>>
    {
    }

    public class NotifyConfig
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool Required { get; set; }
        public bool? IsCheckedEmailByUser { get; set; }
        public bool? IsCheckedWebByUser { get; set; }
    }

    public class NotifyConfigGroup
    {
        public NotifyConfigGroup()
        {
            NotifyConfig = new HashSet<NotifyConfig>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Ord { get; set; }
        public string AppId { get; set; }

        public ICollection<NotifyConfig> NotifyConfig { get; set; }
    }
}