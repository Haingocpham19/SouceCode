using Core.Specification.Abstract;
using iChiba.OM.Model;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Specification.Implement
{
    public class OrderListGetBy : SpecificationBase<Order>
    {
        public OrderListGetBy(string ordertype, string keyword)
           : base(m => ((string.IsNullOrWhiteSpace(keyword)
                || m.Code.Contains(keyword)
                || m.CustomerName.Contains(keyword)
                || m.CustomerPhone.Contains(keyword)
                || m.CustomerProvince.Contains(keyword)
                || m.CustomerDistrict.Contains(keyword))
              && (string.IsNullOrWhiteSpace(ordertype)
                || m.OrderType.Equals(ordertype))))
        {

        }


        public OrderListGetBy(int status, string nameCustomer)
           : base(m => m.Status == status && m.CustomerName.Equals(nameCustomer))
        {

        }

        public OrderListGetBy(string ordertype, string preCode, DateTime startDate, DateTime endDate, string state)
          : base(m => m.OrderType.Contains(ordertype)
          && (m.Code.Contains(preCode))
          && (m.State.Contains(state))
          && (startDate == null || m.OrderDate >= startDate)
          && (endDate == null || m.OrderDate <= endDate))
        {

        }


        public OrderListGetBy(string ordertype, string keyword, string code)
           : base(m => ((string.IsNullOrWhiteSpace(keyword)
                || m.Code.Contains(keyword))
              && (string.IsNullOrWhiteSpace(ordertype)
                || m.OrderType.Equals(ordertype))
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))))
        {

        }

        public OrderListGetBy(string accountId)
          : base(m => (
         (string.IsNullOrWhiteSpace(accountId)
               || m.AccountId.Equals(accountId))))
        {

        }



        public OrderListGetBy(string[] orderType, string accountId, string Code, List<int> OrderId, DateTime? startDate, DateTime? EndDate, int[] Status, string[] State, string Description)
        : base(m => (
               (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Equals(accountId))
                && (orderType == null || orderType.Contains(m.OrderType))
                && (string.IsNullOrWhiteSpace(Code) || m.Code.Equals(Code))
                && (string.IsNullOrWhiteSpace(Description) || m.Title.Contains(Description))
                && (startDate == null || EndDate == null || (m.OrderDate.Date >= startDate.Value.Date && m.OrderDate.Date <= EndDate.Value.Date))
                && (OrderId == null || OrderId.Contains(m.Id))
                && (State == null || State.Length == 0 || State.Contains(m.State))
                && (Status == null || Status.Length == 0 || (m.Status.HasValue && Status.Contains(m.Status.Value)))
        ))
        {

        }

        public OrderListGetBy(string[] orderType, string accountId, string Code, List<int> OrderId, DateTime? startDate, DateTime? EndDate, DateTime? DeliveryStartTime, DateTime? DeliveryEndTime, bool? StatusPayment, int[] Status, string[] State, string Description)
       : base(m => (
              (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Equals(accountId))
               && (orderType == null || orderType.Contains(m.OrderType))
               && (string.IsNullOrWhiteSpace(Code) || m.Code.Equals(Code))
               && (string.IsNullOrWhiteSpace(Description) || m.Title.Contains(Description))
               && (startDate == null || m.OrderDate.Date >= startDate.Value.Date)
               && (EndDate == null || m.OrderDate.Date <= EndDate.Value.Date)
               && (DeliveryStartTime == null || m.DeliveredDate.Value.Date >= DeliveryStartTime.Value.Date)
               && (DeliveryEndTime == null || m.DeliveredDate.Value.Date <= DeliveryEndTime.Value.Date)
               && (StatusPayment == null || (StatusPayment == true ? m.Paid == m.TotalPayment : m.Paid < m.TotalPayment))
               && (OrderId == null || OrderId.Contains(m.Id))
               && (State == null || State.Length == 0 || State.Contains(m.State))
               && (Status == null || Status.Length == 0 || (m.Status.HasValue && Status.Contains(m.Status.Value)))
       ))
        {

        }


        public OrderListGetBy(List<string> lstCode)
         : base(m => lstCode == null || lstCode.Contains(m.Code))
        {

        }

        public OrderListGetBy(string ordertype, string[] state, string keyword)
          : base(m => ((string.IsNullOrWhiteSpace(keyword)
               || m.Code.Contains(keyword)
               || m.CustomerName.Contains(keyword)
               || m.CustomerPhone.Contains(keyword)
               || m.CustomerProvince.Contains(keyword)
               || m.CustomerDistrict.Contains(keyword))
           && (string.IsNullOrWhiteSpace(ordertype)
               || m.OrderType.Equals(ordertype))
           && (state == null || state.Length == 0 || state.Contains(m.State))
          ))
        {

        }


        public OrderListGetBy(string ordertype,
            string keyword,
            string[] accountId,
            string yaUserName,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderId,
            int[] status,
            string code,
            string[] state, string description, string BidAccount)
           : base(m => ((string.IsNullOrWhiteSpace(keyword)
                || m.Code.Contains(keyword)
                || m.CustomerName.Contains(keyword)
                || m.CustomerPhone.Contains(keyword)
                || m.CustomerProvince.Contains(keyword)
                || m.CustomerDistrict.Contains(keyword)
                || m.CustomerWard.Contains(keyword)
                || m.Title.Contains(keyword))
            && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
            && (startTime == null || m.OrderDate.Date >= startTime.Value.Date)
            && (endTime == null || m.OrderDate.Date <= endTime.Value.Date)
            && (accountId == null || accountId.Contains(m.AccountId))
            && (orderId == null || orderId.Contains(m.Id))
            && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
            && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
            && (state == null || state.Length == 0 || state.Contains(m.State))
           ))
        {

        }


        public OrderListGetBy(string ordertype,
            string keyword,
            string[] accountId,
            string yaUserName,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderId,
            int[] status,
            string code, string precode,
            string[] state, string description, string BidAccount, string[] customerAccountId, string tracking, int? Weight)
           : base(m => ((string.IsNullOrWhiteSpace(keyword)
                || m.Code.Contains(keyword)
                || m.CustomerName.Contains(keyword)
                || m.CustomerPhone.Contains(keyword)
                || m.CustomerProvince.Contains(keyword)
                || m.CustomerDistrict.Contains(keyword)
                || m.CustomerWard.Contains(keyword)
                || m.Title.Contains(keyword))
            && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
            && (startTime == null || m.OrderDate >= startTime)
            && (endTime == null || m.OrderDate <= endTime)
            && (accountId == null || accountId.Contains(m.AccountId))
            && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
            && (orderId == null || orderId.Contains(m.Id))
            && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
            && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
            && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
            && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Equals(tracking))
            && (state == null || state.Length == 0 || state.Contains(m.State))
           && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
           //&&(TrackingStatus==null || (m.TrackingStatus.HasValue && TrackingStatus.Contains(m.Status.Value)))
           ))
        { }
        public OrderListGetBy(string ordertype, string[] state, string[] customerAccountId)
          : base(m => (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
           && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
           && (state == null || state.Length == 0 || state.Contains(m.State))
          )
        { }

        public OrderListGetBy(string ordertype,
           string keyword,
           string[] accountId,
           string yaUserName,
           DateTime? startTime,
           DateTime? endTime,
           IList<int> orderId,
           int[] status,
           string code, string precode,
           string[] state, string description, string BidAccount, string[] customerAccountId, string tracking, int? Weight, List<string> bidAccount)
          : base(m => ((string.IsNullOrWhiteSpace(keyword)
               || m.Code.Contains(keyword)
               || m.CustomerName.Contains(keyword)
               || m.CustomerPhone.Contains(keyword)
               || m.CustomerProvince.Contains(keyword)
               || m.CustomerDistrict.Contains(keyword)
               || m.CustomerWard.Contains(keyword)
               || m.Title.Contains(keyword))
           && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
           && ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
           && (accountId == null || accountId.Contains(m.AccountId))
           && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
           && (orderId == null || orderId.Contains(m.Id))
           && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
           && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
           && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
           && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
           && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
           && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Equals(tracking))
           && (state == null || state.Length == 0 || state.Contains(m.State))
           && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
           && (bidAccount.Contains(m.BidAccount))
          ))
        { }



        public OrderListGetBy(string ordertype,
         string keyword,
         string[] accountId,
         DateTime? startTime,
         DateTime? endTime,
         IList<int> orderId,
         int[] trackingStatus,
         string code, string precode,
         string[] state, string description, string BidAccount, string[] customerAccountId, string tracking)
         : base(m => ((string.IsNullOrWhiteSpace(keyword)
              || m.Code.Contains(keyword)
              || m.CustomerName.Contains(keyword)
              || m.CustomerPhone.Contains(keyword)
              || m.CustomerProvince.Contains(keyword)
              || m.CustomerDistrict.Contains(keyword)
              || m.CustomerWard.Contains(keyword)
              || m.Title.Contains(keyword))
          && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
          && ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
          && (accountId == null || accountId.Contains(m.AccountId))
          && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
          && (orderId == null || orderId.Contains(m.Id))
          && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
          && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
          && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
          && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
          && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
          && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Equals(tracking))
          && (state == null || state.Length == 0 || state.Contains(m.State))
         ))
        {

        }

        #region Get order transport

        public OrderListGetBy(string ordertype,
         string keyword,
         string customerAccountId,
         DateTime? startTime,
         DateTime? endTime,
         IList<int> orderId,
         int[] trackingStatus,
         int[] status,
         string code, string precode,
         string[] state, string description, string BidAccount,
         string[] ListCustomerAccountIdBySale, string tracking,
         string preCode, int? shippingRouteId, DateTime? DepartureDateFrom, DateTime? DepartureDateTo)
         : base(m => ((string.IsNullOrWhiteSpace(keyword)
              || m.Code.Contains(keyword)
              || m.CustomerName.Contains(keyword)
              || m.CustomerPhone.Contains(keyword)
              || m.CustomerProvince.Contains(keyword)
              || m.CustomerDistrict.Contains(keyword)
              || m.CustomerWard.Contains(keyword)
              || m.Title.Contains(keyword))
          && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
          && ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
          && (string.IsNullOrWhiteSpace(customerAccountId) || m.AccountId.Contains(customerAccountId))
          && (ListCustomerAccountIdBySale == null || ListCustomerAccountIdBySale.Contains(m.AccountId))
          && (orderId == null || orderId.Contains(m.Id))
          && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
          && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
          && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
          && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
          && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
          && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
          && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Equals(tracking))
          && (state == null || state.Length == 0 || state.Contains(m.State))
          && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
          && (shippingRouteId == null || m.ShippingRouteId == shippingRouteId)
          && (DepartureDateFrom == null || m.DepartureDate >= DepartureDateFrom)
          && (DepartureDateTo == null || m.DepartureDate <= DepartureDateTo)
          && (m.Status != 8)
         ))
        {

        }

        #endregion

        public OrderListGetBy(string ordertype,
           string accountId,
           int[] status,
           string[] state, string description)
          : base(m => (
              (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
          && (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Equals(accountId))
          && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
          && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
          && (state == null || state.Length == 0 || state.Contains(m.State))
       ))
        {

        }

        public OrderListGetBy(string ordertype,
         string accountId,
         int[] status,
         string code,
         string[] state, string description)
        : base(m => (
            (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Equals(accountId))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        ))
        {

        }


        public OrderListGetBy(string ordertype,
          string keyword,
          string accountId,
          string yaUserName,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderId,
          int[] status,
          string code,
          string[] state, string description, string BidAccount, string[] customerAccountId)
         : base(m => ((string.IsNullOrWhiteSpace(keyword)
              || m.Code.Contains(keyword)
              || m.CustomerName.Contains(keyword)
              || m.CustomerPhone.Contains(keyword)
              || m.CustomerProvince.Contains(keyword)
              || m.CustomerDistrict.Contains(keyword)
              || m.CustomerWard.Contains(keyword)
              || m.Title.Contains(keyword))
          && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
          && (startTime == null || m.OrderDate.Date >= startTime.Value.Date)
          && (endTime == null || m.OrderDate.Date <= endTime.Value.Date)
          && (accountId == null || accountId.Contains(m.AccountId))
         && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
          && (orderId == null || orderId.Contains(m.Id))
          && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
          && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))

          && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
         && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
           && (state == null || state.Length == 0 || state.Contains(m.State))))
        {

        }

        public OrderListGetBy(string ordertype,
        string keyword,
        string accountId,
        string yaUserName,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        //&& ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
        && (startTime == null || m.LastActionDate >= startTime.Value)
        && (endTime == null || m.LastActionDate <= endTime.Value)
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }
        public OrderListGetBy(string payer, string ordertype,
        string keyword,
        string accountId,
        string yaUserName,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        //&& ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
        && (startTime == null || m.LastActionDate >= startTime.Value)
        && (endTime == null || m.LastActionDate <= endTime.Value)
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
        ))
        {

        }
        public OrderListGetBy(string payer, string shopSell, string ordertype,
        string keyword,
        string accountId,
        string yaUserName,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        //&& ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
        && (startTime == null || m.LastActionDate >= startTime.Value)
        && (endTime == null || m.LastActionDate <= endTime.Value)
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
       && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
        ))
        {

        }

        #region debt
        public OrderListGetBy(
        string keyword,
        string accountId,
        string yaUserName,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (m.OrderType != "TRANSPORT")
        && (startTime == null || m.LastActionDate >= startTime.Value)
        && (endTime == null || m.LastActionDate <= endTime.Value)
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }



        public OrderListGetBy(
        string keyword,
        string[] accountId,
        string yaUserName,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (m.OrderType != "TRANSPORT")
        && ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }
        #endregion


        public OrderListGetBy(string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }
        public OrderListGetBy(DateTime? startTimeCancel, DateTime? endTimeCancel, string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (startTimeCancel == null || m.CancelDate >= startTimeCancel.Value)
       && (endTimeCancel == null || m.CancelDate <= endTimeCancel.Value)
        ))
        {

        }

        public OrderListGetBy(string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }
        public OrderListGetBy(string shopSell, string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
        ))
        {

        }
        public OrderListGetBy(string payer, string shopSell, string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
       && (string.IsNullOrWhiteSpace(payer) || m.PurchaseAssign.Equals(payer))
        ))
        {

        }

        public OrderListGetBy(string shopSell, string ordertype,
       string keyword,
       string accountId,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] trackingStatus,
       int[] status,
       int? preStatus,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, List<string> bidAccount)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
       && ((startTime == null) || (m.LastActionDate >= startTime.Value))
       && ((endTime == null) || (m.LastActionDate <= endTime.Value))
       && (accountId == null || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
       && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (Tracking == null || m.Tracking.Contains(Tracking))
       && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
       && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
       && (bidAccount.Contains(m.BidAccount))
       ))
        {

        }

        public OrderListGetBy(
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree,
        int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, List<string> shippingRoutes)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (m.OrderType != "TRANSPORT")
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (shippingRoutes == null || shippingRoutes.Count() == 0 || shippingRoutes.Contains(m.Currency))
        ))
        {

        }
        public OrderListGetBy(string[] state)
       : base(m => (m.OrderType != "TRANSPORT")
        && (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false)
        && (state == null || state.Length == 0 || state.Contains(m.State))
        )
        {

        }




        public OrderListGetBy(string code,
        string keyword,
        string accountId,
        bool? approvalOrder,
        DateTime? startTime,
        DateTime? endTime)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword) || m.Code.Contains(keyword))
        && (!m.OrderType.Equals("TRANSPORT"))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && ((startTime == null) || (m.QuoteDate >= startTime.Value))
        && ((endTime == null) || (m.QuoteDate <= endTime.Value))
        && (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Contains(accountId))
        && ((approvalOrder == null) || (approvalOrder == true ? m.RevenueDate != null : m.RevenueDate == null))
        ))
        {

        }




        public OrderListGetBy(string note, string ordertype,
       string keyword,
       string accountId,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] trackingStatus,
       int[] status,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
       && ((startTime == null) || (m.LastActionDate >= startTime.Value))
       && ((endTime == null) || (m.LastActionDate <= endTime.Value))
       && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
       && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
       && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
      && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
      && (string.IsNullOrWhiteSpace(m.Tracking))
       ))
        {

        }
        public OrderListGetBy(string shopSell, string note, string ordertype,
       string keyword,
       string accountId,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] trackingStatus,
       int[] status,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
       && ((startTime == null) || (m.LastActionDate >= startTime.Value))
       && ((endTime == null) || (m.LastActionDate <= endTime.Value))
       && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
       && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
       && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
      && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
      && (string.IsNullOrWhiteSpace(m.Tracking))
      && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
       ))
        {

        }
        public OrderListGetBy(string payer, string shopSell, string note, string ordertype,
       string keyword,
       string accountId,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] trackingStatus,
       int[] status,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
       && ((startTime == null) || (m.LastActionDate >= startTime.Value))
       && ((endTime == null) || (m.LastActionDate <= endTime.Value))
       && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
       && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
       && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
      && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
      //&& (string.IsNullOrWhiteSpace(m.Tracking))
      && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
      && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
       ))
        {

        }




        public OrderListGetBy(string shopSell, string note, string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, List<string> bidAccount)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
            && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
            && ((startTime == null) || (m.LastActionDate >= startTime.Value))
            && ((endTime == null) || (m.LastActionDate <= endTime.Value))
            && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
            && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
            && (orderId == null || orderId.Contains(m.Id))
            && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
            && (bidAccount == null || bidAccount.Contains(m.BidAccount))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
            && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
            && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
            && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
            && (state == null || state.Length == 0 || state.Contains(m.State))
            && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
            && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
            && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
            && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
            && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
           && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
           && (string.IsNullOrWhiteSpace(m.Tracking))
           && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
          ))
        {

        }

        public OrderListGetBy(string shopSell, string note, string ordertype,
      string keyword,
      string accountId,
      string purchaseAssign,
      DateTime? startTime,
      DateTime? endTime,
      IList<int> orderId,
      int[] status,
      string code, string precode,
      string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
     : base(m => (
      (string.IsNullOrWhiteSpace(keyword)
          || m.Code.Contains(keyword)
          || m.CustomerName.Contains(keyword)
          || m.CustomerPhone.Contains(keyword)
          || m.CustomerProvince.Contains(keyword)
          || m.CustomerDistrict.Contains(keyword)
          || m.CustomerWard.Contains(keyword)
          || m.Title.Contains(keyword)
           || m.Saler.Contains(keyword))
          && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
          && ((startTime == null) || (m.LastActionDate >= startTime.Value))
          && ((endTime == null) || (m.LastActionDate <= endTime.Value))
          && (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Contains(accountId))
          && (m.PurchaseAssign.Contains(purchaseAssign))
          && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
          && (orderId == null || orderId.Contains(m.Id))
          && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
          && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
          && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
          && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
          && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
          && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
          && (state == null || state.Length == 0 || state.Contains(m.State))
          && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
          && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
          && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
          && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
          && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
          && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
          //&& (string.IsNullOrWhiteSpace(m.Tracking))
          && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
        ))
        {

        }



        public OrderListGetBy(string payer, string note, string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Note.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
        && (!string.IsNullOrWhiteSpace(m.Tracking))
        && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
        ))
        {

        }



        public OrderListGetBy(string ordertype,
        string keyword,
        string[] accountId,
        string yaUserName,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }

        public OrderListGetBy(string ordertype,
        string keyword,
        string accountId,
        string yaUserName,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? preProductType, string preOrderType)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Equals(code))
        && (string.IsNullOrWhiteSpace(ordertype) || m.Code.StartsWith(ordertype))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }


        public OrderListGetBy(string ordertype,
       string keyword,
       string[] accountId,
       string yaUserName,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] status,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? preProductType, string preOrderType)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
       && (accountId == null || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Equals(code))
       && (string.IsNullOrWhiteSpace(ordertype) || m.Code.StartsWith(ordertype))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (Tracking == null || m.Tracking.Contains(Tracking))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       ))
        {

        }



        public OrderListGetBy(int[] Id)
        : base(m => Id.Contains(m.Id))
        {

        }

        public OrderListGetBy(int preStatus, string preState, string ordertype, DateTime? startTime, DateTime? endTime, string keyword, string[] accountId, string code, string[] customerAccountId, int[] status, string[] state)
       : base(m => (string.IsNullOrWhiteSpace(keyword)
                   || m.OrderType.Contains(keyword)
                   || m.Code.Contains(keyword)
                   || m.Saler.Contains(keyword))
               && (string.IsNullOrWhiteSpace(ordertype) || (m.OrderType.Equals(ordertype)))
               && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
               && (m.Status == preStatus || m.State.Contains(preState))
               && (startTime == null || m.OrderDate.Date >= startTime.Value.Date)
               && (endTime == null || m.OrderDate.Date <= endTime.Value.Date)
               && (accountId == null || accountId.Contains(m.AccountId))
               && (state == null || state.Length == 0 || state.Contains(m.State))
               && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
               && (customerAccountId == null || customerAccountId.Contains(m.AccountId)))
        {

        }
        public OrderListGetBy(string payer, int preStatus, string preState, string ordertype, DateTime? startTime, DateTime? endTime, string keyword, string[] accountId, string code, string[] customerAccountId, int[] status, string[] state)
       : base(m => (string.IsNullOrWhiteSpace(keyword)
                   || m.OrderType.Contains(keyword)
                   || m.Code.Contains(keyword)
                   || m.Saler.Contains(keyword))
               && (string.IsNullOrWhiteSpace(ordertype) || (m.OrderType.Equals(ordertype)))
               && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
               && (m.Status == preStatus || m.State.Contains(preState))
               && (startTime == null || m.OrderDate.Date >= startTime.Value.Date)
               && (endTime == null || m.OrderDate.Date <= endTime.Value.Date)
               && (accountId == null || accountId.Contains(m.AccountId))
               && (state == null || state.Length == 0 || state.Contains(m.State))
               && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
               && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
               && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
       )

        {

        }


        public OrderListGetBy(int preStatus, string preState, string ordertype, DateTime? startTime, DateTime? endTime, string keyword, string accountId, string code, string[] customerAccountId, int[] status, string[] state)
         : base(m => (string.IsNullOrWhiteSpace(keyword)
                 || m.OrderType.Contains(keyword)
                 || m.Code.Contains(keyword)
                 || m.Saler.Contains(keyword))
             && (string.IsNullOrWhiteSpace(ordertype) || (m.OrderType.Equals(ordertype)))
             && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
             && (m.Status == preStatus || m.State.Contains(preState))
             && (startTime == null || m.OrderDate.Date >= startTime.Value.Date)
             && (endTime == null || m.OrderDate.Date <= endTime.Value.Date)
             && (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Contains(accountId))
             && (state == null || state.Length == 0 || state.Contains(m.State))
             && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
             && (customerAccountId == null || customerAccountId.Contains(m.AccountId)))
        {

        }
    }

    public class QuotesAaggregateTransport : SpecificationBase<Order>
    {
        public QuotesAaggregateTransport(string code,
        string keyword,
        string accountId,
        bool? approvalOrder,
        string trackingNumner,
        DateTime? startTime,
        DateTime? endTime)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword) || m.Code.Contains(keyword))
        && (m.OrderType.Equals("TRANSPORT"))
        && (string.IsNullOrWhiteSpace(trackingNumner) || m.Tracking.Equals(trackingNumner))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && ((startTime == null) || (m.QuoteDate >= startTime.Value))
        && ((endTime == null) || (m.QuoteDate <= endTime.Value))
        && ((approvalOrder == null) || (approvalOrder == true ? m.RevenueDate != null : m.RevenueDate == null))
        && (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Contains(accountId))
        ))
        {

        }
    }


    public class OrderGetListCancel : SpecificationBase<Order>
    {
        public OrderGetListCancel(int[] Id) : base(m => Id.Contains(m.Id))
        {

        }
    }


    public class OrderPurchaseBoughtGetBy : SpecificationBase<Order>
    {
        public OrderPurchaseBoughtGetBy(string note, string ordertype,
           string keyword,
           string accountId,
           DateTime? startTime,
           DateTime? endTime,
           IList<int> orderId,
           int[] status,
           string code, string precode,
           string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
          : base(m => (
           (string.IsNullOrWhiteSpace(keyword)
               || m.Code.Contains(keyword)
               || m.CustomerName.Contains(keyword)
               || m.CustomerPhone.Contains(keyword)
               || m.CustomerProvince.Contains(keyword)
               || m.CustomerDistrict.Contains(keyword)
               || m.CustomerWard.Contains(keyword)
               || m.Title.Contains(keyword)
                || m.Saler.Contains(keyword))
           && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
           && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
           && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
           && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
           && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
           && (orderId == null || orderId.Contains(m.Id))
           && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
           && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
           && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
           && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
           && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
           && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
           && (state == null || state.Length == 0 || state.Contains(m.State))
           && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
           && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
           && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
           && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
           && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
          && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
          && (string.IsNullOrWhiteSpace(m.Tracking))
           ))
        {

        }
        public OrderPurchaseBoughtGetBy(string payer, string shopSell, string note, string ordertype,
           string keyword,
           string accountId,
           DateTime? startTime,
           DateTime? endTime,
           IList<int> orderId,
           int[] status,
           string code, string precode,
           string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
          : base(m => (
           (string.IsNullOrWhiteSpace(keyword)
               || m.Code.Contains(keyword)
               || m.CustomerName.Contains(keyword)
               || m.CustomerPhone.Contains(keyword)
               || m.CustomerProvince.Contains(keyword)
               || m.CustomerDistrict.Contains(keyword)
               || m.CustomerWard.Contains(keyword)
               || m.Title.Contains(keyword)
                || m.Saler.Contains(keyword))
           && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
           && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
           && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
           && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
           && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
           && (orderId == null || orderId.Contains(m.Id))
           && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
           && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
           && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
           && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
           && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
           && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
           && (state == null || state.Length == 0 || state.Contains(m.State))
           && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
           && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
           && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
           && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
           && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
          && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
          && (string.IsNullOrWhiteSpace(m.Tracking))
          && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
          && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
           ))
        {

        }
    }



    public class OrderListGetByTransport : Specification<Order>
    {
        public OrderListGetByTransport(string payer, string shopSell, string note, string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
        && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
        && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
        && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
        && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
        ))
        {

        }




        public OrderListGetByTransport(string note, string ordertype,
      string keyword,
      string accountId,
      DateTime? startTime,
      DateTime? endTime,
      IList<int> orderId,
      int[] trackingStatus,
      int[] status,
      string code, string precode,
      string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, List<string> bidAccount)
     : base(m => (
      (string.IsNullOrWhiteSpace(keyword)
          || m.Code.Contains(keyword)
          || m.CustomerName.Contains(keyword)
          || m.CustomerPhone.Contains(keyword)
          || m.CustomerProvince.Contains(keyword)
          || m.CustomerDistrict.Contains(keyword)
          || m.CustomerWard.Contains(keyword)
          || m.Title.Contains(keyword)
           || m.Saler.Contains(keyword))
      && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
      && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
      && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
      && (accountId == null || accountId.Contains(m.AccountId))
      && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
      && (orderId == null || orderId.Contains(m.Id))
      && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
      && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
      && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
      && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
      && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
      && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
      && (Tracking == null || m.Tracking.Contains(Tracking))
      && (state == null || state.Length == 0 || state.Contains(m.State))
      && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
      && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
      && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
      && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
      && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
      && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
      && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
      && (bidAccount == null || bidAccount.Contains(m.BidAccount))
      ))
        {

        }



        public OrderListGetByTransport(string note, string ordertype,
       string keyword,
       string accountId,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] trackingStatus,
       int[] status,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
       && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
       && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
       && (accountId == null || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
       && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (Tracking == null || m.Tracking.Contains(Tracking))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
       && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
      && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
      && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
       ))
        {

        }


        public OrderListGetByTransport(string shopSell, string note, string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, List<string> bidAccount)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
        && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
        && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
        && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
        && (bidAccount == null || bidAccount.Contains(m.BidAccount))
        ))
        {

        }

    }
    public class SurchargeOrderListGetBy : SpecificationBase<Order>
    {
        public SurchargeOrderListGetBy(string payer, string note, string ordertype,
       string keyword,
       string accountId,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] trackingStatus,
       int[] status,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState,
       string[] customerAccountId, int? preTracking, int? Weight, string preCodeVC)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
       && ((startTime == null) || (m.LastActionDate >= startTime.Value))
       && ((endTime == null) || (m.LastActionDate <= endTime.Value))
       && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
       && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
       && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
       && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
       && (string.IsNullOrWhiteSpace(preCodeVC) || m.Code.StartsWith(preCodeVC))
       ))
        {

        }

        public SurchargeOrderListGetBy(string note, string ordertype,
       string keyword,
       string accountId,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] trackingStatus,
       int[] status,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, List<string> bidAccount)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
       && ((startTime == null) || (m.LastActionDate >= startTime.Value))
       && ((endTime == null) || (m.LastActionDate <= endTime.Value))
       && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
       && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
       && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
       && (bidAccount == null || bidAccount.Contains(m.BidAccount))
       ))
        {

        }
    }

    public class OrderListGetByNoTracking : SpecificationBase<Order>
    {
        public OrderListGetByNoTracking(string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && (startTime == null || m.PurchaseDate >= startTime.Value)
        && (endTime == null || m.PurchaseDate <= endTime.Value)
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(m.Tracking))
        ))
        {

        }
        public OrderListGetByNoTracking(string payer, string shopSell, string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && (startTime == null || m.PurchaseDate >= startTime.Value)
        && (endTime == null || m.PurchaseDate <= endTime.Value)
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(m.Tracking))
       && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
       && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
        ))
        {

        }


        public OrderListGetByNoTracking(string shopSell, string ordertype,
       string keyword,
       string accountId,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] trackingStatus,
       int[] status,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid,
       string PreState, string[] customerAccountId, int? preTracking, int? Weight, List<string> bidAccount)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
       && (startTime == null || m.PurchaseDate >= startTime.Value)
       && (endTime == null || m.PurchaseDate <= endTime.Value)
       && (accountId == null || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
       && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (Tracking == null || m.Tracking.Contains(Tracking))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
       && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(m.Tracking))
       && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
       && (bidAccount.Contains(m.BidAccount))
       ))
        {

        }

    }
    public class OrderListGetByHaveTracking : SpecificationBase<Order>
    {
        public OrderListGetByHaveTracking(string ordertype,
        string keyword,
        string accountId,
        string yaUserName,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        //&& ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
        && (startTime == null || m.LastActionDate >= startTime.Value)
        && (endTime == null || m.LastActionDate <= endTime.Value)
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (!string.IsNullOrWhiteSpace(m.Tracking))
        ))
        {

        }
        public OrderListGetByHaveTracking(string payer, string shopSell, string ordertype,
        string keyword,
        string accountId,
        string yaUserName,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        //&& ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
        && (startTime == null || m.LastActionDate >= startTime.Value)
        && (endTime == null || m.LastActionDate <= endTime.Value)
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (!string.IsNullOrWhiteSpace(m.Tracking))
       && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
       && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
        ))
        {

        }
    }
    public class OrderDebtPaidGetBy : SpecificationBase<Order>
    {
        public OrderDebtPaidGetBy(string[] orderType, string accountId, string Code, List<int> OrderId, DateTime? startDate, DateTime? EndDate, int[] Status, string[] State, string Description)
         : base(m => (
                (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Equals(accountId))
                 && (orderType == null || orderType.Contains(m.OrderType))
                 && (m.Paid == m.TotalPayment)
                 && (string.IsNullOrWhiteSpace(Code) || m.Code.Equals(Code))
                 && (string.IsNullOrWhiteSpace(Description) || m.Title.Contains(Description))
                 && (startDate == null || EndDate == null || (m.OrderDate.Date >= startDate.Value.Date && m.OrderDate.Date <= EndDate.Value.Date))
                 && (OrderId == null || OrderId.Contains(m.Id))
                 && (State == null || State.Length == 0 || State.Contains(m.State))
                 && (Status == null || Status.Length == 0 || (m.Status.HasValue && Status.Contains(m.Status.Value)))
         ))
        {

        }
    }


    public class OrderPaymentApprovalGetBy : SpecificationBase<Order>
    {
        public OrderPaymentApprovalGetBy(string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount,
        string Tracking, int? shippingFree, int? Paid, string PreState,
        string[] customerAccountId, int? preTracking, int? Weight,
        string purchaseAssig, string preCode, List<string> shippingRoutes)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (!m.OrderType.Equals("TRANSPORT"))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Contains(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (string.IsNullOrWhiteSpace(purchaseAssig) || m.PurchaseAssign.Equals(purchaseAssig))
        && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
        && (shippingRoutes == null || shippingRoutes.Count() == 0 || shippingRoutes.Contains(m.Currency))
        ))
        {

        }
    }

    public class OrderQuoteGetBy : SpecificationBase<Order>
    {
        public OrderQuoteGetBy(string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (!m.OrderType.Equals("TRANSPORT"))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Contains(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }
    }

    public class OrderStorageGetBy : SpecificationBase<Order>
    {
        public OrderStorageGetBy(string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (!m.OrderType.Equals("TRANSPORT"))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (m.Status.Equals(status))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }
    }


    public class TotalOrderPaymentApprovalGetBy : SpecificationBase<Order>
    {
        public TotalOrderPaymentApprovalGetBy(
        string[] state)
       : base(m => (
        (!m.OrderType.Equals("TRANSPORT"))
        && (m.DeliveryPayType == true)
        && (state == null || state.Length == 0 || state.Contains(m.State))
        ))
        {

        }
    }

    public class AllOrderGetBy : SpecificationBase<Order>
    {
        public AllOrderGetBy(
        string keyword,
        string title,
        string refType,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        DateTime? startPurchaseTime,
        DateTime? endPurchaseTime,
        DateTime? startDeliveryDateTime,
        DateTime? endDeliveryDateTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (!m.OrderType.Equals("TRANSPORT"))
        && (string.IsNullOrWhiteSpace(refType) || (m.OrderType.Contains(refType)))
        && ((startTime == null) || (m.OrderDate >= startTime.Value))
        && ((endTime == null) || (m.OrderDate <= endTime.Value))
        && ((startPurchaseTime == null) || (m.PurchaseDate >= startPurchaseTime.Value))
        && ((endPurchaseTime == null) || (m.PurchaseDate <= endPurchaseTime.Value))
        && ((startDeliveryDateTime == null) || (m.RevenueDate >= startDeliveryDateTime.Value))
        && ((endDeliveryDateTime == null) || (m.RevenueDate <= endDeliveryDateTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (string.IsNullOrWhiteSpace(title) || m.Title.Contains(title))
        ))
        {

        }
    }



    public class AllOrderTransportGetBy : SpecificationBase<Order>
    {
        public AllOrderTransportGetBy(
        string keyword,
        string title,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        DateTime? startPurchaseTime,
        DateTime? endPurchaseTime,
        DateTime? startDeliveryDateTime,
        DateTime? endDeliveryDateTime,
        IList<int> orderId,
        int? trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (m.OrderType.Equals("TRANSPORT"))
        && ((startTime == null) || (m.OrderDate >= startTime.Value))
        && ((endTime == null) || (m.OrderDate <= endTime.Value))
        && ((startPurchaseTime == null) || (m.PurchaseDate >= startPurchaseTime.Value))
        && ((endPurchaseTime == null) || (m.PurchaseDate <= endPurchaseTime.Value))
        && ((startDeliveryDateTime == null) || (m.RevenueDate >= startDeliveryDateTime.Value))
        && ((endDeliveryDateTime == null) || (m.RevenueDate <= endDeliveryDateTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || m.TrackingStatus.Equals(trackingStatus))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (string.IsNullOrWhiteSpace(title) || m.Title.Contains(title))
        ))
        {

        }
    }


    public class OrderOrdertransportdeleveryapprovalGetBy : SpecificationBase<Order>
    {
        public OrderOrdertransportdeleveryapprovalGetBy(string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, string warehouseCode)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (string.IsNullOrWhiteSpace(warehouseCode) || m.Warehouse.Contains(warehouseCode))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }
    }
    public class TotalOrderOrdertransportdeleveryapprovalGetBy : SpecificationBase<Order>
    {
        public TotalOrderOrdertransportdeleveryapprovalGetBy(string[] state)
       : base(m => (!m.OrderType.Equals("TRANSPORT"))
        && (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false)
        && (state == null || state.Length == 0 || state.Contains(m.State))
        )
        {

        }
    }
    public class OrderListGetByBought : Specification<Order>
    {
        public OrderListGetByBought(string payer, string shopSell, string note, string ordertype,
       string keyword,
       string accountId,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] trackingStatus,
       int[] status,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, string preCode)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
       && ((startTime == null) || (m.LastActionDate >= startTime.Value))
       && ((endTime == null) || (m.LastActionDate <= endTime.Value))
       && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
       && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
       && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
      && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
      //&& (string.IsNullOrWhiteSpace(m.Tracking))
      && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
      && (string.IsNullOrWhiteSpace(payer) || m.PurchaseAssign.Equals(payer))
      && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
       ))
        {

        }
    }
    public class SearchWaitingOrder : Specification<Order>
    {
        public SearchWaitingOrder(string payer, string ordertype,
           string keyword,
           string[] accountId,
           string yaUserName,
           DateTime? startTime,
           DateTime? endTime,
           IList<int> orderId,
           int[] status,
           string code, string precode,
           string[] state, string description, string BidAccount, string[] customerAccountId, string tracking, int? Weight)
          : base(m => ((string.IsNullOrWhiteSpace(keyword)
               || m.Code.Contains(keyword)
               || m.CustomerName.Contains(keyword)
               || m.CustomerPhone.Contains(keyword)
               || m.CustomerProvince.Contains(keyword)
               || m.CustomerDistrict.Contains(keyword)
               || m.CustomerWard.Contains(keyword)
               || m.Title.Contains(keyword))
           && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
           && (startTime == null || m.OrderDate >= startTime)
           && (endTime == null || m.OrderDate <= endTime)
           && (accountId == null || accountId.Contains(m.AccountId))
           && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
           && (orderId == null || orderId.Contains(m.Id))
           && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
           && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
           && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
           && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
           && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
           && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Equals(tracking))
           && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
           && (state == null || state.Length == 0 || state.Contains(m.State))
          ))
        { }
        public SearchWaitingOrder(string ordertype,
          string keyword,
          string[] accountId,
          string yaUserName,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderId,
          int[] status,
          string code, string precode,
          string[] state, string description, string BidAccount, string[] customerAccountId, string tracking, int? Weight)
         : base(m => ((string.IsNullOrWhiteSpace(keyword)
              || m.Code.Contains(keyword)
              || m.CustomerName.Contains(keyword)
              || m.CustomerPhone.Contains(keyword)
              || m.CustomerProvince.Contains(keyword)
              || m.CustomerDistrict.Contains(keyword)
              || m.CustomerWard.Contains(keyword)
              || m.Title.Contains(keyword))
          && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
          && (startTime == null || m.OrderDate >= startTime)
          && (endTime == null || m.OrderDate <= endTime)
          && (accountId == null || accountId.Contains(m.AccountId))
          && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
          && (orderId == null || orderId.Contains(m.Id))
          && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
          && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
          && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
          && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
          && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
          && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Equals(tracking))
          && (state == null || state.Length == 0 || state.Contains(m.State))
         ))
        { }

        public SearchWaitingOrder(string[] orderTypes,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderIds,
        int[] status,
        string BidAccount,
        string[] state,
        string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string preCode)
       : base(m => (
            (string.IsNullOrWhiteSpace(keyword)
                || m.CustomerName.Contains(keyword)
                || m.CustomerPhone.Contains(keyword)
                || m.CustomerProvince.Contains(keyword)
                || m.CustomerDistrict.Contains(keyword)
                || m.Title.Contains(keyword)
            )
            && (orderTypes.Contains(m.OrderType))
            && (startTime == null || m.OrderDate >= startTime.Value)
            && (endTime == null || m.OrderDate <= endTime.Value)
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


        public SearchWaitingOrder(string payer, string[] orderTypes,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderIds,
        int[] status,
        string BidAccount,
        string[] state,
        string code, string tracking, string PreState, string[] arrCustomerAccountId, int? statusTracking, string preCode)
       : base(m => (
            (string.IsNullOrWhiteSpace(keyword)
                || m.CustomerName.Contains(keyword)
                || m.CustomerPhone.Contains(keyword)
                || m.CustomerProvince.Contains(keyword)
                || m.CustomerDistrict.Contains(keyword)
                || m.Title.Contains(keyword)
            )
            && (!m.OrderType.Equals("TRANSPORT"))
            && (!m.Code.StartsWith("JPD"))
            && (startTime == null || m.OrderDate >= startTime.Value)
            && (endTime == null || m.OrderDate <= endTime.Value)
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
            && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
        ))
        {
        }
    }


    public class OrderGetAuctionPurchaseBy : Specification<Order>
    {
        public OrderGetAuctionPurchaseBy(string payer, string shopSell, string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
       && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
        ))
        {

        }
    }
    public class OrderGetAuctionPurchaseAssign : Specification<Order>
    {
        public OrderGetAuctionPurchaseAssign(string payer, string shopSell, string ordertype,
        string keyword,
        string accountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        int? preStatus,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (preStatus == 1 ? m.DeliveryPayType == true : (m.DeliveryPayType == true || m.DeliveryPayType == null || m.DeliveryPayType == false))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
       && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
       && (string.IsNullOrWhiteSpace(payer) || m.PurchaseAssign.Equals(payer))
        ))
        {

        }
    }
    public class TotalAuction : Specification<Order>
    {
        public TotalAuction(string ordertype,
       string precode,
        string[] state)
       : base(m =>
        (
           (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
                && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
                && (state == null || state.Length == 0 || state.Contains(m.State))
           ))
        {

        }
        public TotalAuction(string payer, string ordertype,
       string precode,
        string[] state)
       : base(m =>
        (
           (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
                && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (m.PurchaseAssign.Equals(payer))
           ))
        {

        }
    }
    public class TotalAuctionBougtht : Specification<Order>
    {
        public TotalAuctionBougtht(string ordertype,
       string precode,
        string[] state)
       : base(m =>
        (
           (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
             && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
            && (state == null || state.Length == 0 || state.Contains(m.State))
            && (string.IsNullOrWhiteSpace(m.Tracking))
       ))
        {

        }
        public TotalAuctionBougtht(string payer, string ordertype,
       string precode,
        string[] state)
       : base(m =>
        (
           (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
                && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
                && (state == null || state.Length == 0 || state.Contains(m.State))
                && (m.PurchaseBy.Equals(payer))
                && (string.IsNullOrWhiteSpace(m.Tracking))
           ))
        {

        }
    }
    public class OrderListGetByPurchaseBy : Specification<Order>
    {
        public OrderListGetByPurchaseBy(string payer, string ordertype,
            string keyword,
            string[] accountId,
            string yaUserName,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderId,
            int[] status,
            string code, string precode,
            string[] state, string description, string BidAccount, string[] customerAccountId, string tracking, int? Weight)
           : base(m => ((string.IsNullOrWhiteSpace(keyword)
                || m.Code.Contains(keyword)
                || m.CustomerName.Contains(keyword)
                || m.CustomerPhone.Contains(keyword)
                || m.CustomerProvince.Contains(keyword)
                || m.CustomerDistrict.Contains(keyword)
                || m.CustomerWard.Contains(keyword)
                || m.Title.Contains(keyword))
            && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
            && (startTime == null || m.OrderDate >= startTime)
            && (endTime == null || m.OrderDate <= endTime)
            && (accountId == null || accountId.Contains(m.AccountId))
            && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
            && (orderId == null || orderId.Contains(m.Id))
            && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
            && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
            && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
            && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Equals(tracking))
            && (state == null || state.Length == 0 || state.Contains(m.State))
           && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
           && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
           ))
        { }
    }


    public class WaitingPaymentOrderGetByPurchaseBy : Specification<Order>
    {
        public WaitingPaymentOrderGetByPurchaseBy(string payer, string ordertype,
            string keyword,
            string[] accountId,
            string yaUserName,
            DateTime? startTime,
            DateTime? endTime,
            IList<int> orderId,
            int[] status,
            string code, string precode,
            string[] state, string description, string BidAccount, string[] customerAccountId, string tracking, int? Weight)
           : base(m => ((string.IsNullOrWhiteSpace(keyword)
                || m.Code.Contains(keyword)
                || m.CustomerName.Contains(keyword)
                || m.CustomerPhone.Contains(keyword)
                || m.CustomerProvince.Contains(keyword)
                || m.CustomerDistrict.Contains(keyword)
                || m.CustomerWard.Contains(keyword)
                || m.Title.Contains(keyword))
            && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
            && (startTime == null || m.OrderDate >= startTime)
            && (endTime == null || m.OrderDate <= endTime)
            && (accountId == null || accountId.Contains(m.AccountId))
            && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
            && (orderId == null || orderId.Contains(m.Id))
            && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
            && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
            && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
            && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Equals(tracking))
            && (state == null || state.Length == 0 || state.Contains(m.State))
           && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
           && (m.PurchaseBy.Contains(payer))
           ))
        { }
    }



    public class OrderListByPurchaseBy : Specification<Order>
    {
        public OrderListByPurchaseBy(string payer, string ordertype,
           string keyword,
           string[] accountId,
           string yaUserName,
           DateTime? startTime,
           DateTime? endTime,
           IList<int> orderId,
           int[] status,
           string code, string precode,
           string[] state, string description, string BidAccount, string[] customerAccountId, string tracking, int? Weight)
          : base(m => ((string.IsNullOrWhiteSpace(keyword)
               || m.Code.Contains(keyword)
               || m.CustomerName.Contains(keyword)
               || m.CustomerPhone.Contains(keyword)
               || m.CustomerProvince.Contains(keyword)
               || m.CustomerDistrict.Contains(keyword)
               || m.CustomerWard.Contains(keyword)
               || m.Title.Contains(keyword))
           && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
           && (startTime == null || m.OrderDate >= startTime)
           && (endTime == null || m.OrderDate <= endTime)
           && (accountId == null || accountId.Contains(m.AccountId))
           && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
           && (orderId == null || orderId.Contains(m.Id))
           && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
           && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
           && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
           && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
           && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
           && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Equals(tracking))
           && (state == null || state.Length == 0 || state.Contains(m.State))
          && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
          && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
          ))
        { }
    }
    public class OrderListGetByCode : SpecificationBase<Order>
    {
        public OrderListGetByCode(string code)
            : base(x => x.Code.Equals(code))
        {

        }
    }


    public class GetOrderByGroupCode : SpecificationBase<Order>
    {
        public GetOrderByGroupCode(string groupCode)
            : base(m => m.GroupOrder.Equals(groupCode))
        {

        }
    }


    public class OrderListGetByTran : SpecificationBase<Order>
    {
        public OrderListGetByTran()
            : base(x => x.OrderType.Equals("TRANSPORT"))
        {

        }
    }


    public class OrderListGetByIds : SpecificationBase<Order>
    {
        public OrderListGetByIds(IList<int> ids)
            : base(x => ids.Contains(x.Id))
        {

        }
    }
    public class OrderListGetByTracking : SpecificationBase<Order>
    {
        public OrderListGetByTracking(string tracking)
            : base(x => x.Tracking.Contains(tracking))
        {

        }
    }
    public class OrderListGetBySaler : SpecificationBase<Order>
    {
        public OrderListGetBySaler(string saler)
            : base(x => x.Saler.Equals(saler))
        {

        }
    }

    #region don da mua theo purchaseAssign
    public class OrderListGetByPurchaseAssign : SpecificationBase<Order>
    {
        public OrderListGetByPurchaseAssign(string shopSell, string note, string ordertype,
        string keyword,
        string accountId,
        string purchaseAssign,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, List<string> bidAccount)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
            && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
            && ((startTime == null) || (m.LastActionDate >= startTime.Value))
            && ((endTime == null) || (m.LastActionDate <= endTime.Value))
            && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
            && (m.PurchaseBy.Contains(purchaseAssign))
            && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
            && (orderId == null || orderId.Contains(m.Id))
            && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
            && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
            && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
            && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
            && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
            && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
            && (state == null || state.Length == 0 || state.Contains(m.State))
            && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
            && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
            && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
            && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
            && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
           && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
           && (string.IsNullOrWhiteSpace(m.Tracking))
           && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
          ))
        {

        }
    }
    #endregion
    public class OrderListGetPurchaseAssign : SpecificationBase<Order>
    {
        public OrderListGetPurchaseAssign(string payer, string shopSell, string note, string ordertype,
       string keyword,
       string accountId,
       DateTime? startTime,
       DateTime? endTime,
       IList<int> orderId,
       int[] trackingStatus,
       int[] status,
       string code, string precode,
       string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
      : base(m => (
       (string.IsNullOrWhiteSpace(keyword)
           || m.Code.Contains(keyword)
           || m.CustomerName.Contains(keyword)
           || m.CustomerPhone.Contains(keyword)
           || m.CustomerProvince.Contains(keyword)
           || m.CustomerDistrict.Contains(keyword)
           || m.CustomerWard.Contains(keyword)
           || m.Title.Contains(keyword)
            || m.Saler.Contains(keyword))
       && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
       && ((startTime == null) || (m.LastActionDate >= startTime.Value))
       && ((endTime == null) || (m.LastActionDate <= endTime.Value))
       && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
       && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
       && (orderId == null || orderId.Contains(m.Id))
       && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
       && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
       && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
       && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
       && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
       && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
       && (state == null || state.Length == 0 || state.Contains(m.State))
       && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
       && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
       && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
       && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
       && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
      && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
      //&& (string.IsNullOrWhiteSpace(m.Tracking))
      && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
      && (string.IsNullOrWhiteSpace(payer) || m.PurchaseAssign.Equals(payer))
       ))
        {

        }
    }
    public class GetTotalOrderQuote : SpecificationBase<Order>
    {
        public GetTotalOrderQuote(string[] state)
         : base(m => !m.OrderType.Equals("TRANSPORT")
          && (state == null || state.Length == 0 || state.Contains(m.State))
         )
        {

        }
        public GetTotalOrderQuote(string orderType, string[] state)
         : base(m => m.OrderType.Equals(orderType)
          && (state == null || state.Length == 0 || state.Contains(m.State))
         )
        {

        }

    }
    #region đơn vc nội địa theo purchaseAssign
    public class OrderListGetByTransportByPurchaseAssign : Specification<Order>
    {
        public OrderListGetByTransportByPurchaseAssign(string payer, string shopSell, string note, string ordertype,
        string keyword,
        string accountId,
        string purchaseAssign,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
        && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (m.PurchaseBy.Contains(purchaseAssign))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (m.Tracking != null && !string.IsNullOrWhiteSpace(m.Tracking))
        && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
        && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
        && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
        ))
        {

        }
    }
    #endregion

    #region cập nhật phụ phí theo purchaseAssign
    public class SurchargeOrderListGetByPurchaseAsign : Specification<Order>
    {
        public SurchargeOrderListGetByPurchaseAsign(string payer, string note, string ordertype,
          string keyword,
          string accountId,
          string purchaseAssign,
          DateTime? startTime,
          DateTime? endTime,
          IList<int> orderId,
          int[] trackingStatus,
          int[] status,
          string code, string precode,
          string[] state, string description, string BidAccount, string Tracking, int? shippingFree,
          int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, string preCodeVC)
         : base(m => (
          (string.IsNullOrWhiteSpace(keyword)
              || m.Code.Contains(keyword)
              || m.CustomerName.Contains(keyword)
              || m.CustomerPhone.Contains(keyword)
              || m.CustomerProvince.Contains(keyword)
              || m.CustomerDistrict.Contains(keyword)
              || m.CustomerWard.Contains(keyword)
              || m.Title.Contains(keyword)
               || m.Saler.Contains(keyword))
          && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
          && ((startTime == null) || (m.LastActionDate >= startTime.Value))
          && ((endTime == null) || (m.LastActionDate <= endTime.Value))
          && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
          && (m.PurchaseBy.Contains(purchaseAssign))
          && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
          && (orderId == null || orderId.Contains(m.Id))
          && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
          && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
          && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
          && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
          && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
          && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
          && (state == null || state.Length == 0 || state.Contains(m.State))
          && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
          && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
          && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
          && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
          && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
         && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
         && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
          && (string.IsNullOrWhiteSpace(preCodeVC) || m.Code.StartsWith(preCodeVC))

          ))
        {

        }
    }
    #endregion

    #region hoan thanh giao dich

    public class ComplateGetBy : Specification<Order>
    {
        public ComplateGetBy(string payer, string note, string ordertype,
        string keyword,
        string accountId,
        string purchaseAssign,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.LastActionDate >= startTime.Value))
        && ((endTime == null) || (m.LastActionDate <= endTime.Value))
        && (string.IsNullOrWhiteSpace(accountId) || accountId.Contains(m.AccountId))
        && (m.PurchaseBy.Contains(purchaseAssign))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Note.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
        && (!string.IsNullOrWhiteSpace(m.Tracking))
        && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
        ))
        {

        }
    }
    #endregion

    #region huy don
    public class WaitingOrderCancel : Specification<Order>
    {
        public WaitingOrderCancel(string payer, string shopSell, string note, string ordertype,
        string keyword,
        string accountId,
        string purchaseAssign,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && ((startTime == null) || (m.PurchaseDate >= startTime.Value))
        && ((endTime == null) || (m.PurchaseDate <= endTime.Value))
        && (accountId == null || accountId.Contains(m.AccountId))
        && (m.PurchaseAssign.Contains(purchaseAssign))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (Tracking == null || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        && (string.IsNullOrWhiteSpace(note) || m.Note.Contains(note))
        && (string.IsNullOrWhiteSpace(shopSell) || m.Saler.Contains(shopSell))
        && (string.IsNullOrWhiteSpace(payer) || m.PurchaseBy.Equals(payer))
        ))
        {

        }
    }
    #endregion

    public class GetTotalCountWaitingAdvance : SpecificationBase<Order>
    {
        public GetTotalCountWaitingAdvance(string[] orderType, int status, string accountId)
         : base(m => (orderType.Contains(m.OrderType) && (m.Status.Equals(status)) && (string.IsNullOrEmpty(accountId) || m.AccountId.Contains(accountId))))
        {

        }
    }

    public class GetTotalCountWaitingPayment : SpecificationBase<Order>
    {
        public GetTotalCountWaitingPayment(string[] orderType, string[] state, string accountId)
         : base(m => (orderType.Contains(m.OrderType) && (state.Contains(m.State)) && (string.IsNullOrEmpty(accountId) || m.AccountId.Contains(accountId))))
        {

        }
    }


    public class GetTotalCountTransportWaitingPayment : SpecificationBase<Order>
    {
        public GetTotalCountTransportWaitingPayment(string orderType, string[] state, string accountId)
         : base(m => (orderType.Contains(m.OrderType) && (state.Contains(m.State)) && (string.IsNullOrEmpty(accountId) || m.AccountId.Contains(accountId))))
        {

        }
    }

    public class GroupOrderGetByCode : SpecificationBase<Order>
    {
        public GroupOrderGetByCode(string code)
            : base(m => m.Code.Equals(code))
        {

        }
    }

    public class GetOrderWaitingPurchase : SpecificationBase<Order>
    {
        public GetOrderWaitingPurchase(List<string> purchaseAssig, DateTime? startTime, DateTime? endTime, string state)
            : base(m => purchaseAssig.Contains(m.PurchaseAssign) && m.LastActionDate >= startTime && m.LastActionDate <= endTime && m.State.Equals(state))
        {

        }
    }


    public class GetOrderFollowGroupCode : SpecificationBase<Order>
    {
        public GetOrderFollowGroupCode(string groupCode)
            : base(m => m.GroupOrder.Equals(groupCode))
        {

        }
    }


    public class GetWaitingOrderErp : SpecificationBase<Order>
    {
        public GetWaitingOrderErp(string keyword, string accountId, string orderCode, IList<int> orderId, DateTime? startTime, DateTime? endTime, string orderType, string[] customerAccountId, string[] state, int ShippingRouteId, string preCode)
              : base(m => ((string.IsNullOrWhiteSpace(keyword)
                   || m.Code.Contains(keyword))
               && (!m.OrderType.Equals("TRANSPORT"))
               && (string.IsNullOrWhiteSpace(orderType) || m.OrderType.Equals(orderType))
               && (startTime == null || m.OrderDate >= startTime)
               && (endTime == null || m.OrderDate <= endTime)
               && (accountId == null || accountId.Contains(m.AccountId))
               && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
               && (orderId == null || orderId.Contains(m.Id))
               && (string.IsNullOrWhiteSpace(orderCode) || m.Code.Contains(orderCode))
               && (state == null || state.Length == 0 || state.Contains(m.State))
               && (m.Code.StartsWith(preCode))
              ))
        { }
    }


    public class GetOrderPurchaseErp : SpecificationBase<Order>
    {
        public GetOrderPurchaseErp(string keyword, string accountId, string orderCode, IList<int> orderId, DateTime? startTime, DateTime? endTime, string orderType, string[] customerAccountId, string[] state, int ShippingRouteId, string preCode)
              : base(m => ((string.IsNullOrWhiteSpace(keyword)
                   || m.Code.Contains(keyword))
               && (!m.OrderType.Equals("TRANSPORT"))
               && (string.IsNullOrWhiteSpace(orderType) || m.OrderType.Equals(orderType))
               && (startTime == null || m.OrderDate >= startTime)
               && (endTime == null || m.OrderDate <= endTime)
               && (accountId == null || accountId.Contains(m.AccountId))
               && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
               && (orderId == null || orderId.Contains(m.Id))
               && (string.IsNullOrWhiteSpace(orderCode) || m.Code.Contains(orderCode))
               && (state == null || state.Length == 0 || state.Contains(m.State))
               && (string.IsNullOrWhiteSpace(m.Tracking))
               && (m.Code.StartsWith(preCode))
              ))
        { }
    }


    public class GetWaitingOrderErpWithTraking : SpecificationBase<Order>
    {
        public GetWaitingOrderErpWithTraking(string keyword, string accountId, string orderCode, IList<int> orderId, DateTime? startTime, DateTime? endTime, string orderType, string[] customerAccountId, string[] state, int ShippingRouteId, string preCode)
              : base(m => ((string.IsNullOrWhiteSpace(keyword)
                   || m.Code.Contains(keyword))
               && (!m.OrderType.Equals("TRANSPORT"))
               && (string.IsNullOrWhiteSpace(orderType) || m.OrderType.Equals(orderType))
               && (startTime == null || m.OrderDate >= startTime)
               && (endTime == null || m.OrderDate <= endTime)
               && (accountId == null || accountId.Contains(m.AccountId))
               && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
               && (orderId == null || orderId.Contains(m.Id))
               && (string.IsNullOrWhiteSpace(orderCode) || m.Code.Contains(orderCode))
               && (state == null || state.Length == 0 || state.Contains(m.State))
               && (!string.IsNullOrWhiteSpace(m.Tracking))
               && (m.Code.StartsWith(preCode))
              ))
        { }
    }


    public class CancelOrderGetBy : SpecificationBase<Order>
    {
        public CancelOrderGetBy(DateTime? startTimeCancel, DateTime? endTimeCancel, string ordertype,
         string keyword,
         string accountId,
         DateTime? startTime,
         DateTime? endTime,
         IList<int> orderId,
         int[] trackingStatus,
         int[] status,
         string code, string precode,
         string[] state, string description, string BidAccount, string Tracking, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight, int ShippingRouteId)
        : base(m => (
         (string.IsNullOrWhiteSpace(keyword)
             || m.Code.Contains(keyword)
             || m.CustomerName.Contains(keyword)
             || m.CustomerPhone.Contains(keyword)
             || m.CustomerProvince.Contains(keyword)
             || m.CustomerDistrict.Contains(keyword)
             || m.CustomerWard.Contains(keyword)
             || m.Title.Contains(keyword)
              || m.Saler.Contains(keyword))
         && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
         && ((startTime == null) || (m.LastActionDate >= startTime.Value))
         && ((endTime == null) || (m.LastActionDate <= endTime.Value))
         && (accountId == null || accountId.Contains(m.AccountId))
         && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
         && (orderId == null || orderId.Contains(m.Id))
         && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
         && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
         && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
         && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
         && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
         && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
         && (Tracking == null || m.Tracking.Contains(Tracking))
         && (state == null || state.Length == 0 || state.Contains(m.State))
         && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
         && (preTracking == null || (preTracking == 0 ? string.IsNullOrEmpty(m.Tracking) : !string.IsNullOrEmpty(m.Tracking)))
         && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
         && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
         && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
         && (startTimeCancel == null || m.CancelDate >= startTimeCancel.Value)
         && (endTimeCancel == null || m.CancelDate <= endTimeCancel.Value)
         //&& (m.ShippingRouteId == ShippingRouteId)
         ))
        {

        }
    }

    public class OrderAuctionPretreatmentGetBy : SpecificationBase<Order>
    {
        public OrderAuctionPretreatmentGetBy(string ordertype,
        string keyword,
        string accountId,
        string yaUserName,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount, string Tracking, string saler, int? shippingFree, int? Paid, string PreState, string[] customerAccountId, int? preTracking, int? Weight)
       : base(m => (
        (string.IsNullOrWhiteSpace(keyword)
            || m.Code.Contains(keyword)
            || m.CustomerName.Contains(keyword)
            || m.CustomerPhone.Contains(keyword)
            || m.CustomerProvince.Contains(keyword)
            || m.CustomerDistrict.Contains(keyword)
            || m.CustomerWard.Contains(keyword)
            || m.Title.Contains(keyword)
             || m.Saler.Contains(keyword))
        && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
        && (m.Code.StartsWith("JPD"))
        && (startTime == null || m.LastActionDate >= startTime.Value)
        && (endTime == null || m.LastActionDate <= endTime.Value)
        && (accountId == null || accountId.Contains(m.AccountId))
        && (customerAccountId == null || customerAccountId.Contains(m.AccountId))
        && (orderId == null || orderId.Contains(m.Id))
        && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
        && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
        && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
        && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
        && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
        && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
        && (string.IsNullOrWhiteSpace(Tracking) || m.Tracking.Contains(Tracking))
        && (state == null || state.Length == 0 || state.Contains(m.State))
        && (shippingFree == null || (shippingFree == 0 ? m.ShippingFee == null : m.ShippingFee != null))
        && (preTracking == null || (preTracking == 0 ? m.Tracking == null : m.Tracking != null))
        && (Weight == null || (Weight == 0 ? m.Weight == null : m.Weight != null))
        && (Paid == null || (Paid == 0 ? m.Paid == null : (m.Paid != null && m.Paid > 0)))
        && (string.IsNullOrWhiteSpace(PreState) || m.State.Contains(PreState))
        ))
        {

        }
    }


    public class GetTransportCancel : Specification<Order>
    {
        public GetTransportCancel(string ordertype,
        string keyword,
        string customerAccountId,
        DateTime? startTime,
        DateTime? endTime,
        IList<int> orderId,
        int[] trackingStatus,
        int[] status,
        string code, string precode,
        string[] state, string description, string BidAccount,
        string[] ListCustomerAccountIdBySale, string tracking,
        string preCode, int? shippingRouteId, DateTime? DepartureDateFrom, DateTime? DepartureDateTo)
        : base(m => ((string.IsNullOrWhiteSpace(keyword)
             || m.Code.Contains(keyword)
             || m.CustomerName.Contains(keyword)
             || m.CustomerPhone.Contains(keyword)
             || m.CustomerProvince.Contains(keyword)
             || m.CustomerDistrict.Contains(keyword)
             || m.CustomerWard.Contains(keyword)
             || m.Title.Contains(keyword))
         && (string.IsNullOrWhiteSpace(ordertype) || m.OrderType.Equals(ordertype))
         && ((startTime == null || endTime == null) || (m.OrderDate >= startTime.Value && m.OrderDate <= endTime.Value))
         && (string.IsNullOrWhiteSpace(customerAccountId) || m.AccountId.Contains(customerAccountId))
         && (ListCustomerAccountIdBySale == null || ListCustomerAccountIdBySale.Contains(m.AccountId))
         && (orderId == null || orderId.Contains(m.Id))
         && (trackingStatus == null || trackingStatus.Length == 0 || (m.TrackingStatus.HasValue && trackingStatus.Contains(m.TrackingStatus.Value)))
         && (status == null || status.Length == 0 || (m.Status.HasValue && status.Contains(m.Status.Value)))
         && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
         && (string.IsNullOrWhiteSpace(precode) || m.Code.StartsWith(precode))
         && (string.IsNullOrWhiteSpace(description) || m.Title.Contains(description))
         && (string.IsNullOrWhiteSpace(BidAccount) || m.BidAccount.Equals(BidAccount))
         && (string.IsNullOrWhiteSpace(tracking) || m.Tracking.Equals(tracking))
         && (state == null || state.Length == 0 || state.Contains(m.State))
         && (string.IsNullOrWhiteSpace(preCode) || m.Code.StartsWith(preCode))
         && (shippingRouteId == null || m.ShippingRouteId == shippingRouteId)
         && (DepartureDateFrom == null || m.DepartureDate >= DepartureDateFrom)
         && (DepartureDateTo == null || m.DepartureDate <= DepartureDateTo)
         && (m.Status == 8)
        ))
        {

        }
    }

    public class GetByListTracking : Specification<Order>
    {
        public GetByListTracking(List<string> listTracking)
        : base(m => (listTracking.Contains(m.Tracking)))
        {

        }
    }

    public class GetByTracking : Specification<Order>
    {
        public GetByTracking(string tracking)
        : base(m => m.Tracking.Equals(tracking))
        {

        }
    }
}
