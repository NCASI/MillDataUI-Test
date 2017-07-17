using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.ExistingDb.Models
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
