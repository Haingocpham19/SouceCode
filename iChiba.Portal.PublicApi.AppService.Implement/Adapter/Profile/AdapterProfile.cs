using AutoMapper;
using iChiba.Portal.Cache.Model;
using Ichiba.Portal.Commands;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public class AdapterProfile : Profile
    {
        public AdapterProfile()
        {
            WebLink();
            WebLinkGroup();
            AdvBanner();
            Guidelines();
            News();
            Recruitment();
            About();
            Policy();
            CategoryService();
            Service();
            Navigation();
            Advisory();
            Exchangerates();
            Metaconfig();
            Tags();
            Location();
            Settings();
            ShoppingCart();
            Order();
        }

        private IMappingExpression<TFromModel, TToModel> CreateMapIgnore<TFromModel, TToModel>()
        {
            var map = CreateMap<TFromModel, TToModel>();

            map.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            return map;
        }

        private void Order()
        {
            CreateMapIgnore<AppModel.Request.OrderAddRequest, CS.PublicApi.Driver.Request.OrderAddRequest>();
        }
        private void ShoppingCart()
        {
            CreateMapIgnore<ShoppingCart, AppModel.Model.ShoppingCart>();
            CreateMapIgnore<ShoppingCartItem, AppModel.Model.ShoppingCartItem>();
        }

        private void WebLink()
        {
            CreateMapIgnore<Cache.Model.WebLink, AppModel.Model.WebLink>();
            CreateMapIgnore<Cache.Model.WebLinkGroup, AppModel.Model.WebLinkGroup>();
        }
        private void WebLinkGroup()
        {
            CreateMapIgnore<Cache.Model.WebLinkGroup, AppModel.Model.WebLinkGroup>();
            CreateMapIgnore<Cache.Model.WebLinkGroup, AppModel.Model.WebLinkGroup>();
        }
       
        private void AdvBanner()
        {
            CreateMapIgnore<AppModel.Model.AdvBanner, Cache.Model.AdvBanner>();
        }
       
        private void Guidelines()
        {
            CreateMapIgnore<Cache.Model.Guidelines, AppModel.Model.Guidelines>();
            CreateMapIgnore<Cache.Model.GroupGuidelines, AppModel.Model.GroupGuidelines>();
        }

        private void News()
        {
            CreateMapIgnore<Cache.Model.CategoryNews, AppModel.Model.CategoryNews>();
            CreateMapIgnore<Index.Model.News, AppModel.Model.News>();
        }

        private void Recruitment()
        {
            CreateMapIgnore<Cache.Model.Recruitment, AppModel.Model.Recruitment>();
        }

        private void About()
        {
            CreateMapIgnore<Cache.Model.About, AppModel.Model.About>();
        }

        private void Policy()
        {
            CreateMapIgnore<Cache.Model.Policy, AppModel.Model.Policy>();
        }

        private void CategoryService()
        {
            CreateMapIgnore<Cache.Model.CategoryService, AppModel.Model.CategoryService>();
        }

        private void Service()
        {
            CreateMapIgnore<Cache.Model.Service, AppModel.Model.Service>();
        }

        private void Navigation()
        {
            CreateMapIgnore<Cache.Model.Navigation, AppModel.Model.Navigation>();
        }

        private void Advisory()
        {
            CreateMapIgnore<AdvisoryAddCommand, AppModel.Model.Advisory>();
        }

        private void Exchangerates()
        {
            CreateMapIgnore<Cache.Model.Exchangerates, AppModel.Model.Exchangerates>();
        }

        private void Metaconfig()
        {
            CreateMapIgnore<Cache.Model.Metaconfig, AppModel.Model.Metaconfig>();
        }

        private void Tags()
        {
            CreateMapIgnore<Cache.Model.Tags, AppModel.Model.Tags>();
        }

        private void Location()
        {
            CreateMapIgnore<Cache.Model.Location, AppModel.Model.Location>();
        }

        private void Settings()
        {
            CreateMapIgnore<Cache.Model.Settings, AppModel.Model.Settings>();
        }
    }
}
