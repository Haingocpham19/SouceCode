using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public class AdapterProfile : Profile
    {
        public AdapterProfile()
        {
            Customer();
        }

        private void CreateMapIgnore<TFromModel, TToModel>()
        {
            var map = CreateMap<TFromModel, TToModel>();
            map.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }

        private void Customer()
        {
            CreateMapIgnore<Customer, Customer>();
            CreateMapIgnore<Customer, CustomerViewModel>();
        }
    }
}
