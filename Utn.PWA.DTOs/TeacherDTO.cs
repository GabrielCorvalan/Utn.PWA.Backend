using System;
using System.Collections.Generic;

namespace Utn.PWA.DTOs
{
    public class TeacherDTO : BaseDTO
    {
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string File { get; set; }
        public string Sex { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
