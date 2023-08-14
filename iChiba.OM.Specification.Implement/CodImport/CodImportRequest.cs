using System;
using System.Collections.Generic;
using Core.Specification.Abstract;

namespace iChiba.OM.Specification.Implement.CodImport
{
    public class CodImportRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportRequest(string codeType, string tracking, string supplier, DateTime? startTime, DateTime? endTime, string mawb, string orderCode, bool? mawbEmty)
           : base(m => (string.IsNullOrWhiteSpace(m.CodeType))
                       && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                       && (string.IsNullOrWhiteSpace(supplier) || m.Supplier.Contains(supplier))
                       && (string.IsNullOrWhiteSpace(mawb) || m.Mawb.Contains(mawb))
                       && (startTime == null || m.PayCodeDate >= startTime)
                       && (endTime == null || m.PayCodeDate <= endTime)
                       && (string.IsNullOrWhiteSpace(orderCode) || m.OrderCode.Contains(orderCode)))
        {
        }

        public CodImportRequest(string codeType, string tracking, string supplier, DateTime? startTime, DateTime? endTime, string mawb, string orderCode)
           : base(m => (string.IsNullOrWhiteSpace(codeType) || m.CodeType.Contains(codeType))
                       && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                       && (string.IsNullOrWhiteSpace(supplier) || m.Supplier.Contains(supplier))
                       && (string.IsNullOrWhiteSpace(mawb) || m.Mawb.Contains(mawb))
                       && (startTime == null || m.PayCodeDate >= startTime)
                       && (endTime == null || m.PayCodeDate <= endTime)
                       && (string.IsNullOrWhiteSpace(orderCode) || m.OrderCode.Contains(orderCode)))
        {
        }
    }

    public class CodImport_CODRequest : SpecificationBase<Model.CodImport>
    {
        public CodImport_CODRequest(string codeType, string tracking, string supplier, DateTime? startTime, DateTime? endTime, string mawb, string orderCode)
           : base(m => (m.CodeType.Equals(codeType))
                       && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                       && (string.IsNullOrWhiteSpace(supplier) || m.Supplier.Contains(supplier))
                       && (string.IsNullOrWhiteSpace(mawb) || m.Mawb.Contains(mawb))
                       && (startTime == null || m.PayCodeDate >= startTime)
                       && (endTime == null || m.PayCodeDate <= endTime)
                       && (string.IsNullOrWhiteSpace(orderCode) || m.OrderCode.Contains(orderCode)))
        {
        }
    }


    public class CodImportmawbEmtyRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportmawbEmtyRequest(bool? mawbEmty)
           : base(m => (string.IsNullOrWhiteSpace(m.Mawb)))
        {
        }
    }


    public class CodImportGetByTrackingRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportGetByTrackingRequest(string tracking)
           : base(m => (m.Tracking.Equals(tracking)))
        {
        }
    }

    public class CodImportGetByTrackingOrOrderCode : SpecificationBase<Model.CodImport>
    {
        public CodImportGetByTrackingOrOrderCode(string keyword)
            : base(m => m.Tracking.Equals(keyword) || m.OrderCode.Equals(keyword) || m.DoneOrderCode.Equals(keyword))
        {
        }

        public CodImportGetByTrackingOrOrderCode(List<string> keywords)
            : base(m => keywords.Contains(m.Tracking) || keywords.Contains(m.OrderCode) || keywords.Contains(m.DoneOrderCode))
        {
        }
    }

    public class CodImportGetByTrackingsRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportGetByTrackingsRequest(List<string> trackings)
           : base(m => trackings.Contains(m.Tracking))
        {
        }
    }
    public class CodImportCodeTypeRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportCodeTypeRequest()
           : base(m => (string.IsNullOrWhiteSpace(m.CodeType)))
        {
        }
    }

    public class CodImporttrackingRequest : SpecificationBase<Model.CodImport>
    {
        public CodImporttrackingRequest(string tracking)
           : base(m => m.Tracking.Contains(tracking))
        {
        }
    }

    public class CodImportCode_CodTypeRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportCode_CodTypeRequest(string codeType)
           : base(m => m.CodeType.Equals(codeType))
        {
        }
    }


    public class CodImportSupplierRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportSupplierRequest(string supplier)
           : base(m => m.Supplier.Contains(supplier))
        {
        }
    }

    public class CodImportDateTimeRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportDateTimeRequest(DateTime? startTime)
           : base(m => (m.PayCodeDate >= startTime))
        {
        }
    }


    public class CodImportEndTimeRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportEndTimeRequest(DateTime? endTime)
           : base(m => (m.PayCodeDate <= endTime))
        {
        }
    }


    public class CodImportmawbRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportmawbRequest(string mawb)
           : base(m => m.Mawb.Contains(mawb))
        {
        }
    }

    public class CodImportorderCodeRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportorderCodeRequest(string orderCode)
           : base(m => m.OrderCode.Contains(orderCode))
        {
        }
    }

    public class CodImportGetsForSyncData : SpecificationBase<Model.CodImport>
    {
        public CodImportGetsForSyncData()
            : base(m => m.Done == null || m.Done == false)
        {
        }
    }
}
