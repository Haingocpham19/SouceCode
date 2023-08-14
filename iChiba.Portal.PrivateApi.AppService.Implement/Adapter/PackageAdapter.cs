using AutoMapper;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.WH.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class PackageAdapter
    {
        public static PackageViewModel ToModel(this Package model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Package, PackageViewModel>(model);
        }
    }
}
