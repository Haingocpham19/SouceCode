using AutoMapper;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.ExtensionApi.AppModel.Model;

namespace iChiba.Portal.ExtensionApi.AppService.Implement.Adapter
{
    public static class ExchangeratesAdapter
    {
        public static Exchangerates ToModel(this ExchangeratesViewModel model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<ExchangeratesViewModel, Exchangerates>(model);
        }
        public static ExchangeratesViewModel ToViewModel(this Exchangerates model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Exchangerates, ExchangeratesViewModel>(model);
        }
    }
}
