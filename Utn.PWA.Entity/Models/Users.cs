using System;
using System.Collections.Generic;

namespace Utn.PWA.Entity.Models
{
    public partial class Users
    {
        public Users()
        {
            IntershipsUserCancelattion = new HashSet<Interships>();
            IntershipsUserCreated = new HashSet<Interships>();
            IntershipsUserLasModified = new HashSet<Interships>();
            IntershipsUserRenovation = new HashSet<Interships>();
        }

        public int Id { get; set; }
        public int? RolId { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string UniversityPosition { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Deleted { get; set; }

        public Rols Rol { get; set; }
        public ICollection<Interships> IntershipsUserCancelattion { get; set; }
        public ICollection<Interships> IntershipsUserCreated { get; set; }
        public ICollection<Interships> IntershipsUserLasModified { get; set; }
        public ICollection<Interships> IntershipsUserRenovation { get; set; }
    }
}
