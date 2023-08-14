using AutoMapper;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.WH.Model;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class PackageDetailAdapter
    {
        public static PackageDetailViewModel ToModel(this PackageDetail model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<PackageDetail, PackageDetailViewModel>(model);
        }
    }
}
