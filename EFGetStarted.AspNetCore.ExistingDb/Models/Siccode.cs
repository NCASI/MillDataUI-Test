using System.Collections.Generic;

namespace MillData.Models
{
    public partial class Siccode
    {
        public Siccode()
        {
            MillSiccodes = new HashSet<MillSiccodes>();
        }

        public int PkSiccodeId { get; set; }
        public int? Siccode1 { get; set; }

        public virtual ICollection<MillSiccodes> MillSiccodes { get; set; }
    }
}
