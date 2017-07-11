using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class Siccode
    {
        public Siccode()
        {
            MillSiccodes = new HashSet<MillSiccodes>();
        }

        public int SiccodeId { get; set; }
        public int? Siccode1 { get; set; }

        public virtual ICollection<MillSiccodes> MillSiccodes { get; set; }
    }
}
