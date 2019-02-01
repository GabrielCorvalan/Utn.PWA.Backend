using System;
using System.Collections.Generic;

namespace Utn.PWA.Entity.Models
{
    public partial class CompanyMentor
    {
        public CompanyMentor()
        {
            Interships = new HashSet<Interships>();
        }

        public int Id { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }
        public string Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public int? CompanyId { get; set; }

        public Companies Company { get; set; }
        public ICollection<Interships> Interships { get; set; }
    }
}
