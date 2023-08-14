using AutoMapper;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.WH.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class PackageDetailQuoteAdapter
    {
        public static PackageDetailQuoteViewModel ToModel(this PackageDetailQuote model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<PackageDetailQuote, PackageDetailQuoteViewModel>(model);
        }
    }
}
