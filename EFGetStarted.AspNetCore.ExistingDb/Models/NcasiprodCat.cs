using System;
using System.Collections.Generic;

namespace MillData.Models
{
    public partial class NcasiprodCat
    {
        public NcasiprodCat()
        {
            HistoricalMillInfo = new HashSet<HistoricalMillInfo>();
            ProductionData = new HashSet<ProductionData>();
        }

        public int PkProdCatId { get; set; }
        public string FacType { get; set; }
        public string ProdType { get; set; }
        public string Category { get; set; }
        public string ProdCatDescription { get; set; }
        public int? FkEpasubcatId { get; set; }
        public string FiberSource { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<HistoricalMillInfo> HistoricalMillInfo { get; set; }
        public virtual ICollection<ProductionData> ProductionData { get; set; }
        public virtual Epasubcat FkEpasubcat { get; set; }
    }
}
