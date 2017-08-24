using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillData.Models
{
    public partial class Env_WoodThickness
    {
        public int PkWoodKey { get; set; }
        public int? WoodId { get; set; }
        public float? Amount { get; set; }
        public float? Thickness { get; set; }
        public float? CF { get; set; }
        public string Units { get; set; }

        public virtual Env_ProductionData FkProductionDataNavigation { get; set; }
    }
}
