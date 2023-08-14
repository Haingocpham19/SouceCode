using Core.Specification.Abstract;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Specification.Implement
{
    public class CustomerGetBy : SpecificationBase<Customer>
    {
        public CustomerGetBy(int[] arrCustomerIds, string searchKeyword, string userName, string email, string phone, string customerName,
            bool? bidActive, string code, string[] arrCustomerByAccountId, string Group, bool? PrePhone, bool? PreEmail, bool? PreCareBy)
            : base(m => (string.IsNullOrEmpty(searchKeyword) ||
            m.Fullname.Contains(searchKeyword) ||
            m.Phone.Contains(searchKeyword) ||
            m.Username.Contains(searchKeyword) ||
            m.Email.Contains(searchKeyword))
            && (string.IsNullOrWhiteSpace(userName) || m.Username.Contains(userName))
            && (string.IsNullOrWhiteSpace(email) || m.Email.Contains(email))
            && (string.IsNullOrWhiteSpace(phone) || m.Phone.Contains(phone))
            && (string.IsNullOrWhiteSpace(Group) || m.Group.Contains(Group))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Equals(code))
            && (string.IsNullOrWhiteSpace(customerName) || m.Fullname.Contains(customerName) || m.IdName.Contains(customerName))
            && (bidActive == null || m.BidActive == bidActive || (bidActive == false && m.BidActive == null))
            && (arrCustomerByAccountId == null || arrCustomerByAccountId.Contains(m.AccountId))
            && (arrCustomerIds == null || arrCustomerIds.Contains(m.Id))
            && (PrePhone == null || (PrePhone == true ? (m.Phone != null && !string.IsNullOrWhiteSpace(m.Phone)) : (m.Phone == null || string.IsNullOrWhiteSpace(m.Phone))))
            && (PreEmail == null || (PreEmail == true ? (m.Email != null && !string.IsNullOrWhiteSpace(m.Email)) : (m.Email == null || string.IsNullOrWhiteSpace(m.Email))))
            && (PreCareBy == null || (PreCareBy == true ? m.CareBy != null : m.CareBy == null))
            )
        {
        }

    }
    public class CustomerGetBySearchAll : SpecificationBase<Customer>
    {
        public CustomerGetBySearchAll(int[] customerIds, string code, string IdAddress, string searchKeyword, string userName, string email, string phone, string customerName, bool? bidActive, bool? tranActive, string[] arrCustomerByAccountId, string Group, bool? PrePhone, bool? PreEmail, bool? PreCareBy, bool? PreAddress, string domain)
            : base(m => (string.IsNullOrEmpty(searchKeyword) ||
            m.Fullname.Contains(searchKeyword) ||
            m.Phone.Contains(searchKeyword) ||
            m.Username.Contains(searchKeyword) ||
            m.Email.Contains(searchKeyword))
            && (string.IsNullOrWhiteSpace(userName) || m.Username.Contains(userName))
            && (customerIds == null || customerIds.Contains(m.Id))
            && (string.IsNullOrWhiteSpace(email) || m.Email.Contains(email))
            && (string.IsNullOrWhiteSpace(IdAddress) || m.IdAddress.Contains(IdAddress))
            && (string.IsNullOrWhiteSpace(phone) || m.Phone.Contains(phone))
            && (string.IsNullOrWhiteSpace(Group) || m.Group.Contains(Group))
            && (string.IsNullOrWhiteSpace(customerName) || m.Fullname.Contains(customerName) || m.IdName.Contains(customerName))
            && (bidActive == null || m.BidActive == bidActive || (bidActive == false && m.BidActive == null))
            && (tranActive == null || m.TranActive == tranActive || (tranActive == false && m.TranActive == null))
            && (arrCustomerByAccountId == null || arrCustomerByAccountId.Contains(m.AccountId))
            && (PrePhone == null || (PrePhone == true ? (m.Phone != null && !string.IsNullOrWhiteSpace(m.Phone)) : (m.Phone == null || string.IsNullOrWhiteSpace(m.Phone))))
            && (PreAddress == null || (PreAddress == true ? (m.IdPermanentAddress != null && !string.IsNullOrWhiteSpace(m.IdPermanentAddress)) : (m.IdPermanentAddress == null || string.IsNullOrWhiteSpace(m.IdPermanentAddress))))
            && (PreEmail == null || (PreEmail == true ? (m.Email != null && !string.IsNullOrWhiteSpace(m.Email)) : (m.Email == null || string.IsNullOrWhiteSpace(m.Email))))
            && (PreCareBy == null || (PreCareBy == true ? m.CareBy != null : m.CareBy == null))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            && (domain.Equals("ICHIBA") ? (string.IsNullOrWhiteSpace(m.Domain) || m.Domain.Contains(domain)) : m.Domain.Contains(domain))
            )
        {
        }

    }
    public class CustomerGetBySearchAllApproved : SpecificationBase<Customer>
    {
        public CustomerGetBySearchAllApproved(string code, string IdAddress, string searchKeyword, string userName, string email, string phone, string customerName, bool? bidActive, bool? tranActive, string[] arrCustomerByAccountId, string Group, bool? PrePhone, bool? PreEmail, bool? PreCareBy, bool? PreAddress, string domain)
            : base(m => (string.IsNullOrEmpty(searchKeyword) ||
            m.Fullname.Contains(searchKeyword) ||
            m.Phone.Contains(searchKeyword) ||
            m.Username.Contains(searchKeyword) ||
            m.Email.Contains(searchKeyword))
            && (string.IsNullOrWhiteSpace(userName) || m.Username.Contains(userName))
            && (string.IsNullOrWhiteSpace(email) || m.Email.Contains(email))
            && (string.IsNullOrWhiteSpace(IdAddress) || m.IdAddress.Contains(IdAddress))
            && (string.IsNullOrWhiteSpace(phone) || m.Phone.Contains(phone))
            && (string.IsNullOrWhiteSpace(Group) || m.Group.Contains(Group))
            && (string.IsNullOrWhiteSpace(customerName) || m.Fullname.Contains(customerName) || m.IdName.Contains(customerName))
            && (bidActive == null || m.BidActive == bidActive || (bidActive == false && m.BidActive == null))
            && (tranActive == null || m.TranActive == tranActive || (tranActive == false && m.TranActive == null))
            && (arrCustomerByAccountId == null || arrCustomerByAccountId.Contains(m.AccountId))
            && (PrePhone == null || (PrePhone == true ? (m.Phone != null && !string.IsNullOrWhiteSpace(m.Phone)) : (m.Phone == null || string.IsNullOrWhiteSpace(m.Phone))))
            && (PreAddress == null || (PreAddress == true ? (m.IdAddress != null && !string.IsNullOrWhiteSpace(m.IdAddress)) : (m.IdAddress == null || string.IsNullOrWhiteSpace(m.IdAddress))))
            && (PreEmail == null || (PreEmail == true ? (m.Email != null && !string.IsNullOrWhiteSpace(m.Email)) : (m.Email == null || string.IsNullOrWhiteSpace(m.Email))))
            && (PreCareBy == null || (PreCareBy == true ? m.CareBy != null : m.CareBy == null))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            //&& (domain.Equals("ICHIBA") ? (string.IsNullOrWhiteSpace(m.Domain) || m.Domain.Contains(domain)) : m.Domain.Contains(domain))
            //&& (!string.IsNullOrWhiteSpace(m.IdImageFront) && !string.IsNullOrWhiteSpace(m.IdImageBack))
            )
        {
        }

    }
    public class SyncCustomerGetBy : SpecificationBase<Customer>
    {
        public SyncCustomerGetBy(int[] arrCustomerIds,string searchKeyword, string userName, string email, string phone, string customerName, bool? bidActive, string code,
            string[] arrCustomerByAccountId, string Group, bool? PrePhone, bool? PreEmail, bool? PreCareBy, int? SyncAccStatus, DateTime? StartTime, DateTime? EndTime, bool? preSyncAccCode)
            : base(m => (string.IsNullOrEmpty(searchKeyword) ||
            m.Fullname.Contains(searchKeyword) ||
            m.Phone.Contains(searchKeyword) ||
            m.Username.Contains(searchKeyword) ||
            m.Email.Contains(searchKeyword))
            && (string.IsNullOrWhiteSpace(userName) || m.Username.Contains(userName))
            && (string.IsNullOrWhiteSpace(email) || m.Email.Contains(email))
            && (string.IsNullOrWhiteSpace(phone) || m.Phone.Contains(phone))
            && (string.IsNullOrWhiteSpace(Group) || m.Group.Contains(Group))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Equals(code))
            && (string.IsNullOrWhiteSpace(customerName) || m.Fullname.Contains(customerName) || m.IdName.Contains(customerName))
            && (bidActive == null || m.BidActive == bidActive || (bidActive == false && m.BidActive == null))
            && (arrCustomerByAccountId == null || arrCustomerByAccountId.Contains(m.AccountId))
            && (PrePhone == null || (PrePhone == true ? (m.Phone != null && !string.IsNullOrWhiteSpace(m.Phone)) : (m.Phone == null || string.IsNullOrWhiteSpace(m.Phone))))
            && (PreEmail == null || (PreEmail == true ? (m.Email != null && !string.IsNullOrWhiteSpace(m.Email)) : (m.Email == null || string.IsNullOrWhiteSpace(m.Email))))
            && (preSyncAccCode == null || (preSyncAccCode == true ? (m.SyncAccCode != null && !string.IsNullOrWhiteSpace(m.SyncAccCode)) : (m.SyncAccCode == null || string.IsNullOrWhiteSpace(m.SyncAccCode))))
            && (PreCareBy == null || (PreCareBy == true ? m.CareBy != null : m.CareBy == null))
            && (m.Code != null)
            && (arrCustomerIds == null || arrCustomerIds.Contains(m.Id))
            && (StartTime == null || m.CodeCreatedDate >= StartTime)
            && (EndTime == null || m.CodeCreatedDate <= EndTime)
            && (SyncAccStatus == null || (SyncAccStatus == 0 ? (m.SyncAccStatus == 0 || m.SyncAccStatus == null) : m.SyncAccStatus == SyncAccStatus))
            )
        {
        }
    }


    public class CustomerGetByDebt : SpecificationBase<Customer>
    {
        public CustomerGetByDebt(string searchKeyword, string userName, string email, string phone, string customerName, bool? bidActive, string[] arrCustomerByAccountId)
            : base(m => (string.IsNullOrEmpty(searchKeyword) ||
            m.Fullname.Contains(searchKeyword) ||
            m.Phone.Contains(searchKeyword) ||
            m.Username.Contains(searchKeyword) ||
            m.Email.Contains(searchKeyword))
            && (!string.IsNullOrEmpty(m.CareBy))
            && (string.IsNullOrWhiteSpace(userName) || m.Username.Contains(userName))
            && (string.IsNullOrWhiteSpace(email) || m.Email.Contains(email))
            && (string.IsNullOrWhiteSpace(phone) || m.Phone.Contains(phone))
            && (string.IsNullOrWhiteSpace(customerName) || m.Fullname.Contains(customerName) || m.IdName.Contains(customerName))
            && (bidActive == null || m.BidActive == bidActive || (bidActive == false && m.BidActive == null))
            && (arrCustomerByAccountId == null || arrCustomerByAccountId.Contains(m.AccountId))
            )
        {
        }

        public CustomerGetByDebt(string searchKeyword, string userName, string email, string phone, string customerName, bool? bidActive, string[] arrCustomerByAccountId, string group, string code = null)
            : base(m => (string.IsNullOrEmpty(searchKeyword) ||
            m.Fullname.Contains(searchKeyword) ||
            m.Phone.Contains(searchKeyword) ||
            m.Username.Contains(searchKeyword) ||
            m.Email.Contains(searchKeyword) ||
            m.Code.Contains(searchKeyword) ||
            m.Group.Contains(searchKeyword))
            && (string.IsNullOrEmpty(code) || m.Code == code)
            && (!string.IsNullOrEmpty(m.CareBy))
            && (string.IsNullOrWhiteSpace(userName) || m.Username.Contains(userName))
            && (string.IsNullOrWhiteSpace(email) || m.Email.Contains(email))
            && (string.IsNullOrWhiteSpace(phone) || m.Phone.Contains(phone))
            && (string.IsNullOrWhiteSpace(customerName) || m.Fullname.Contains(customerName) || m.IdName.Contains(customerName))
            && (bidActive == null || m.BidActive == bidActive || (bidActive == false && m.BidActive == null))
            && (string.IsNullOrWhiteSpace(group) || m.Group.Equals(group))
            && (arrCustomerByAccountId == null || arrCustomerByAccountId.Contains(m.AccountId))
            )
        {
        }
    }

    public class CustomerGetByCare : SpecificationBase<Customer>
    {
        public CustomerGetByCare(string searchKeyword, string userName, string email, string phone, string customerName, bool? bidActive, string code, string careby, string[] arrCustomerByAccountId, string Group, bool? PrePhone, bool? PreEmail)
            : base(m => (string.IsNullOrEmpty(searchKeyword) ||
            m.Fullname.Contains(searchKeyword) ||
            m.Phone.Contains(searchKeyword) ||
            m.Username.Contains(searchKeyword) ||
            m.Email.Contains(searchKeyword) ||
            m.Code.Contains(searchKeyword) ||
            m.Group.Contains(searchKeyword))
            && (string.IsNullOrWhiteSpace(userName) || m.Username.Contains(userName))
            && (string.IsNullOrWhiteSpace(email) || m.Email.Contains(email))
            && (string.IsNullOrWhiteSpace(phone) || m.Phone.Contains(phone))
            && (string.IsNullOrWhiteSpace(Group) || m.Group.Contains(Group))
            && (string.IsNullOrWhiteSpace(customerName) || m.Fullname.Contains(customerName) || m.IdName.Contains(customerName))
            && (bidActive == null || m.BidActive == bidActive || (bidActive == false && m.BidActive == null))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            && (string.IsNullOrWhiteSpace(careby) || m.CareBy.Contains(careby))
            && (arrCustomerByAccountId == null || arrCustomerByAccountId.Contains(m.AccountId))
            && (PrePhone == null || (PrePhone == true ? (m.Phone != null && !string.IsNullOrWhiteSpace(m.Phone)) : (m.Phone == null || string.IsNullOrWhiteSpace(m.Phone))))
            && (PreEmail == null || (PreEmail == true ? (m.Email != null && !string.IsNullOrWhiteSpace(m.Email)) : (m.Email == null || string.IsNullOrWhiteSpace(m.Email))))
            )
        {
        }
    }

    public class CustomerGetByCareAcc : SpecificationBase<Customer>
    {
        public CustomerGetByCareAcc(string searchKeyword, string userName, string email, string phone, string customerName, bool? bidActive, string code, string careby, string[] arrCustomerByAccountId, string Group, bool? PrePhone, bool? PreEmail, bool? preSyncAccCode)
            : base(m => (string.IsNullOrEmpty(searchKeyword) ||
            m.Fullname.Contains(searchKeyword) ||
            m.Phone.Contains(searchKeyword) ||
            m.Username.Contains(searchKeyword) ||
            m.Email.Contains(searchKeyword))
            && (string.IsNullOrWhiteSpace(userName) || m.Username.Contains(userName))
            && (string.IsNullOrWhiteSpace(email) || m.Email.Contains(email))
            && (string.IsNullOrWhiteSpace(phone) || m.Phone.Contains(phone))
            && (string.IsNullOrWhiteSpace(Group) || m.Group.Contains(Group))
            && (string.IsNullOrWhiteSpace(customerName) || m.Fullname.Contains(customerName) || m.IdName.Contains(customerName))
            && (bidActive == null || m.BidActive == bidActive || (bidActive == false && m.BidActive == null))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            && (string.IsNullOrWhiteSpace(careby) || m.CareBy.Contains(careby))
            && (arrCustomerByAccountId == null || arrCustomerByAccountId.Contains(m.AccountId))
            && (PrePhone == null || (PrePhone == true ? (m.Phone != null && !string.IsNullOrWhiteSpace(m.Phone)) : (m.Phone == null || string.IsNullOrWhiteSpace(m.Phone))))
            && (PreEmail == null || (PreEmail == true ? (m.Email != null && !string.IsNullOrWhiteSpace(m.Email)) : (m.Email == null || string.IsNullOrWhiteSpace(m.Email))))
            && (preSyncAccCode == null || (preSyncAccCode == true ? (m.SyncAccCode != null && !string.IsNullOrWhiteSpace(m.SyncAccCode)) : (m.SyncAccCode == null || string.IsNullOrWhiteSpace(m.SyncAccCode))))
            )
        {
        }
    }
    public class CustomerGetBySearch : SpecificationBase<Customer>
    {
        public CustomerGetBySearch(string searchKeyword)
            : base(m => m.Phone.Contains(searchKeyword)
            || m.Username.Contains(searchKeyword)
            || m.Email.Contains(searchKeyword)
            || m.Fullname.Contains(searchKeyword)
            || m.IdName.Contains(searchKeyword))
        {
        }
    }
}
