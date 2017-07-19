using System;
using System.Collections.Generic;

namespace MillData.Models
{
    public partial class MillCodischarger
    {
        public int PkCodischargeId { get; set; }
        public int? FkMillKey1 { get; set; }
        public int? FkMillKey2 { get; set; }

        public virtual MillInformation FkMillKey1Navigation { get; set; }
        public virtual MillInformation FkMillKey2Navigation { get; set; }
    }
}
