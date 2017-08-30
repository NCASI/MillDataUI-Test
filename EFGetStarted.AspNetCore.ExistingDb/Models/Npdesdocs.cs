namespace MillData.Models
{
    public partial class Npdesdocs
    {
        public int PkDocId { get; set; }
        public int? FkNpdeskey { get; set; }
        public string DocPath { get; set; }
        public int? FkDocTypeId { get; set; }

        public virtual NpdesdocType FkDocType { get; set; }
        public virtual Npdes FkNpdeskeyNavigation { get; set; }
    }
}
