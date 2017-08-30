namespace MillData.Models
{
    public partial class FlowData
    {
        public int PkFlowId { get; set; }
        public int? FkMillKey { get; set; }
        public int? FkFlowType { get; set; }
        public string FlowDescription { get; set; }
        public float? FlowMmgd { get; set; }
        public float? RetDays { get; set; }
        public string WaterBodyType { get; set; }
        public string WaterBodyName { get; set; }
        public int? WaterBodySegment { get; set; }
        public int? WaterBodyMile { get; set; }
        public int? FkSourceId { get; set; }
        public int? SourceYear { get; set; }
        public string Comments { get; set; }

        public virtual FlowType FkFlowTypeNavigation { get; set; }
        public virtual MillInformation FkMillKeyNavigation { get; set; }
        public virtual Source FkSource { get; set; }
    }
}
