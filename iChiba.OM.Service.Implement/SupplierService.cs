using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Service.Implement
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }
        public Supplier Add(Supplier model)
        {
            return supplierRepository.Add(model);
        }

        public void Delete(Supplier model)
        {
            supplierRepository.Delete(model);
        }

        public Supplier GetById(int id)
        {
            return supplierRepository.FindById(id);
        }

        public IList<Supplier> Gets()
        {
            return supplierRepository.Find().ToList();
        }

        public IList<Supplier> GetHaveAccountId()
        {
            return supplierRepository.Find(new SupplierGetByAccountIdIsNotNull()).ToList();
        }

        public IList<Supplier> GetSuppliers()
        {
            return supplierRepository.Find().Where(x => !string.IsNullOrWhiteSpace(x.AccountId)).ToList();
        }

        public IList<Supplier> Gets(string searchKeyword, string code, string taxcode, string phone, DateTime? StartTime, DateTime? EndTime, bool? active, Sorts sorts, Paging paging)
        {
            return supplierRepository.Find(new SupplierGetBy(searchKeyword, code, taxcode, active, StartTime, EndTime, phone), sorts, paging).ToList();
        }

        public IList<Supplier> GetsSupplierByUID(params string[] uid)
        {
            return supplierRepository.Find(new SupplierGetBy(uid)).ToList();
        }

        public IList<Supplier> GetsSupplierById(params int[] ids)
        {
            return supplierRepository.Find(new SupplierSearchById(ids)).ToList();
        }

        public IList<Supplier> GetsSupplierByCode(params string[] code)
        {
            return supplierRepository.Find(new SupplierSearchByArrCode(code)).ToList();
        }

        public IEnumerable<Supplier> SupplierGetByCodes(params string[] code)
        {
            return supplierRepository.Find(new SupplierGetByCodes(code));
        }


        public IList<Supplier> GetsSupplierBylistCode(List<string> codes,string code)
        {
            return supplierRepository.Find(new SupplierSearchBylstCode(codes, code)).ToList();
        }

        public IList<Supplier> GetsSupplierByObjectCode(params string[] objectCode)
        {
            return supplierRepository.Find(new SupplierGetByObjectCode(objectCode)).ToList();
        }

        public IList<Supplier> GetsSync(string searchKeyword, string code, string taxcode, string phone, DateTime? StartTime, DateTime? EndTime, bool? active, Sorts sorts, Paging paging)
        {
            return supplierRepository.Find(new SupplierSyncGetBy(searchKeyword, code, taxcode, active, StartTime, EndTime, phone), sorts, paging).ToList();
        }

        public Supplier GetDetailSupplierByUID(string uid)
        {
            return supplierRepository.FindSingleBySpec(new SupplierGetBy(uid));
        }

        public IList<Supplier> GetListSupplierByUID(string[] uid)
        {
            return supplierRepository.Find(new SupplierGetBy(uid)).ToList();
        }

        public Supplier GetDetailSupplierByCode(string code)
        {
            return supplierRepository.FindSingleBySpec(new SupplierGetSingerByCode(code));
        }

        public void Update(Supplier model)
        {
            supplierRepository.Update(model);
        }

        public Supplier GetByCode(string code)
        {
            return supplierRepository.FindSingleBySpec(new SupplierGetByCode(code));
        }

        public IList<Supplier> Search(string keyword, Paging paging)
        {
            var spec = new Specification<Supplier>(m => true)
                .AndIf(!string.IsNullOrWhiteSpace(keyword), () => new SupplierSearchByCode(keyword)
                    .Or(new SupplierSearchByEmail(keyword))
                    .Or(new SupplierSearchByName(keyword))
                    .Or(new SupplierSearchByPhone(keyword)));

            return supplierRepository.Find(spec, null, paging).ToList();
        }

        public bool ExistingByAccountId(string accountId)
        {
            return supplierRepository.Find(new SupplierGetByAccountId(accountId)).Any();
        }

        public IList<Supplier> GetListByBuyer(string keyword, Sorts sorts, Paging paging)
        {
            return supplierRepository.Find(new SupplierGetByBuyer(keyword), sorts, paging).ToList();
        }

        public IList<Supplier> GetListByBuyer()
        {
            return supplierRepository.Find().Where(x => x.Buyer == 1).ToList();
        }

        public IList<Supplier> GetListSupplierByAccountId(string accountId)
        {
            return supplierRepository.Find(new GetSupplierGetByAccountId(accountId)).ToList();
        }

        public Supplier GetSingerSupplierByAccountId(string accountId)
        {
            return supplierRepository.FindSingleBySpec(new GetSupplierGetByAccountId(accountId));
        }

        public IList<Supplier> GetListByCode(string code)
        {
            return supplierRepository.Find(new SupplierGetBycode(code)).ToList();
        }

        public IList<Supplier> AutoComplete(string keyword, Sorts sorts, Paging paging)
        {
            return supplierRepository.Find(new SupplierGetByKeyWord(keyword), sorts, paging).ToList();
        }

        public IList<Supplier> GetByAccountIds(params string[] accIds)
        {
            return supplierRepository.Find(new SupplierGetByAccoutIds(accIds)).ToList();
        }

        public Supplier GetSingleByAccountId(string accId)
        {
            return supplierRepository.FindSingleBySpec(new SupplierGetByAccoutIds(accId));
        }

        public Supplier GetByAccountId(string accountId)
        {
            return supplierRepository.Find().Where(x => x.AccountId.Equals(accountId)).FirstOrDefault();
        }

        public IList<Supplier> GetListSupplers(string code)
        {
            return supplierRepository.Find(new SupplierGets(code)).ToList();
        }

        public HashSet<string> ExistsListCode(IEnumerable<string> lstCode)
        {
            return supplierRepository.ExistsListCode(lstCode);
        }

        public IList<Supplier> GetByListCode(List<string> lstCode)
        {
            var spec = new Specification<Supplier>(m => lstCode.Count > 0 && lstCode.Contains(m.Code));
            return supplierRepository.Find(spec).ToList();
        }
    }
}
