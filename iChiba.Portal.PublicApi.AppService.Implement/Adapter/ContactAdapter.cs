using AutoMapper;
using Ichiba.Portal.Commands;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class ContactAdapter
    {
        public static ContactAddCommand ToModel(this AppModel.Model.Contact model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<AppModel.Model.Contact, ContactAddCommand>(model);
        } 
    }
}
