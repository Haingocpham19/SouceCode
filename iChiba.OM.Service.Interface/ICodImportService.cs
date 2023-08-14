using Core.Common;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;

namespace iChiba.OM.Service.Interface
{
    public interface ICodImportService
    {
        IList<CodImport> Gets(string codeType, string tracking, string supplier, DateTime? startTime, DateTime? endTime, string mawb, string orderCode,bool? mawbEmty, Sorts sorts, Paging paging);

        void Add(CodImport model);

        IList<CodImport> GetsCod(string codeType, string tracking, string supplier, DateTime? startTime, DateTime? endTime, string mawb,  string orderCode, bool? mawbEmty, Sorts sorts, Paging paging);

        CodImport GetsByTracking(string tracking);

        CodImport GetByTrackingOrOrderCode(string keyword);

        IList<CodImport> GetByTrackingOrOrderCode(List<string> keywords);

        IEnumerable<CodImport> GetsByTrackings(List<string> trackings);

        void Update(CodImport model);

        IList<CodImport> Export(string codeType, string tracking, string supplier, DateTime? startTime, DateTime? endTime, string mawb, string orderCode);

        IList<CodImport> GetsForSyncData();

        IList<CodImport> GetsForUpdateData();
    }
}
