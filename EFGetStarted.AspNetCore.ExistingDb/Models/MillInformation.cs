using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.ExistingDb.Models
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
        public int MillId { get; set; }
        public int? FkMillTypeId { get; set; }
        public string Company { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? FkEpasubcatId { get; set; }
        public string Naprodcat { get; set; }
        public string ProdCat1 { get; set; }
        public string ProdCat2 { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostcode { get; set; }
        public string ShippingCountry { get; set; }
        public string PostalAddress { get; set; }
        public string PostalAddress2 { get; set; }
        public string PostalCity { get; set; }
        public string PostalState { get; set; }
        public string PostalPostcode { get; set; }
        public string PostalCountry { get; set; }
        public int? Eparegion { get; set; }
        public string Website { get; set; }
        public string Comments { get; set; }
        public string MillStatus { get; set; }
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
        public virtual Epasubcat FkEpasubcat { get; set; }
        public virtual MillType FkMillType { get; set; }
    }
}
