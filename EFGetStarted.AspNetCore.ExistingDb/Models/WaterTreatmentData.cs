using System;
using System.Collections.Generic;

namespace MillData.Models
{
    public partial class WaterTreatmentData
    {
        public int PkWaterTreatmentId { get; set; }
        public int? FkMillKey { get; set; }
        public int? FkFlowType { get; set; }
        public string Stage { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? FkSourceId { get; set; }
        public int? SourceYear { get; set; }
        public string Comments { get; set; }

        public virtual FlowType FkFlowTypeNavigation { get; set; }
        public virtual MillInformation FkMillKeyNavigation { get; set; }
        public virtual Source FkSource { get; set; }
    }
}
