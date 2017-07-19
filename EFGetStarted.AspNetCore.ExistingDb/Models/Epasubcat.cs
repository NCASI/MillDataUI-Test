using System;
using System.Collections.Generic;

namespace MillData.Models
{
    public partial class Epasubcat
    {
        public Epasubcat()
        {
            MillInformation = new HashSet<MillInformation>();
            NcasiprodCat = new HashSet<NcasiprodCat>();
        }

        public int PkSubcatId { get; set; }
        public string Subcat { get; set; }
        public string Fiber { get; set; }
        public string SubcatDescription { get; set; }

        public virtual ICollection<MillInformation> MillInformation { get; set; }
        public virtual ICollection<NcasiprodCat> NcasiprodCat { get; set; }
    }
}
