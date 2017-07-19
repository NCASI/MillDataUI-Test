using System;
using System.Collections.Generic;

namespace MillData.Models
{
    public partial class MillSiccodes
    {
        public int PkMillSicid { get; set; }
        public int? FkMillKey { get; set; }
        public int FkSiccodeId { get; set; }

        public virtual MillInformation FkMillKeyNavigation { get; set; }
        public virtual Siccode FkSiccode { get; set; }
    }
}
