using System;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class CustomerInfoHomePageModel
    {
        public CustomerViewModel Customer { get; set; }
        public CustomerAggregateInfoViewModel CustomerAggregateInfo { get; set; }
    }

    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AccountId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Avatar { get; set; }
        public string Website { get; set; }
        public string IdImages { get; set; }
        public string IdNumber { get; set; }
        public string IdName { get; set; }
        public string IdAddress { get; set; }
        public string IdPermanentAddress { get; set; }
        public DateTime? IdBirthDay { get; set; }
        public DateTime? IdIssuedDate { get; set; }
        public string IdIssuedBy { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CareBy { get; set; }
        public bool? BidActive { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string Code { get; set; }
        public DateTime? CodeCreatedDate { get; set; }
        public string Group { get; set; }
        public string TranCode { get; set; }
        public bool? TranActive { get; set; }
        public int? SyncAccStatus { get; set; }
        public DateTime? SyncAccDate { get; set; }
        public string SyncAccCode { get; set; }
        public string Domain { get; set; }
        /// <summary>
        /// GTTT mặt trước
        /// </summary>
        public string IdImageFront { get; set; }
        /// <summary>
        /// GTTT mặt sau
        /// </summary>
        public string IdImageBack { get; set; }
        /// <summary>
        /// Bỏ qua, không cần ký hợp đồng điện tử
        /// </summary>
        public bool BypassSignEcontract { get; set; }
        public string Saler { get; set; }
        public string SalerPhone { get; set; }
    }

    public class CustomerAggregateInfoViewModel
    {
        public decimal TotalAvailableCash { get; set; }
        public decimal TotalCashFreeze { get; set; }
        public int CountAllOrder { get; set; }
        public int CountOrderWaitDelivery { get; set; }
        public int CountOrderDelivered { get; set; }
        public decimal TotalPaymentProcessed { get; set; }
        public decimal TotalPaymentApproved { get; set; }
        public decimal TotalPaymentWaitOrder { get; set; }
    }
}
