using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using iChiba.OM.Specification.Implement.CodImport;

namespace iChiba.OM.Service.Implement
{
    public class CodImportService : ICodImportService
    {
        private readonly ICodImportRepository codImportRepository;
        public CodImportService(ICodImportRepository codImportRepository)
        {
            this.codImportRepository = codImportRepository;
        }

        //public IList<CodImport> Gets(string codeType,string tracking,string supplier,DateTime? startTime,DateTime? endTime,string mawb,string orderCode,bool? mawbEmty,Sorts sorts, Paging paging)
        //{
        //    return codImportRepository.Find(new CodImportRequest(codeType, tracking, supplier, startTime, endTime, mawb, orderCode, mawbEmty), sorts, paging).ToList();
        //}


        public IList<CodImport> Gets(string codeType, string tracking, string supplier, DateTime? startTime, DateTime? endTime, string mawb, string orderCode, bool? mawbEmty, Sorts sorts, Paging paging)
        {
            var spec = new Specification<CodImport>(x => true)
                .AndIf(!string.IsNullOrWhiteSpace(tracking), new CodImporttrackingRequest(tracking))
                .AndIf(!string.IsNullOrWhiteSpace(supplier), new CodImportSupplierRequest(supplier))
                .AndIf(startTime != null, new CodImportDateTimeRequest(startTime))
                .AndIf(startTime != null, new CodImportEndTimeRequest(endTime))
                .AndIf(!string.IsNullOrWhiteSpace(mawb), new CodImportmawbRequest(mawb))
                .AndIf(!string.IsNullOrWhiteSpace(orderCode), new CodImportorderCodeRequest(orderCode))
                .AndIf(mawbEmty != null, new CodImportmawbEmtyRequest(mawbEmty))
                .And(new CodImportCodeTypeRequest());


            return codImportRepository.Find(spec, sorts, paging).OrderByDescending(item => item.Id).ToList();
        }

        public IList<CodImport> GetsCod(string codeType, string tracking, string supplier, DateTime? startTime, DateTime? endTime, string mawb, string orderCode, Sorts sorts, Paging paging)
        {
            return codImportRepository.Find(new CodImport_CODRequest(codeType, tracking, supplier, startTime, endTime, mawb, orderCode), sorts, paging).OrderByDescending(item => item.Id).ToList();
        }


        public IList<CodImport> GetsCod(string codeType, string tracking, string supplier, DateTime? startTime, DateTime? endTime, string mawb, string orderCode, bool? mawbEmty, Sorts sorts, Paging paging)
        {
            var spec = new Specification<CodImport>(x => true)
                .AndIf(!string.IsNullOrWhiteSpace(tracking), new CodImporttrackingRequest(tracking))
                .AndIf(!string.IsNullOrWhiteSpace(supplier), new CodImportSupplierRequest(supplier))
                .AndIf(startTime != null, new CodImportDateTimeRequest(startTime))
                .AndIf(startTime != null, new CodImportEndTimeRequest(endTime))
                .AndIf(!string.IsNullOrWhiteSpace(mawb), new CodImportmawbRequest(mawb))
                .AndIf(!string.IsNullOrWhiteSpace(orderCode), new CodImportorderCodeRequest(orderCode))
                .AndIf(mawbEmty != null, new CodImportmawbEmtyRequest(mawbEmty))
                .And(new CodImportCode_CodTypeRequest(codeType));


            return codImportRepository.Find(spec, sorts, paging).OrderByDescending(item => item.Id).ToList();
        }

        public CodImport GetsByTracking(string tracking)
        {
            return codImportRepository.FindSingleBySpec(new CodImportGetByTrackingRequest(tracking));
        }

        public CodImport GetByTrackingOrOrderCode(string keyword)
        {
            return codImportRepository.FindSingleBySpec(new CodImportGetByTrackingOrOrderCode(keyword));
        }

        public IList<CodImport> GetByTrackingOrOrderCode(List<string> keywords)
        {
            var spec = new Specification<CodImport>(x => true)
                                            .AndIf(keywords.Any(), new CodImportGetByTrackingOrOrderCode(keywords));

            return codImportRepository.Find(spec).ToList();
        }

        public IEnumerable<CodImport> GetsByTrackings(List<string> trackings)
        {
            return codImportRepository.Find(new CodImportGetByTrackingsRequest(trackings));
        }

        public void Add(CodImport model)
        {
            codImportRepository.Add(model);
        }

        public void Update(CodImport model)
        {
            codImportRepository.Update(model);
        }

        public IList<CodImport> Export(string codeType, string tracking, string supplier, DateTime? startTime, DateTime? endTime, string mawb, string orderCode)
        {
            return codImportRepository.Find(new CodImportRequest(codeType, tracking, supplier, startTime, endTime, mawb, orderCode)).ToList();
        }

        public IList<CodImport> GetsForSyncData()
        {
            var spec = new Specification<CodImport>(x => true)
                                            .And(new CodImportGetsForSyncData());

            return codImportRepository.Find(spec).ToList();
        }

        public IList<CodImport> GetsForUpdateData()
        {
            var spec = new Specification<CodImport>(x => true)
                                            .And(new CodImportUpdateDataRequest());

            return codImportRepository.Find(spec).ToList();
        }
    }
}
