using System;

namespace Utn.PWA.DTOs
{
    public class InternshipDTO : BaseDTO
    {
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

        public CompanyDTO Company { get; set; }
        public CompanyTutorDTO CompanyTutor { get; set; }
        public StudentDTO Student { get; set; }
    }
}
