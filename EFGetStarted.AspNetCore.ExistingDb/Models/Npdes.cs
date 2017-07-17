using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.ExistingDb.Models
{
    public partial class Npdes
    {
        public Npdes()
        {
            Npdesdocs = new HashSet<Npdesdocs>();
        }

        public int PkNpdeskey { get; set; }
        public int? FkMillKey { get; set; }
        public string Npdesid { get; set; }
        public string PermitLatitude { get; set; }
        public string PermitLongitude { get; set; }
        public bool? NotProcess { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<Npdesdocs> Npdesdocs { get; set; }
        public virtual MillInformation FkMillKeyNavigation { get; set; }
    }
}
