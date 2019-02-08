using System;
using System.Collections.Generic;

namespace Utn.PWA.Entity.Models
{
    public partial class Interships
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CompanyId { get; set; }
        public int? CompanyTutorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalaryWorkAssignment { get; set; }
        public string WorkAgreement { get; set; }
        public string CompanySignatory { get; set; }
        public short DailyHours { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserCreatedId { get; set; }
        public DateTime? LastModified { get; set; }
        public int? UserLasModifiedId { get; set; }
        public DateTime? CancellationDate { get; set; }
        public int? UserCancelattionId { get; set; }
        public string TaskDescription { get; set; }
        public string CancellationDescription { get; set; }
        public DateTime? RenovationDate { get; set; }
        public int? UserRenovationId { get; set; }
        public string ConfirmationState { get; set; }
        public string Observations { get; set; }
        public string State { get; set; }
        public bool Deleted { get; set; }

        public Companies Company { get; set; }
        public CompanyTutor CompanyTutor { get; set; }
        public Students Student { get; set; }
        public Users UserCancelattion { get; set; }
        public Users UserCreated { get; set; }
        public Users UserLasModified { get; set; }
        public Users UserRenovation { get; set; }
    }
}
