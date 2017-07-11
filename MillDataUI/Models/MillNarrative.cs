using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class MillNarrative
    {
        public int NarrativeId { get; set; }
        public int? FkMillId { get; set; }
        public string MillNarrative1 { get; set; }

        public virtual MillInformation FkMill { get; set; }
    }
}
