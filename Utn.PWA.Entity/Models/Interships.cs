using System;
using System.Collections.Generic;

namespace Utn.PWA.Entity.Models
{
    public partial class Interships
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CompanyId { get; set; }
        public int? CompanyMentorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalaryWorkAssignment { get; set; }
        public string WorkAgreement { get; set; }
        public string CompanySignatory { get; set; }
        public short DailyHours { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UserCreated { get; set; }
        public DateTime LastModified { get; set; }
        public int? UserLasModified { get; set; }
        public DateTime? CancellationDate { get; set; }
        public int? UserCancelattion { get; set; }
        public string TaskDescription { get; set; }
        public string CancellationDescription { get; set; }
        public DateTime? RenovationDate { get; set; }
        public int? UserRenovation { get; set; }
        public string ConfirmationState { get; set; }
        public string Observations { get; set; }
        public string State { get; set; }
        public bool Deleted { get; set; }

        public Companies Company { get; set; }
        public CompanyMentor CompanyMentor { get; set; }
        public Students Student { get; set; }
        public Users UserCancelattionNavigation { get; set; }
        public Users UserCreatedNavigation { get; set; }
        public Users UserLasModifiedNavigation { get; set; }
        public Users UserRenovationNavigation { get; set; }
    }
}
