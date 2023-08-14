using AutoMapper;
using Ichiba.Portal.Commands;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class AdvisoryAdapter
    {
        public static AdvisoryAddCommand ToModel(this AppModel.Model.Advisory model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<AppModel.Model.Advisory, AdvisoryAddCommand>(model);
        } 
    }
}
