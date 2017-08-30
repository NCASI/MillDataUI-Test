﻿namespace MillData.Models
{
    public class Env_ProductionData
    {
        public int PkEnvProdId { get; set; }
        public int FkFacilityKey { get; set; }
        public int FkWoodThicknessId { get; set; }
        public string ProdType { get; set; }
        public string Category { get; set; }
        public float? Amount { get; set; }
        public string Units { get; set; }
        public string Comments { get; set; }

        public virtual Env_WoodThickness FkWoodThickness { get; set; }
        public virtual Env_Facility FkFacility { get; set; }
    }
}
