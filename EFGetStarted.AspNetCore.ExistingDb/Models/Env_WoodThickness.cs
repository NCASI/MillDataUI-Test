using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillData.Models
{
    public partial class Env_WoodThickness
    {
        public Env_Facility()
        {
            Env_ProductionData = new HashSet<Env_ProductionData>();
        }
        public int PkWoodKey { get; set; }
        public int? WoodId { get; set; }
        public float? Amount { get; set; }
        public float? Thickness { get; set; }
        public float? CF { get; set; }
        public string Units { get; set; }

        public virtual ICollection<Env_ProductionData> Env_ProductionData { get; set; }
    }
}
