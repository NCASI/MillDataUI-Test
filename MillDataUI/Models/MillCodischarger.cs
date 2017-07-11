using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class MillCodischarger
    {
        public int CodischargeId { get; set; }
        public int? MillKey1 { get; set; }
        public int? MillKey2 { get; set; }

        public virtual MillInformation MillKey1Navigation { get; set; }
        public virtual MillInformation MillKey2Navigation { get; set; }
    }
}
