using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class NpdesdocType
    {
        public NpdesdocType()
        {
            Npdesdocs = new HashSet<Npdesdocs>();
        }

        public int DocTypeId { get; set; }
        public string DocType { get; set; }

        public virtual ICollection<Npdesdocs> Npdesdocs { get; set; }
    }
}
