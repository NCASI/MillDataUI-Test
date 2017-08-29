using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillData.Models
{
    public class Env_Facility
    {

        public Env_Facility()
        {
            //TODO: ADD ENV_FACILITY CONSTRUCTOR
        }

        public int PkEnvFacilityKey { get; set; }
        public int? FkMillkey { get; set; }
        public bool? NotAfpa { get; set; }
        public int? FK_ParentKey { get; set; }
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
        public float? Penalty { get; set; }
        public string PenaltyComments { get; set; }
        public string GenComments { get; set; }
        public string FossilFuelComments { get; set; }
        public string BiomassComments { get; set; }
        public string EnergyComments { get; set; }
        public string NtProducts { get; set; }



        public virtual Env_WoodThickness FkWoodThicknessIdNavigation { get; set; }



    }
}
