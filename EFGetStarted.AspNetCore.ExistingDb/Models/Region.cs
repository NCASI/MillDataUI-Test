namespace MillData.Models
{
    public partial class Region
    {
        public int PkRegionId { get; set; }
        public string OldNcasiregion { get; set; }
        public int FkNcasiregionId { get; set; }
        public int? Eparegion { get; set; }
        public string Subregion { get; set; }
        public string State { get; set; }

        public virtual Ncasiregion FkNcasiregion { get; set; }
    }
}
