using Core.Specification.Abstract;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace iChiba.OM.Specification.Implement
{
    public class OrderSearch : SpecificationBase<Order>
    {
        public OrderSearch(string[] orderTypes,
            string keyword,
            string[] accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && (startTime == null || m.OrderDate.Date >= startTime.Value.Date)
                && (endTime == null || m.OrderDate.Date <= endTime.Value.Date)
                && (accountId == null || accountId.Contains(m.AccountId))
            && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
           && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
            ))
        {
        }

        public OrderSearch(string[] orderTypes, string preAccountId,
            string keyword,
            string[] accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && (string.IsNullOrWhiteSpace(preAccountId) || m.AccountId.Contains(preAccountId))
                && (startTime == null || m.OrderDate.Date >= startTime.Value.Date)
                && (endTime == null || accountId.Length == 0 || m.OrderDate.Date <= endTime.Value.Date)
                && (accountId == null || accountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
            ))
        {
        }

        public OrderSearch(string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.LastActionDate >= startTime.Value)
               && (endTime == null || m.LastActionDate <= endTime.Value)
                //&& ((startTime == null || endTime == null) || (m.LastActionDate >= startTime.Value && m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
            ))
        {
        }
        public OrderSearch(string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string payer)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.LastActionDate >= startTime.Value)
               && (endTime == null || m.LastActionDate <= endTime.Value)
                //&& ((startTime == null || endTime == null) || (m.LastActionDate >= startTime.Value && m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
           && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
            ))
        {
        }


        public OrderSearch(string note, string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.PurchaseDate >= startTime.Value)
               && (endTime == null || m.PurchaseDate <= endTime.Value)
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
           && (string.IsNullOrWhiteSpace(note) || m.StatusNote.Contains(note))
           && (string.IsNullOrWhiteSpace(m.Tracking))
            ))
        {
        }
        public OrderSearch(string payer, string shopSell, string note, string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string preCode = null)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.PurchaseDate >= startTime.Value)
               && (endTime == null || m.PurchaseDate <= endTime.Value)
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
           && (string.IsNullOrWhiteSpace(note) || m.StatusNote.Contains(note))
           && (string.IsNullOrWhiteSpace(m.Tracking))
           && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
           && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
           && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
            ))
        {
        }


        public OrderSearch(string shopSell, string note, string[] orderTypes,
          string keyword,
          string accountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, List<string> listBidAccount)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
              && (startTime == null || m.PurchaseDate >= startTime.Value)
              && (endTime == null || m.PurchaseDate <= endTime.Value)
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
              && (string.IsNullOrWhiteSpace(note) || m.StatusNote.Contains(note))
              && (string.IsNullOrWhiteSpace(m.Tracking))
              && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
              && (listBidAccount == null || listBidAccount.Contains(m.BidAccount))
          ))
        {
        }

        public OrderSearch(string[] orderTypes,
          string keyword,
          string[] lstAccountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
              //&& (startTime == null || m.OrderDate.Date >= startTime.Value.Date)
              //&& (endTime == null || m.OrderDate.Date <= endTime.Value.Date)
              && ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
              && (lstAccountId == null || lstAccountId.Length == 0 || lstAccountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
          ))
        {
        }

        public OrderSearch(string[] orderTypes,string[] state, string[] arrCustomerAccountId)
        : base(m => (orderTypes.Contains(m.OrderType))
             && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
             && (state == null || state.Length == 0 || state.Contains(m.State))
         )
        {
        }


        public OrderSearch(string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
            string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
                && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
            ))
        {
        }
        public OrderSearch(string note, string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
            string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
                && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
           && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
            ))
        {
        }
        public OrderSearch(string payer, string shopSell, string note, string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
            string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
                && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
           && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
           && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
           && (string.IsNullOrWhiteSpace(payer) || m.PurchaseAssign.Equals(payer))
            ))
        {
        }
        public OrderSearch(string shopSell, string note, string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
           string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource, List<string> bidAccount)
          : base(m => (
               (string.IsNullOrWhiteSpace(keyword)
                   || m.CustomerName.Contains(keyword)
                   || m.CustomerPhone.Contains(keyword)
                   || m.CustomerProvince.Contains(keyword)
                   || m.CustomerDistrict.Contains(keyword)
                   || m.Title.Contains(keyword)
               )
               && (orderTypes.Contains(m.OrderType))
               && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
               && ((startTime == null) || (m.LastActionDate >= startTime.Value))
               && ((endTime == null) || (m.LastActionDate <= endTime.Value))
               && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
               && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
               && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
               && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
               && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
               && (state == null || state.Length == 0 || state.Contains(m.State))
               && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
              && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
              && (bidAccount == null || bidAccount.Contains(m.BidAccount))
           ))
        {
        }
    }

    public class OrderBuyForYouMH : SpecificationBase<Order>
    {
        public OrderBuyForYouMH(string[] orderTypes,
          string keyword,
          string accountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber, string preCode = null)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
               && ((startTime == null) || (m.LastActionDate >= startTime.Value))
               && ((endTime == null) || (m.LastActionDate <= endTime.Value))
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (string.IsNullOrWhiteSpace(preCode) || (m.Code.StartsWith(preCode)))
              && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
          ))
        {
        }
        public OrderBuyForYouMH(string[] orderTypes,
            string shopSell,
          string keyword,
          string accountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
               && ((startTime == null) || (m.LastActionDate >= startTime.Value))
               && ((endTime == null) || (m.LastActionDate <= endTime.Value))
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
         && (string.IsNullOrWhiteSpace(shopSell) && m.Saler.Contains(shopSell))
          ))
        {
        }
        public OrderBuyForYouMH(string payer, string[] orderTypes,
            string shopSell,
          string keyword,
          string accountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string preCode)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
              && (m.Code.StartsWith(preCode))
               && ((startTime == null) || (m.LastActionDate >= startTime.Value))
               && ((endTime == null) || (m.LastActionDate <= endTime.Value))
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
         && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
         && (string.IsNullOrWhiteSpace(payer) || m.PurchaseAssign.Equals(payer))
          ))
        {
        }
        public OrderBuyForYouMH(string note, string[] orderTypes,
          string keyword,
          string accountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
               && ((startTime == null) || (m.LastActionDate >= startTime.Value))
               && ((endTime == null) || (m.LastActionDate <= endTime.Value))
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
         && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
          ))
        {
        }
        public OrderBuyForYouMH(string shopSell, string note, string[] orderTypes,
          string keyword,
          string accountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
               && ((startTime == null) || (m.LastActionDate >= startTime.Value))
               && ((endTime == null) || (m.LastActionDate <= endTime.Value))
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
         && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
         && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
          ))
        {
        }
        public OrderBuyForYouMH(string payer, string shopSell, string note, string[] orderTypes,
         string keyword,
         string accountId,
         DateTime? startTime,
         DateTime? endTime,
         IList<int> orderIds,
         int[] status,
         string BidAccount,
         string[] state,
         string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string preCode)
        : base(m => (
             (string.IsNullOrWhiteSpace(keyword)
                 || m.CustomerName.Contains(keyword)
                 || m.CustomerPhone.Contains(keyword)
                 || m.CustomerProvince.Contains(keyword)
                 || m.CustomerDistrict.Contains(keyword)
                 || m.Title.Contains(keyword)
             )
            // && (!m.OrderType.Equals("TRANSPORT"))
               && (orderTypes == null || orderTypes.Contains(m.OrderType))
              && ((startTime == null) || (m.LastActionDate >= startTime.Value))
              && ((endTime == null) || (m.LastActionDate <= endTime.Value))
             && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
             && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
             && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
             && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
             && (orderIds == null || orderIds.Contains(m.Id))
             && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
             && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
             && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
             && (state == null || state.Length == 0 || state.Contains(m.State))
             && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
             && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
            && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
            && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
            && (string.IsNullOrWhiteSpace(payer) || m.PurchaseAssign.Equals(payer))
            && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
         ))
        {
        }


        public OrderBuyForYouMH(string shopSell, string note, string[] orderTypes,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderIds,
        int[] status,
        string BidAccount,
        string[] state,
        string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber, List<string> listBidAccount)
       : base(m => (
            (string.IsNullOrWhiteSpace(keyword)
                || m.CustomerName.Contains(keyword)
                || m.CustomerPhone.Contains(keyword)
                || m.CustomerProvince.Contains(keyword)
                || m.CustomerDistrict.Contains(keyword)
                || m.Title.Contains(keyword)
            )
            && (orderTypes.Contains(m.OrderType))
            && ((startTime == null) || (m.LastActionDate >= startTime.Value))
            && ((endTime == null) || (m.LastActionDate <= endTime.Value))
            && (listBidAccount == null || listBidAccount.Contains(m.BidAccount))
            && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
            && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
            && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
            && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
            && (orderIds == null || orderIds.Contains(m.Id))
            && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
            && (state == null || state.Length == 0 || state.Contains(m.State))
            && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
            && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
            && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
            && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
          ))
        {
        }
    }
    public class OrderBuyForYouMHBought : SpecificationBase<Order>
    {
        public OrderBuyForYouMHBought(string note, string[] orderTypes,
              string keyword,
              string accountId,
              DateTime? startTime,
              DateTime? endTime,
              IList<int> orderIds,
              int[] status,
              string BidAccount,
              string[] state,
              string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string preCode)
             : base(m => (
                  (string.IsNullOrWhiteSpace(keyword)
                      || m.CustomerName.Contains(keyword)
                      || m.CustomerPhone.Contains(keyword)
                      || m.CustomerProvince.Contains(keyword)
                      || m.CustomerDistrict.Contains(keyword)
                      || m.Title.Contains(keyword)
                  )
                  && (!m.OrderType.Contains("TRANSPORT"))
                   && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
                   && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
                  && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                  && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                  && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                  && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
                  && (orderIds == null || orderIds.Contains(m.Id))
                  && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                  && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                  && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                  && (state == null || state.Length == 0 || state.Contains(m.State))
                  && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                  && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
                 && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
                 && (m.Tracking == null)
                 && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
              ))
        {
        }





        public OrderBuyForYouMHBought(string shopSell, string note, string[] orderTypes,
              string keyword,
              string accountId,
              DateTime? startTime,
              DateTime? endTime,
              IList<int> orderIds,
              int[] status,
              string BidAccount,
              string[] state,
              string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber)
             : base(m => (
                  (string.IsNullOrWhiteSpace(keyword)
                      || m.CustomerName.Contains(keyword)
                      || m.CustomerPhone.Contains(keyword)
                      || m.CustomerProvince.Contains(keyword)
                      || m.CustomerDistrict.Contains(keyword)
                      || m.Title.Contains(keyword)
                  )
                  && (orderTypes.Contains(m.OrderType))
                   && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
                   && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
                  && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                  && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                  && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                  && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
                  && (orderIds == null || orderIds.Contains(m.Id))
                  && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                  && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                  && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                  && (state == null || state.Length == 0 || state.Contains(m.State))
                  && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                  && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
             && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
             && (m.Tracking == null)
             && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
              ))
        {
        }

        public OrderBuyForYouMHBought(string payer, string shopSell, string note, string[] orderTypes,
              string keyword,
              string accountId,
              DateTime? startTime,
              DateTime? endTime,
              IList<int> orderIds,
              int[] status,
              string BidAccount,
              string[] state,
              string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string preCode)
             : base(m => (
                  (string.IsNullOrWhiteSpace(keyword)
                      || m.CustomerName.Contains(keyword)
                      || m.CustomerPhone.Contains(keyword)
                      || m.CustomerProvince.Contains(keyword)
                      || m.CustomerDistrict.Contains(keyword)
                      || m.Title.Contains(keyword)
                  )
                  && (!m.OrderType.Equals("TRANSPORT"))
                  && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
                  && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
                  && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                  && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                  && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                  && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
                  && (orderIds == null || orderIds.Contains(m.Id))
                  && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                  && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                  && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                  && (state == null || state.Length == 0 || state.Contains(m.State))
                  && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                  && (string.IsNullOrWhiteSpace(preCode) || (m.Code.StartsWith(preCode)))
                  && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
                 && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
                 && (m.Tracking == null)
                 && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
                 && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
              ))
        {
        }

    }

    public class OrderBuyForYouMHSurcharge : SpecificationBase<Order>
    {
        public OrderBuyForYouMHSurcharge(string payer, string note, string orderTypes,
          string keyword,
          string accountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string preCode, string preCodeVC,string searchOrder)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (!m.OrderType.Contains("TRANSPORT"))
              && (orderTypes == null || orderTypes.Contains(m.OrderType))
              && ((startTime == null) || (m.LastActionDate >= startTime.Value))
              && ((endTime == null) || (m.LastActionDate <= endTime.Value))
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
              && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
              && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
              && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
              && (string.IsNullOrWhiteSpace(searchOrder) || m.Code.StartsWith(searchOrder))
          ))
        {
        }

        public OrderBuyForYouMHSurcharge(string payer, string note, string orderTypes,
         string keyword,
         string accountId,
         string purchaseAssign,
         DateTime? startTime,
         DateTime? endTime,
         IList<int> orderIds,
         int[] status,
         string BidAccount,
         string[] state,
         string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string preCode, string preCodeVC, string searchOrder)
        : base(m => (
             (string.IsNullOrWhiteSpace(keyword)
                 || m.CustomerName.Contains(keyword)
                 || m.CustomerPhone.Contains(keyword)
                 || m.CustomerProvince.Contains(keyword)
                 || m.CustomerDistrict.Contains(keyword)
                 || m.Title.Contains(keyword)
             )
             && (string.IsNullOrWhiteSpace(orderTypes) || m.OrderType.Contains(orderTypes))
             && ((startTime == null) || (m.LastActionDate >= startTime.Value))
             && ((endTime == null) || (m.LastActionDate <= endTime.Value))
             && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
             && (m.PurchaseAssign.Contains(purchaseAssign))
             && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
             && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
             && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
             && (orderIds == null || orderIds.Contains(m.Id))
             && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
             && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
             && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
             && (state == null || state.Length == 0 || state.Contains(m.State))
             && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
             && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
             && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
             && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
             && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode) || m.Code.StartsWith(preCodeVC))
             && (string.IsNullOrWhiteSpace(searchOrder) || m.Code.StartsWith(searchOrder))
         ))
        {
        }
    }



    public class OrderBuyForYouMHTransport : SpecificationBase<Order>
    {
        public OrderBuyForYouMHTransport(
            string note,
            string[] orderTypes,
          string keyword,
          string accountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
               && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
               && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
            && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
            && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
          ))
        {
        }
        public OrderBuyForYouMHTransport(
            string payer,
            string shopSell,
           string note,
           string[] orderTypes,
         string keyword,
         string accountId,
         DateTime? startTime,
         DateTime? endTime,
         IList<int> orderIds,
         int[] status,
         string BidAccount,
         string[] state,
         string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string PreCode)
        : base(m => (
             (string.IsNullOrWhiteSpace(keyword)
                 || m.CustomerName.Contains(keyword)
                 || m.CustomerPhone.Contains(keyword)
                 || m.CustomerProvince.Contains(keyword)
                 || m.CustomerDistrict.Contains(keyword)
                 || m.Title.Contains(keyword)
             )
              && (!m.OrderType.Equals("TRANSPORT"))
              && (orderTypes == null || orderTypes.Contains(m.OrderType))
              && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
              && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
             && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
             && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
             && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
             && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
             && (orderIds == null || orderIds.Contains(m.Id))
             && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
             && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
             && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
             && (state == null || state.Length == 0 || state.Contains(m.State))
             && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
             && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
             && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
            && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
            && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
            && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
            && (string.IsNullOrWhiteSpace(PreCode) || m.Code.StartsWith(PreCode))
         ))
        {
        }
    }

    public class OrderMercari : SpecificationBase<Order>
    {
        public OrderMercari(string[] orderTypes,
          string keyword,
          string accountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
               && ((startTime == null) || (m.OrderDate >= startTime.Value))
               && ((endTime == null) || (m.OrderDate <= endTime.Value))
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
          ))
        {
        }
        public OrderMercari(string payer, string[] orderTypes,
          string keyword,
          string accountId,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
               && ((startTime == null) || (m.OrderDate >= startTime.Value))
               && ((endTime == null) || (m.OrderDate <= endTime.Value))
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
          ))
        {
        }
    }
    public class OrderSearchTransport : SpecificationBase<Order>
    {

        public OrderSearchTransport(
            string note,
            string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code,
            string tracking,
            string PreState,
            string[] arrCustomerAccountId,
            int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.PurchaseDate >= startTime.Value)
               && (endTime == null || m.PurchaseDate <= endTime.Value)
                //&& ((startTime == null || endTime == null) || (m.LastActionDate >= startTime.Value && m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
           && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
           && (string.IsNullOrWhiteSpace(note) || m.StatusNote.Contains(note))
           && (!string.IsNullOrWhiteSpace(m.Tracking))
            ))
        {
        }
        public OrderSearchTransport(
            string payer,
            string shopSell,
            string note,
            string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code,
            string tracking,
            string PreState,
            string[] arrCustomerAccountId,
            int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.PurchaseDate >= startTime.Value)
               && (endTime == null || m.PurchaseDate <= endTime.Value)
                //&& ((startTime == null || endTime == null) || (m.LastActionDate >= startTime.Value && m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
           && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
           && (string.IsNullOrWhiteSpace(note) || m.StatusNote.Contains(note))
           && (!string.IsNullOrWhiteSpace(m.Tracking))
           && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
           && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
            ))
        {
        }
    }
    public class OrderSearchTracking : SpecificationBase<Order>
    {
        public OrderSearchTracking(string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.LastActionDate >= startTime.Value)
               && (endTime == null || m.LastActionDate <= endTime.Value)
                //&& ((startTime == null || endTime == null) || (m.LastActionDate >= startTime.Value && m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
           && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
            ))
        {
        }
        public OrderSearchTracking(string payer, string shopSell, string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.LastActionDate >= startTime.Value)
               && (endTime == null || m.LastActionDate <= endTime.Value)
                //&& ((startTime == null || endTime == null) || (m.LastActionDate >= startTime.Value && m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
           && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
           && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
           && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
            ))
        {
        }

    }
    public class OrderSearchNoTracking : SpecificationBase<Order>
    {
        public OrderSearchNoTracking(string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.PurchaseDate >= startTime.Value)
               && (endTime == null || m.PurchaseDate <= endTime.Value)
                //&& ((startTime == null || endTime == null) || (m.LastActionDate >= startTime.Value && m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
           && (string.IsNullOrWhiteSpace(m.Tracking))
            ))
        {
        }
        public OrderSearchNoTracking(string shopSell, string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.PurchaseDate >= startTime.Value)
               && (endTime == null || m.PurchaseDate <= endTime.Value)
                //&& ((startTime == null || endTime == null) || (m.LastActionDate >= startTime.Value && m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
           && (string.IsNullOrWhiteSpace(m.Tracking))
           && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
            ))
        {
        }
        public OrderSearchNoTracking(string payer, string shopSell, string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && (startTime == null || m.PurchaseDate >= startTime.Value)
                && (endTime == null || m.PurchaseDate <= endTime.Value)
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
                && (string.IsNullOrWhiteSpace(m.Tracking))
                && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
                && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
            ))
        {
        }
    }
    public class OrderSearchMercariTracking : SpecificationBase<Order>
    {
        public OrderSearchMercariTracking(string note, string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
            string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
                && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
           && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
           && (!string.IsNullOrWhiteSpace(m.Tracking))
           && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
            ))
        {
        }
        public OrderSearchMercariTracking(string shopSell, string note, string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
            string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
                && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
           && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
           && (!string.IsNullOrWhiteSpace(m.Tracking))
           && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
           && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
            ))
        {
        }
    }
    public class OrderSearchMercari : SpecificationBase<Order>
    {
        public OrderSearchMercari(string note, string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
            string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
                && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
           && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
           && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
            ))
        {
        }
        public OrderSearchMercari(string shopSell, string note, string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
            string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
                && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
           && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
           && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
           && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
            ))
        {
        }
        public OrderSearchMercari(string payer, string shopSell, string note, string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
            string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
                && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
                && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
                && (string.IsNullOrWhiteSpace(payer) || m.PurchaseAssign.Equals(payer))
            ))
        {
        }

        public OrderSearchMercari(string shopSell, string note, string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
           string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource, List<string> bidAccount)
          : base(m => (
               (string.IsNullOrWhiteSpace(keyword)
                   || m.CustomerName.Contains(keyword)
                   || m.CustomerPhone.Contains(keyword)
                   || m.CustomerProvince.Contains(keyword)
                   || m.CustomerDistrict.Contains(keyword)
                   || m.Title.Contains(keyword)
               )
               && (orderTypes.Contains(m.OrderType))
               && ((startTime == null) || (m.LastActionDate >= startTime.Value))
               && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
               && ((endTime == null) || (m.LastActionDate <= endTime.Value))
               && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
               && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
               && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
               && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
               && (state == null || state.Length == 0 || state.Contains(m.State))
               && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
              && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
              && (bidAccount == null || bidAccount.Contains(m.BidAccount))
           ))
        {
        }
    }


    public class SurchargeMercariGetBy : SpecificationBase<Order>
    {
        public SurchargeMercariGetBy(string payer, string shopSell, string note, string orderTypes, string keyword, string accountId, DateTime? startTime, DateTime? endTime, int[] status,
              string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId)
             : base(m => (
                  (string.IsNullOrWhiteSpace(keyword)
                      || m.CustomerName.Contains(keyword)
                      || m.CustomerPhone.Contains(keyword)
                      || m.CustomerProvince.Contains(keyword)
                      || m.CustomerDistrict.Contains(keyword)
                      || m.Title.Contains(keyword)
                  )
                  && (orderTypes.Contains(m.OrderType))
                  && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                  && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                  && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                  && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                  && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                  && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                  && (state == null || state.Length == 0 || state.Contains(m.State))
                  && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
             && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
             && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
             && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
             && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
              ))
        {
        }
    }




    public class OrderSearchKeywordGetByCustomerName : SpecificationBase<Order>
    {
        public OrderSearchKeywordGetByCustomerName(string keyword)
            : base(m => m.CustomerName.Contains(keyword))
        {
        }
    }
    public class OrderSearchKeywordGetByCustomerPhone : SpecificationBase<Order>
    {
        public OrderSearchKeywordGetByCustomerPhone(string keyword)
            : base(m => m.CustomerPhone.Contains(keyword))
        {
        }
    }
    public class OrderSearchKeywordGetByCustomerProvince : SpecificationBase<Order>
    {
        public OrderSearchKeywordGetByCustomerProvince(string keyword)
            : base(m => m.CustomerProvince.Contains(keyword))
        {
        }
    }
    public class OrderSearchKeywordGetByCustomerDistrict : SpecificationBase<Order>
    {
        public OrderSearchKeywordGetByCustomerDistrict(string keyword)
            : base(m => m.CustomerDistrict.Contains(keyword))
        {
        }
    }
    public class OrderSearchKeywordGetByTitle : SpecificationBase<Order>
    {
        public OrderSearchKeywordGetByTitle(string keyword)
            : base(m => m.Title.Contains(keyword))
        {
        }
    }
    public class OrderSearchGetByOrderType : SpecificationBase<Order>
    {
        public OrderSearchGetByOrderType(string[] orderTypes)
            : base(m => orderTypes.Contains(m.OrderType))
        {
        }
    }
    public class OrderSearchGetByStartTime : SpecificationBase<Order>
    {
        public OrderSearchGetByStartTime(DateTime? startTime)
            : base(m => startTime == null || m.LastActionDate >= startTime.Value)
        {
        }
    }
    public class OrderSearchGetByEndTime : SpecificationBase<Order>
    {
        public OrderSearchGetByEndTime(DateTime? endTime)
            : base(m => endTime == null || m.LastActionDate <= endTime.Value)
        {
        }
    }
    public class OrderSearchGetByAccountId : SpecificationBase<Order>
    {
        public OrderSearchGetByAccountId(string accoutnId)
            : base(m => m.AccountId.Contains(accoutnId))
        {
        }
    }
    public class OrderSearchGetByListOrderIds : SpecificationBase<Order>
    {
        public OrderSearchGetByListOrderIds(IList<int> orderIds)
            : base(m => orderIds == null || orderIds.Contains(m.Id))
        {
        }
    }
    public class OrderSearchGetByStatus : SpecificationBase<Order>
    {
        public OrderSearchGetByStatus(int[] status)
            : base(m => status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        {
        }
    }
    public class OrderSearchGetByBidAccount : SpecificationBase<Order>
    {
        public OrderSearchGetByBidAccount(string bidAccount)
            : base(m => string.IsNullOrWhiteSpace(bidAccount) || m.BidAccount == bidAccount)
        {
        }
    }
    public class OrderSearchGetByState : SpecificationBase<Order>
    {
        public OrderSearchGetByState(string[] state)
            : base(m => state == null || state.Length == 0 || state.Contains(m.State))
        {
        }
    }
    public class OrderSearchGetByCode : SpecificationBase<Order>
    {
        public OrderSearchGetByCode(string code)
            : base(m => m.Code.Contains(code))
        {
        }
    }
    public class OrderSearchGetByTracking : SpecificationBase<Order>
    {
        public OrderSearchGetByTracking(string tracking)
            : base(m => tracking == null || m.Tracking.Contains(tracking))
        {
        }
    }
    public class OrderSearchGetByPreState : SpecificationBase<Order>
    {
        public OrderSearchGetByPreState(string preState)
            : base(m => string.IsNullOrWhiteSpace(preState) || (m.State.Contains(preState)))
        {
        }
    }
    public class OrderSearchGetByListCusAccountId : SpecificationBase<Order>
    {
        public OrderSearchGetByListCusAccountId(string[] arrCustomerAccountId)
            : base(m => arrCustomerAccountId == null || arrCustomerAccountId.Contains(m.AccountId))
        {
        }
    }
    public class OrderSearchGetByStatusTracking : SpecificationBase<Order>
    {
        public OrderSearchGetByStatusTracking(int? statusTracking)
            : base(m => statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
        {
        }
    }
    public class OrderSearchGetByNote : SpecificationBase<Order>
    {
        public OrderSearchGetByNote(string note)
            : base(m => string.IsNullOrWhiteSpace(note) || m.StatusNote.Contains(note))
        {
        }
    }
    public class OrderSearchGetByListOrderType : SpecificationBase<Order>
    {
        public OrderSearchGetByListOrderType(string[] orderTypes)
            : base(m => orderTypes.Contains(m.OrderType))
        {
        }
    }
    public class OrderSearchGetByOrderNumber : SpecificationBase<Order>
    {
        public OrderSearchGetByOrderNumber(string orderNumber)
            : base(m => m.OrderNumber.Contains(orderNumber))
        {
        }
    }

    public class OrderSearchGetByOrderCodes : SpecificationBase<Order>
    {
        public OrderSearchGetByOrderCodes(string[] orderCodes)
            : base(m => orderCodes.Contains(m.Code))
        {
        }

        public OrderSearchGetByOrderCodes(string[] orderCodes,int? shippingRouteId)
          : base(m => orderCodes.Contains(m.Code) && (shippingRouteId == null || m.ShippingRouteId.Equals(shippingRouteId)))
        {
        }
    }

    public class OrderGetByOrderCode : SpecificationBase<Order>
    {
        public OrderGetByOrderCode(string orderCode)
            : base(m => orderCode.Equals(m.Code))
        {
        }
    }


    public class OrderGetBy : SpecificationBase<Order>
    {
        public OrderGetBy(List<int> Id, string state, string accountId,string orderCode,string productName)
            : base(m => Id.Contains(m.Id) && (m.State.Equals(state)) && (string.IsNullOrWhiteSpace(m.GroupOrder)) && m.AccountId.Equals(accountId) && (string.IsNullOrWhiteSpace(orderCode) ||m.Code.Equals(orderCode)) && (string.IsNullOrWhiteSpace(productName) || m.Title.Contains(productName)))
        {
        }
    }

    public class OrderBuyForYouBoughtGetBy : SpecificationBase<Order>
    {
        public OrderBuyForYouBoughtGetBy(List<int> Id, string state, string accountId, string orderCode, string productName)
            : base(m => Id.Contains(m.Id) 
              && (m.State.Equals(state)) 
              && (string.IsNullOrWhiteSpace(m.GroupOrder)) 
              && m.AccountId.Equals(accountId) && (string.IsNullOrWhiteSpace(orderCode) || m.Code.Equals(orderCode))
              && (string.IsNullOrWhiteSpace(productName) || m.Title.Contains(productName)) && string.IsNullOrWhiteSpace(m.Tracking))
        {
        }
    }


    public class OrderSearchAll : Specification<Order>
    {
        public OrderSearchAll(string payer, string[] orderTypes,
                string keyword,
                string accountId,
                DateTime? startTime,
                DateTime? endTime,
                IList<int> orderIds,
                int[] status,
                string BidAccount,
                string[] state,
                string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
               : base(m => (
                    (string.IsNullOrWhiteSpace(keyword)
                        || m.CustomerName.Contains(keyword)
                        || m.CustomerPhone.Contains(keyword)
                        || m.CustomerProvince.Contains(keyword)
                        || m.CustomerDistrict.Contains(keyword)
                        || m.Title.Contains(keyword)
                    )
                    && (orderTypes.Contains(m.OrderType))
                   && (startTime == null || m.LastActionDate >= startTime.Value)
                   && (endTime == null || m.LastActionDate <= endTime.Value)
                    //&& ((startTime == null || endTime == null) || (m.LastActionDate >= startTime.Value && m.LastActionDate <= endTime.Value))
                    && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                    && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                    && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                    //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                    && (orderIds == null || orderIds.Contains(m.Id))
                    && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                    && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                    && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                    && (state == null || state.Length == 0 || state.Contains(m.State))
                    && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                   && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
              && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
                ))
        {
        }
    }
    public class OrderSearchByPurchaseBy : Specification<Order>
    {
        public OrderSearchByPurchaseBy(string payer, string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.LastActionDate >= startTime.Value)
               && (endTime == null || m.LastActionDate <= endTime.Value)
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
           && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
            ))
        {
        }
    }
    public class OrderBuyForYouAddNew : Specification<Order>
    {
        public OrderBuyForYouAddNew(
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking,string preCode)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (!m.OrderType.Equals("TRANSPORT"))
                && (startTime == null || m.LastActionDate >= startTime.Value)
                && (endTime == null || m.LastActionDate <= endTime.Value)
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
            ))
        {
        }
    }
    public class OrderSearchGetByPurchaseBy : Specification<Order>
    {
        public OrderSearchGetByPurchaseBy(string payer, string[] orderTypes,
            string keyword,
            string[] accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && (startTime == null || m.OrderDate.Date >= startTime.Value.Date)
                && (endTime == null || m.OrderDate.Date <= endTime.Value.Date)
                && (accountId == null || accountId.Contains(m.AccountId))
            && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                && (orderIds == null || orderIds.Contains(m.Id))
           && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
            ))
        {
        }
    }
    public class OrderSearchMercariPurchaseBy : Specification<Order>
    {
        public OrderSearchMercariPurchaseBy(string payer, string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
               && (startTime == null || m.LastActionDate >= startTime.Value)
               && (endTime == null || m.LastActionDate <= endTime.Value)
                //&& ((startTime == null || endTime == null) || (m.LastActionDate >= startTime.Value && m.LastActionDate <= endTime.Value))
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                //&& (orderIds != null ? orderIds.Any(o => o == m.Id) : m.Id > 0)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
               && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
           && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
            ))
        {
        }
    }
    public class OrderSearchBuyForYouPurchaseBy : Specification<Order>
    {
        public OrderSearchBuyForYouPurchaseBy(string payer, string[] orderTypes,
            string keyword,
            string accountId,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderIds,
            int[] status,
            string BidAccount,
            string[] state,
            string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking)
           : base(m => (
                (string.IsNullOrWhiteSpace(keyword)
                    || m.CustomerName.Contains(keyword)
                    || m.CustomerPhone.Contains(keyword)
                    || m.CustomerProvince.Contains(keyword)
                    || m.CustomerDistrict.Contains(keyword)
                    || m.Title.Contains(keyword)
                )
                && (orderTypes.Contains(m.OrderType))
                && (startTime == null || m.LastActionDate >= startTime.Value)
                && (endTime == null || m.LastActionDate <= endTime.Value)
                && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                && (orderIds == null || orderIds.Contains(m.Id))
                && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
               && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
            ))
        {
        }
    }

    public class OrderSearchBuyForYouByPurchaseAssign : Specification<Order>
    {
        public OrderSearchBuyForYouByPurchaseAssign(string payer, string shopSell, string note, string[] orderTypes,
               string keyword,
               string accountId,
               string purchaseAssign,
               DateTime? startTime,
               DateTime? endTime,
               IList<int> orderIds,
               int[] status,
               string BidAccount,
               string[] state,
               string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string preCode,string bidAccount)
              : base(m => (
                   (string.IsNullOrWhiteSpace(keyword)
                       || m.CustomerName.Contains(keyword)
                       || m.CustomerPhone.Contains(keyword)
                       || m.CustomerProvince.Contains(keyword)
                       || m.CustomerDistrict.Contains(keyword)
                       || m.Title.Contains(keyword)
                   )
                   //&& (!m.OrderType.Equals("TRANSPORT"))
                   && (orderTypes == null || orderTypes.Contains(m.OrderType))
                   && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
                   && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
                   && (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Contains(accountId))
                   && (m.PurchaseAssign.Contains(purchaseAssign))
                   && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                   && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                   && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
                   && (orderIds == null || orderIds.Contains(m.Id))
                   && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                   && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                   && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                   && (state == null || state.Length == 0 || state.Contains(m.State))
                   && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                   && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
                   && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
                   && (m.Code.StartsWith(preCode))
                   && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
                   && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
                   && (string.IsNullOrWhiteSpace(bidAccount) || m.BidAccount.Equals(bidAccount))
               ))
        {
        }

        public OrderSearchBuyForYouByPurchaseAssign(string payer, string shopSell, string note, string orderTypes, string keyword, string accountId, string purchaseAssign, DateTime? startTime, DateTime? endTime, int[] status,
           string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId, string preResource)
          : base(m => (
               (string.IsNullOrWhiteSpace(keyword)
                   || m.CustomerName.Contains(keyword)
                   || m.CustomerPhone.Contains(keyword)
                   || m.CustomerProvince.Contains(keyword)
                   || m.CustomerDistrict.Contains(keyword)
                   || m.Title.Contains(keyword)
               )
               && (orderTypes.Contains(m.OrderType))
               && ((startTime == null) || (m.LastActionDate >= startTime.Value))
               && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
               && ((endTime == null) || (m.LastActionDate <= endTime.Value))
               && (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Contains(accountId))
               && (m.PurchaseAssign.Contains(purchaseAssign))
               && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
               && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
               && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
               && (state == null || state.Length == 0 || state.Contains(m.State))
               && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
              && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
              && (string.IsNullOrWhiteSpace(payer) || m.PurchaseAssign.Equals(payer))
           ))
        {
        }
    }


    public class PurchasedBuyForYouPurchaseAssign : Specification<Order>
    {
        public PurchasedBuyForYouPurchaseAssign(string payer, string shopSell, string note, string[] orderTypes,
             string keyword,
             string accountId,
             string purchaseAssign,
             DateTime? startTime,
             DateTime? endTime,
             IList<int> orderIds,
             int[] status,
             string BidAccount,
             string[] state,
             string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber)
            : base(m => (
                 (string.IsNullOrWhiteSpace(keyword)
                     || m.CustomerName.Contains(keyword)
                     || m.CustomerPhone.Contains(keyword)
                     || m.CustomerProvince.Contains(keyword)
                     || m.CustomerDistrict.Contains(keyword)
                     || m.Title.Contains(keyword)
                 )
                 && (orderTypes.Contains(m.OrderType))
                 && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
                 && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
                 && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                 && (m.PurchaseAssign.Contains(purchaseAssign))
                 && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                 && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                 && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
                 && (orderIds == null || orderIds.Contains(m.Id))
                 && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                 && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                 && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                 && (state == null || state.Length == 0 || state.Contains(m.State))
                 && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                 && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
                && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
                && (m.Tracking == null)
                && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
                && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
             ))
        {
        }
    }


    public class PurchasedBuyForYouPurchaseBy : Specification<Order>
    {
        public PurchasedBuyForYouPurchaseBy(string payer, string shopSell, string note, string[] orderTypes,
             string keyword,
             string accountId,
             string purchaseAssign,
             DateTime? startTime,
             DateTime? endTime,
             IList<int> orderIds,
             int[] status,
             string BidAccount,
             string[] state,
             string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber)
            : base(m => (
                 (string.IsNullOrWhiteSpace(keyword)
                     || m.CustomerName.Contains(keyword)
                     || m.CustomerPhone.Contains(keyword)
                     || m.CustomerProvince.Contains(keyword)
                     || m.CustomerDistrict.Contains(keyword)
                     || m.Title.Contains(keyword)
                 )
                 && (orderTypes.Contains(m.OrderType))
                 && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
                 && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
                 && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                 && (m.PurchaseBy.Contains(purchaseAssign))
                 && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                 && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                 && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
                 && (orderIds == null || orderIds.Contains(m.Id))
                 && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                 && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                 && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                 && (state == null || state.Length == 0 || state.Contains(m.State))
                 && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                 && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
                && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
                && (m.Tracking == null)
                && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
                && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
             ))
        {
        }
    }

    public class PurchasedTransportByPurchaseAssign : Specification<Order>
    {
        public PurchasedTransportByPurchaseAssign(
         string payer,
         string shopSell,
         string note,
         string[] orderTypes,
          string keyword,
          string accountId,
          string purchaseAssign,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderIds,
          int[] status,
          string BidAccount,
          string[] state,
          string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string preCode)
         : base(m => (
              (string.IsNullOrWhiteSpace(keyword)
                  || m.CustomerName.Contains(keyword)
                  || m.CustomerPhone.Contains(keyword)
                  || m.CustomerProvince.Contains(keyword)
                  || m.CustomerDistrict.Contains(keyword)
                  || m.Title.Contains(keyword)
              )
              && (orderTypes.Contains(m.OrderType))
               && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
               && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
              && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
              && (m.PurchaseAssign.Contains(purchaseAssign))
              && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
              && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
              && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
              && (orderIds == null || orderIds.Contains(m.Id))
              && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
              && (state == null || state.Length == 0 || state.Contains(m.State))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
             && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
             && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
             && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
             && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
             && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
          ))
        {
        }
    }

    public class SurchargeMercariGetByPurchaseAssign : SpecificationBase<Order>
    {
        public SurchargeMercariGetByPurchaseAssign(string payer, string shopSell, string note, string orderTypes, string keyword, string accountId, string userId, DateTime? startTime, DateTime? endTime, int[] status,
              string[] state, string code, string tracking, string PreState, string[] arrCustomerAccountId)
             : base(m => (
                  (string.IsNullOrWhiteSpace(keyword)
                      || m.CustomerName.Contains(keyword)
                      || m.CustomerPhone.Contains(keyword)
                      || m.CustomerProvince.Contains(keyword)
                      || m.CustomerDistrict.Contains(keyword)
                      || m.Title.Contains(keyword)
                  )
                  && (orderTypes.Contains(m.OrderType))
                  && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                  && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                  && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                  && (m.PurchaseAssign.Contains(userId))
                  && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                  && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                  && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                  && (state == null || state.Length == 0 || state.Contains(m.State))
                  && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
             && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
             && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
             && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
             && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
              ))
        {
        }
    }

    public class PurchaseWaitingOrderBuyForYou : Specification<Order>
    {
        public PurchaseWaitingOrderBuyForYou(string payer, string shopSell, string note, string[] orderTypes,
               string keyword,
               string accountId,
               DateTime? startTime,
               DateTime? endTime,
               IList<int> orderIds,
               int[] status,
               string BidAccount,
               string[] state,
               string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string preCode)
              : base(m => (
                   (string.IsNullOrWhiteSpace(keyword)
                       || m.CustomerName.Contains(keyword)
                       || m.CustomerPhone.Contains(keyword)
                       || m.CustomerProvince.Contains(keyword)
                       || m.CustomerDistrict.Contains(keyword)
                       || m.Title.Contains(keyword)
                   )
                   && (!m.OrderType.Equals("TRANSPORT"))
                   && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                   && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                   && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                   && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                   && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                   && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
                   && (orderIds == null || orderIds.Contains(m.Id))
                   && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                   && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                   && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                   && (state == null || state.Length == 0 || state.Contains(m.State))
                   && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                   && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
                  && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
                  //&& (m.Tracking == null)
                  && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
                  && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
                  && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
               ))
        {
        }
    }


    public class CustomerDebtGetBy : Specification<Order>
    {
        public CustomerDebtGetBy(string accountId)
              : base(m => ((m.AccountId.Equals(accountId)) && (!string.IsNullOrWhiteSpace(m.QuoteCode))))
        {
        }
    }

    public class CustomerDebtGetByOrderDeposites : Specification<Order>
    {
        public CustomerDebtGetByOrderDeposites(string accountId)
              : base(m => ((m.AccountId.Equals(accountId)) && (string.IsNullOrWhiteSpace(m.QuoteCode)) && (m.Paid > 0) && m.State != "KET_THUC_DON_HANG"))
        {
        }
    }

    public class GetOrderByQuotesCode : Specification<Order>
    {
        public GetOrderByQuotesCode(string accountId, string quotesCode, string code, string title, string[] state, int[] status, string orderType)
              : base(m => ((m.AccountId.Equals(accountId)) && (m.QuoteCode.Contains(quotesCode)) && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code)) && (string.IsNullOrWhiteSpace(title) || m.Title.Contains(title)) && (state == null || state.Length == 0 || state.Contains(m.State)) && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value))) && (string.IsNullOrWhiteSpace(orderType) || m.OrderType.Contains(orderType))))
        {
        }
    }
    public class TotalBuyForYou : Specification<Order>
    {
        public TotalBuyForYou(string[] orderTypes, string PreState)
        : base(m =>
             orderTypes.Contains(m.OrderType)
             && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
         )
        {
        }
        public TotalBuyForYou(string payer, string[] orderTypes, string PreState)
        : base(m =>
             orderTypes.Contains(m.OrderType)
             && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
            && (m.PurchaseAssign.Equals(payer))
         )
        {
        }
    }
    public class TotalBuyForYouBought : Specification<Order>
    {
        public TotalBuyForYouBought(string[] orderTypes, string PreState)
        : base(m =>
             orderTypes.Contains(m.OrderType)
             && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
            && (string.IsNullOrWhiteSpace(m.Tracking))
         )
        {
        }
        public TotalBuyForYouBought(string payer, string[] orderTypes, string PreState)
        : base(m =>
             orderTypes.Contains(m.OrderType)
             && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
            && (m.PurchaseBy.Equals(payer))
            && (string.IsNullOrWhiteSpace(m.Tracking))
         )
        {
        }
    }
    public class PurchaseWaitingOrderBuyForYouPurchaseAssign : Specification<Order>
    {
        public PurchaseWaitingOrderBuyForYouPurchaseAssign(string payer, string shopSell, string note, string[] orderTypes,
               string keyword,
               string accountId,
               DateTime? startTime,
               DateTime? endTime,
               IList<int> orderIds,
               int[] status,
               string BidAccount,
               string[] state,
               string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string orderNumber,string preCode,string bidAccount)
              : base(m => (
                   (string.IsNullOrWhiteSpace(keyword)
                       || m.CustomerName.Contains(keyword)
                       || m.CustomerPhone.Contains(keyword)
                       || m.CustomerProvince.Contains(keyword)
                       || m.CustomerDistrict.Contains(keyword)
                       || m.Title.Contains(keyword)
                   )
                   //&& (!m.OrderType.Equals("TRANSPORT"))
                   && (orderTypes == null || orderTypes.Contains(m.OrderType))
                   && ((startTime == null) || (m.LastActionDate >= startTime.Value))
                   && ((endTime == null) || (m.LastActionDate <= endTime.Value))
                   && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
                   && (arrCustomerAccountId == null || arrCustomerAccountId.Length == 0 || arrCustomerAccountId.Contains(m.AccountId))
                   && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount == BidAccount)
                   && (string.IsNullOrWhiteSpace(orderNumber) || m.OrderNumber.Contains(orderNumber))
                   && (orderIds == null || orderIds.Contains(m.Id))
                   && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Contains(tracking))
                   && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
                   && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
                   && (state == null || state.Length == 0 || state.Contains(m.State))
                   && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
                   && (statusTracking == null || (statusTracking == 0 ? (m.Tracking == null && string.IsNullOrWhiteSpace(m.Tracking)) : (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))))
                  && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note) || m.StatusNote.Contains(note))
                  && (m.Code.StartsWith(preCode))
                  && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
                  && (string.IsNullOrWhiteSpace(payer) || m.PurchaseAssign.Equals(payer))
                  && (string.IsNullOrWhiteSpace(bidAccount) || m.BidAccount.Equals(bidAccount))
               ))
        {
        }


    }
    public class GetTotalBuyForYou : Specification<Order>
    {
        public GetTotalBuyForYou(string[] orderTypes,
         string[] state, string PreState)
        : base(m =>
             (orderTypes.Contains(m.OrderType))
             && (state == null || state.Length == 0 || state.Contains(m.State))
             && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
         )
        {
        }
        public GetTotalBuyForYou(string payer, string[] orderTypes,
        string[] state, string PreState)
       : base(m =>
            (orderTypes.Contains(m.OrderType))
            && (state == null || state.Length == 0 || state.Contains(m.State))
            && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
            && (m.PurchaseAssign.Equals(payer))
        )
        {
        }
    }
    public class GetTotalBuyForYouBought : Specification<Order>
    {
        public GetTotalBuyForYouBought(string[] orderTypes,
         string[] state, string PreState)
        : base(m =>
             (orderTypes.Contains(m.OrderType))
             && (state == null || state.Length == 0 || state.Contains(m.State))
             && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
        && (string.IsNullOrWhiteSpace(m.Tracking))
         )
        {
        }
        public GetTotalBuyForYouBought(string payer, string[] orderTypes,
        string[] state, string PreState)
       : base(m =>
            (orderTypes.Contains(m.OrderType))
            && (state == null || state.Length == 0 || state.Contains(m.State))
            && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
            && (m.PurchaseBy.Equals(payer))
       && (string.IsNullOrWhiteSpace(m.Tracking))
        )
        {
        }
    }
    public class TotalOrderMercari : Specification<Order>
    {
        public TotalOrderMercari(string orderTypes, string PreState, string preResource)
           : base(m =>
                (orderTypes.Contains(m.OrderType))
                && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
            )
        {
        }
        public TotalOrderMercari(string payer, string orderTypes, string PreState, string preResource)
         : base(m =>
              (orderTypes.Contains(m.OrderType))
              && (preResource == "DON_TRA_GIA" ? (m.Total < m.PriceExpected) : (m.Total >= m.PriceExpected || m.PriceExpected == null))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (m.PurchaseAssign.Equals(payer))
          )
        {
        }
    }
    public class TotalOrderMercariBought : Specification<Order>
    {
        public TotalOrderMercariBought(string orderTypes, string PreState)
           : base(m =>
                (orderTypes.Contains(m.OrderType))
                && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
            )
        {
        }
        public TotalOrderMercariBought(string payer, string orderTypes, string PreState)
         : base(m =>
              (orderTypes.Contains(m.OrderType))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (m.PurchaseAssign.Equals(payer))
          )
        {
        }
    }
    public class TotalOrderMercariBoughtPayer : Specification<Order>
    {
        public TotalOrderMercariBoughtPayer(string[] orderTypes, string[] state, string PreState)
           : base(m =>
               string.IsNullOrWhiteSpace(m.Tracking)
               && (orderTypes.Contains(m.OrderType))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (string.IsNullOrWhiteSpace(PreState) || (PreState.Contains(m.State)))
            )
        {
        }
        public TotalOrderMercariBoughtPayer(string payer, string[] orderTypes, string[] state, string PreState)
         : base(m =>
              (orderTypes.Contains(m.OrderType))
              && (string.IsNullOrWhiteSpace(PreState) || (m.State.Contains(PreState)))
              && (m.PurchaseBy.Equals(payer))
             && (state == null || state.Length == 0 || state.Contains(m.State))
             && (string.IsNullOrWhiteSpace(m.Tracking))
          )
        {
        }
    }

    public class GetOrderFollowByBidAccount : Specification<Order>
    {
        public GetOrderFollowByBidAccount(string state, string bidAccount,string saler,string orderCode,string productName,string accountId)
           : base(m => m.State.Contains(state)
           && m.BidAccount.Contains(bidAccount)
           && string.IsNullOrWhiteSpace(m.GroupOrder)
           && m.Saler.Equals(saler)
           && (string.IsNullOrWhiteSpace(orderCode) || m.Code.Contains(orderCode))
           && (string.IsNullOrWhiteSpace(productName) || m.Title.Contains(productName))
           && (m.AccountId.Equals(accountId)))
        {
        }
    }


    public class GetOrderPurchasedFollowByBidAccount : Specification<Order>
    {
        public GetOrderPurchasedFollowByBidAccount(string state, string bidAccount, string saler, string orderCode, string productName, string accountId)
           : base(m => m.State.Contains(state)
           && m.BidAccount.Contains(bidAccount)
           && string.IsNullOrWhiteSpace(m.GroupOrder)
           && m.Saler.Equals(saler)
           && string.IsNullOrWhiteSpace(m.Tracking)
           && (string.IsNullOrWhiteSpace(orderCode) || m.Code.Contains(orderCode))
           && (string.IsNullOrWhiteSpace(productName) || m.Title.Contains(productName))
           && (m.AccountId.Equals(accountId)))
        {
        }
    }

    public class GetOrdersByGuid : Specification<Order>
    {
        public GetOrdersByGuid(string groupOrder)
           : base(m => m.GroupOrder.Equals(groupOrder))
        {
        }
    }

    public class GetOrderFollowBySaler : Specification<Order>
    {
        public GetOrderFollowBySaler(string state, string saler,string orderCode, string productName,string accountId)
           : base(m => m.State.Contains(state) && m.Saler.Equals(saler) && (m.AccountId.Equals(accountId)) &&  string.IsNullOrWhiteSpace(m.GroupOrder) && (string.IsNullOrWhiteSpace(orderCode) || m.Code.Equals(orderCode)) && (string.IsNullOrWhiteSpace(productName) || m.Title.Contains(productName)))
        {
        }
    }

    public class GetOrderFollowByGroupOrder : Specification<Order>
    {
        public GetOrderFollowByGroupOrder(string state, List<string> groupOrder)
           : base(m => m.State.Contains(state) && groupOrder.Contains(m.GroupOrder))
        {
        }
    }

    public class GetOrderFollowByUrl : Specification<Order>
    {
        public GetOrderFollowByUrl(string state,List<string> listOrderCode, string productName)
           : base(m => m.State.Contains(state) && (listOrderCode == null || listOrderCode.Contains(m.Code)) && (string.IsNullOrWhiteSpace(productName) || m.Title.Contains(productName)))
        {
        }
    }
}
