using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MillData.Models
{
    public partial class ProductionData
    {
        public int PkProductionId { get; set; }

        [DisplayName("Mill ID")]
        public int? FkMillKey { get; set; }

        [DisplayName("Production Category")]
        public int? FkProdCatId { get; set; }
        public float? Quantity { get; set; }
        public string Units { get; set; }

        [DisplayName("Source")]
        public int? FkSourceId { get; set; }

        [DisplayName("Year")]
        public int? SourceYear { get; set; }
        public string Comments { get; set; }

        public virtual MillInformation FkMillKeyNavigation { get; set; }
        public virtual NcasiprodCat FkProdCat { get; set; }
        public virtual Source FkSource { get; set; }
    }
}
