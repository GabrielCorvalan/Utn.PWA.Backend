using System;

namespace Utn.PWA.DTOs
{
    public class InternshipFilterDTO
    {
        public DateTime? dateStart { get; set; }
        public DateTime? dateEnd { get; set; }
        public string genre { get; set; }
        public int companyId { get; set; }
        public int companyTutorId { get; set; }
        public int careerId { get; set; }
        public string state { get; set; }
    }
}