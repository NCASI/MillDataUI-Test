namespace MillData.Models
{
    public partial class MillCodeLinks
    {
        public int MillCodeLinkId { get; set; }
        public int? FkMillKey { get; set; }
        public int? Lwp { get; set; }
        public string Fisher { get; set; }
        public int? Fpac { get; set; }

        public virtual MillInformation FkMillKeyNavigation { get; set; }
    }
}
