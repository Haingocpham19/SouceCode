using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class ExchangeratesAdapter
    {
        public static AppModel.Model.Exchangerates ToModel(this Exchangerates model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Exchangerates, AppModel.Model.Exchangerates>(model);
        } 
    }
}
