using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class Npdesdocs
    {
        public int DocId { get; set; }
        public int? FkNpdesid { get; set; }
        public string DocPath { get; set; }
        public int? FkDocTypeId { get; set; }

        public virtual NpdesdocType FkDocType { get; set; }
        public virtual Npdes FkNpdes { get; set; }
    }
}
