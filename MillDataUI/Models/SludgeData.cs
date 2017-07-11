using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class SludgeData
    {
        public int SludgeId { get; set; }
        public int FkMillKey { get; set; }
        public string SludgeType { get; set; }
        public float? Tpy { get; set; }
        public string DisposalOpt { get; set; }
        public int? FkSourceId { get; set; }
        public int? SourceYear { get; set; }
        public string Comments { get; set; }

        public virtual MillInformation FkMillKeyNavigation { get; set; }
        public virtual Source FkSource { get; set; }
    }
}
