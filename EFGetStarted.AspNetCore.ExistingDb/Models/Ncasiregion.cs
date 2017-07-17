using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.ExistingDb.Models
{
    public partial class Ncasiregion
    {
        public Ncasiregion()
        {
            Region = new HashSet<Region>();
        }

        public int PkRegionCodeId { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<Region> Region { get; set; }
    }
}
