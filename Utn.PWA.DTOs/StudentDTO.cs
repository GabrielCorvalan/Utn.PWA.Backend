using System;
using System.Collections.Generic;

namespace Utn.PWA.DTOs
{
    public class StudentDTO : BaseDTO
    {
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string File { get; set; }
        public int? CareerId { get; set; }
        public int? TeacherGuideId { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }

        public CareerDTO Career { get; set; }
        public TeacherDTO TeacherGuide { get; set; }
    }
}
