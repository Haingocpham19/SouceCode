using iChiba.WH.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.WH.Service.Interface
{
    public interface IPackageService
    {
        IEnumerable<Package> GetById(List<int> ids);
        IEnumerable<Package> GetByParentId(List<int> parentIds);
        IEnumerable<Package> GetByTrackingCode(List<string> trackingCodes);
    }
}
