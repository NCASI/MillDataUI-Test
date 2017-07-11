using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class Source
    {
        public Source()
        {
            FlowData = new HashSet<FlowData>();
            ProductionData = new HashSet<ProductionData>();
            SludgeData = new HashSet<SludgeData>();
            WaterTreatmentData = new HashSet<WaterTreatmentData>();
        }

        public int SourceId { get; set; }
        public string DataSource { get; set; }
        public string SourceDescription { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string SourceComments { get; set; }

        public virtual ICollection<FlowData> FlowData { get; set; }
        public virtual ICollection<ProductionData> ProductionData { get; set; }
        public virtual ICollection<SludgeData> SludgeData { get; set; }
        public virtual ICollection<WaterTreatmentData> WaterTreatmentData { get; set; }
    }
}
