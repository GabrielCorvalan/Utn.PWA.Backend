using System;

namespace Utn.PWA.DTOs
{
    public class CompanyTutorDTO : BaseDTO
    {
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public int? CompanyId { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
