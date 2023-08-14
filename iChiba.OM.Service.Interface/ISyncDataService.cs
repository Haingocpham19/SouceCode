using System.Collections.Generic;
using Core.Common;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface ISyncDataService
    {
        IList<SyncData> Gets(Sorts sorts, Paging paging);
        IList<SyncData> GetByDataType(int dataType, bool ignore);
        void Delete(SyncData item);
    }
}