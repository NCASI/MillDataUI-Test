namespace MillData.Models
{
    public partial class MillNarrative
    {
        public int PkNarrativeId { get; set; }
        public int? FkMillKey { get; set; }
        public string MillNarrative1 { get; set; }

        public virtual MillInformation FkMillKeyNavigation { get; set; }
    }
}
