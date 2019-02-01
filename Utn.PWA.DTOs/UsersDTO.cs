using System;

namespace Utn.PWA.DTOs
{
    public class UsersDTO : BaseDTO
    {
        public int? RolId { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string UniversityPosition { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public RolDTO Rol { get; set; }
    }
}
