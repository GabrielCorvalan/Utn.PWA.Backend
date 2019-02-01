using System;
using System.Collections.Generic;

namespace Utn.PWA.Entity.Models
{
    public partial class Rols
    {
        public Rols()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
