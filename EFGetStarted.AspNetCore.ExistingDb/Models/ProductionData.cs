using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.ExistingDb.Models
{
    public partial class ProductionData
    {
        public int PkProductionId { get; set; }
        public int? FkMillKey { get; set; }
        public int? FkProdCatId { get; set; }
        public float? Quantity { get; set; }
        public string Units { get; set; }
        public int? FkSourceId { get; set; }
        public int? SourceYear { get; set; }
        public string Comments { get; set; }

        public virtual MillInformation FkMillKeyNavigation { get; set; }
        public virtual NcasiprodCat FkProdCat { get; set; }
        public virtual Source FkSource { get; set; }
    }
}
