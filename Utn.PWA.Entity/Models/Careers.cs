using System;
using System.Collections.Generic;

namespace Utn.PWA.Entity.Models
{
    public partial class Careers
    {
        public Careers()
        {
            Students = new HashSet<Students>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public ICollection<Students> Students { get; set; }
    }
}
