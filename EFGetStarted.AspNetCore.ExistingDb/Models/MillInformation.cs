using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MillData.Models
{
    public partial class MillInformation
    {
        public MillInformation()
        {
            FlowData = new HashSet<FlowData>();
            HistoricalMillInfo = new HashSet<HistoricalMillInfo>();
            MillCodeLinks = new HashSet<MillCodeLinks>();
            MillCodischargerFkMillKey1Navigation = new HashSet<MillCodischarger>();
            MillCodischargerFkMillKey2Navigation = new HashSet<MillCodischarger>();
            MillContactInfo = new HashSet<MillContactInfo>();
            MillNarrative = new HashSet<MillNarrative>();
            MillParentRelationship = new HashSet<MillParentRelationship>();
            MillSiccodes = new HashSet<MillSiccodes>();
            Npdes = new HashSet<Npdes>();
            ProductionData = new HashSet<ProductionData>();
            SludgeData = new HashSet<SludgeData>();
            WaterTreatmentData = new HashSet<WaterTreatmentData>();
        }

        public int PkMillKey { get; set; }

        [DisplayName("Mill ID")]
        public int MillId { get; set; }

        public int? FkMillTypeId { get; set; }

        
        public string Company { get; set; }

        [DisplayName("Coordinates")]
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        
        public int? FkEpasubcatId { get; set; }

        [DisplayName("NA Benchmarking Category")]
        public string Naprodcat { get; set; }

        [DisplayName("NCASI Product Cat 1")]
        public string ProdCat1 { get; set; }

        [DisplayName("NCASI Product Cat 2")]
        public string ProdCat2 { get; set; }

        [DisplayName("Shipping Address")]
        public string ShippingAddress { get; set; }

        [DisplayName("")]
        public string ShippingAddress2 { get; set; }

        [DisplayName("City")]
        public string ShippingCity { get; set; }

        [DisplayName("State")]
        public string ShippingState { get; set; }

        [DisplayName("Postcode")]
        public string ShippingPostcode { get; set; }

        [DisplayName("")]
        public string ShippingCountry { get; set; }

        [DisplayName("Postal Address")]
        public string PostalAddress { get; set; }

        [DisplayName("")]
        public string PostalAddress2 { get; set; }

        [DisplayName("City")]
        public string PostalCity { get; set; }

        [DisplayName("State")]
        public string PostalState { get; set; }

        [DisplayName("Postcode")]
        public string PostalPostcode { get; set; }

        [DisplayName("")]
        public string PostalCountry { get; set; }

        [DisplayName("EPA Region")]
        public int? Eparegion { get; set; }
        public string Website { get; set; }
        public string Comments { get; set; }

        [DisplayName("Mill Status")]
        public string MillStatus { get; set; }

        [DisplayName("Last Updated")]
        public DateTime? StatusDate { get; set; }

        public virtual ICollection<FlowData> FlowData { get; set; }
        public virtual ICollection<HistoricalMillInfo> HistoricalMillInfo { get; set; }
        public virtual ICollection<MillCodeLinks> MillCodeLinks { get; set; }
        public virtual ICollection<MillCodischarger> MillCodischargerFkMillKey1Navigation { get; set; }
        public virtual ICollection<MillCodischarger> MillCodischargerFkMillKey2Navigation { get; set; }
        public virtual ICollection<MillContactInfo> MillContactInfo { get; set; }
        public virtual ICollection<MillNarrative> MillNarrative { get; set; }
        public virtual ICollection<MillParentRelationship> MillParentRelationship { get; set; }
        public virtual ICollection<MillSiccodes> MillSiccodes { get; set; }
        public virtual ICollection<Npdes> Npdes { get; set; }
        public virtual ICollection<ProductionData> ProductionData { get; set; }
        public virtual ICollection<SludgeData> SludgeData { get; set; }
        public virtual ICollection<WaterTreatmentData> WaterTreatmentData { get; set; }

        [DisplayName("EPA Subcategory")]
        public virtual Epasubcat FkEpasubcat { get; set; }

        [DisplayName("Mill Type")]
        public virtual MillType FkMillType { get; set; }
    }
}
