﻿using System.Collections.Generic;

namespace MillData.Models
{
    public partial class NpdesdocType
    {
        public NpdesdocType()
        {
            Npdesdocs = new HashSet<Npdesdocs>();
        }

        public int PkDocTypeId { get; set; }
        public string DocType { get; set; }

        public virtual ICollection<Npdesdocs> Npdesdocs { get; set; }
    }
}
