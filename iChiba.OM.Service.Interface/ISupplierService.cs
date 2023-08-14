using Core.Common;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;

namespace iChiba.OM.Service.Interface
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> SupplierGetByCodes(params string[] code);
        IList<Supplier> Gets(string searchKeyword, string code, string taxcode, string phone, DateTime? StartTime, DateTime? EndTime, bool? active, Sorts sorts, Paging paging);
        IList<Supplier> GetsSync(string searchKeyword, string code, string taxcode, string phone, DateTime? StartTime, DateTime? EndTime, bool? active, Sorts sorts, Paging paging);
        Supplier Add(Supplier model);
        Supplier GetById(int id);
        void Update(Supplier model);
        void Delete(Supplier model);
        IList<Supplier> Gets();
        IList<Supplier> GetListSupplierByUID(string[] uid);
        IList<Supplier> GetHaveAccountId();
        IList<Supplier> AutoComplete(string keyword, Sorts sorts, Paging paging);
        IList<Supplier> GetsSupplierByUID(params string[] uid);
        IList<Supplier> GetsSupplierByObjectCode(params string[] objectCode);
        Supplier GetDetailSupplierByUID(string uid);
        IList<Supplier> Search(string keyword, Paging paging);
        IList<Supplier> GetsSupplierById(params int[] ids);
        IList<Supplier> GetsSupplierByCode(params string[] code);
        IList<Supplier> GetSuppliers();
        Supplier GetDetailSupplierByCode(string code);
        Supplier GetByCode(string code);
        bool ExistingByAccountId(string accountId);
        IList<Supplier> GetListByBuyer(string keyword, Sorts sorts, Paging paging);
        IList<Supplier> GetListByBuyer();
        IList<Supplier> GetByAccountIds(params string[] accIds);
        Supplier GetByAccountId(string accountId);
        IList<Supplier> GetListByCode(string code);
        Supplier GetSingleByAccountId(string accId);
        IList<Supplier> GetListSupplierByAccountId(string accountId);
        Supplier GetSingerSupplierByAccountId(string accountId);
        IList<Supplier> GetListSupplers(string code);
        IList<Supplier> GetsSupplierBylistCode(List<string> codes,string code);
        HashSet<string> ExistsListCode(IEnumerable<string> lstCode);
        IList<Supplier> GetByListCode(List<string> lstCode);
    }
}
