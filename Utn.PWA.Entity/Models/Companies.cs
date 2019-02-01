using System;
using System.Collections.Generic;

namespace Utn.PWA.Entity.Models
{
    public partial class Companies
    {
        public Companies()
        {
            CompanyMentor = new HashSet<CompanyMentor>();
            Interships = new HashSet<Interships>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }
        public string Address { get; set; }

        public ICollection<CompanyMentor> CompanyMentor { get; set; }
        public ICollection<Interships> Interships { get; set; }
    }
}
