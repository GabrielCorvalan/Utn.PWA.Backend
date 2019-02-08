using System;
using System.Collections.Generic;

namespace Utn.PWA.Entity.Models
{
    public partial class Pages
    {
        public Pages()
        {
            PagesRols = new HashSet<PagesRols>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Tittle { get; set; }
        public bool Deleted { get; set; }

        public ICollection<PagesRols> PagesRols { get; set; }
    }
}
