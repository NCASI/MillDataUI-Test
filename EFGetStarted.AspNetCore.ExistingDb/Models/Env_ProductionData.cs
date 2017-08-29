using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillData.Models
{
    public class Env_ProductionData
    {
        public int PkEnvProdId { get; set; }
        public int FkFacilityKey { get; set; }
        public string ProdType { get; set; }
        public string Category { get; set; }
        public float? Amount { get; set; }
        public string Units { get; set; }
        public string Comments { get; set; }

        public virtual Env_WoodThickness FkWoodThicknessIdNavigation { get; set; }
    }
}
