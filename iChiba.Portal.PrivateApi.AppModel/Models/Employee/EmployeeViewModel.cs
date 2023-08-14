using System;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AccountId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? SyncAccStatus { get; set; }
        public DateTime? SyncAccDate { get; set; }
    }
}
