using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class FlowType
    {
        public FlowType()
        {
            FlowData = new HashSet<FlowData>();
            WaterTreatmentData = new HashSet<WaterTreatmentData>();
        }

        public int FlowTypeId { get; set; }
        public string FlowTypeName { get; set; }

        public virtual ICollection<FlowData> FlowData { get; set; }
        public virtual ICollection<WaterTreatmentData> WaterTreatmentData { get; set; }
    }
}
