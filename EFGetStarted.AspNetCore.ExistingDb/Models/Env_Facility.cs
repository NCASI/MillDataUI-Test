using System.Collections.Generic;

namespace MillData.Models
{
    public class Env_Facility
    {
        //TODO: ADD MORE TABLE CONNECTIONS AS NECESSARY
        public Env_Facility()
        {
            Env_ProductionData = new HashSet<Env_ProductionData>();
        }

        public int PkEnvFacilityKey { get; set; }
        public int? FkMillkey { get; set; }
        public bool? NotAfpa { get; set; }
        public int? FkParentKey { get; set; }
        public int? Year { get; set; }
        public string Company { get; set; }
        public bool? HasCodischarge { get; set; }
        public bool? CoBod { get; set; }
        public bool? CoTss { get; set; }
        public bool? CoFlow { get; set; }
        public bool? CoSludge { get; set; }
        public bool? CoAllSw { get; set; }
        public bool? CoBoilers { get; set; }
        public bool? CoTri { get; set; }
        public int? FkProdCatId { get; set; }
        public string Eprodcat { get; set; }
        public int? MosOp { get; set; }
        public string PrimaryProd { get; set; }
        public string SecondaryProd { get; set; }
        public int? NumSpills { get; set; }
        public string SpillComments { get; set; }
        public decimal Penalty { get; set; }
        public string PenaltyComments { get; set; }
        public string GenComments { get; set; }
        public string FossilFuelComments { get; set; }
        public string BiomassComments { get; set; }
        public string EnergyComments { get; set; }
        public string NtProducts { get; set; }



        public virtual ICollection<Env_ProductionData> Env_ProductionData { get; set; }

        public virtual MillInformation FkMillInformation { get; set; }
        public virtual NcasiprodCat FkNcasiProdcat { get; set; }


    }
}
