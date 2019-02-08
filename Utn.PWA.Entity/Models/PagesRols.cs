using System;
using System.Collections.Generic;

namespace Utn.PWA.Entity.Models
{
    public partial class PagesRols
    {
        public int PageId { get; set; }
        public int RolId { get; set; }
        public bool Write { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }

        public Pages Page { get; set; }
        public Rols Rol { get; set; }
    }
}
