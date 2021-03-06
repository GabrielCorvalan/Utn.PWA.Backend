﻿using System;
using System.Collections.Generic;

namespace Utn.PWA.Entity.Models
{
    public partial class Rols
    {
        public Rols()
        {
            PagesRols = new HashSet<PagesRols>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public ICollection<PagesRols> PagesRols { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
