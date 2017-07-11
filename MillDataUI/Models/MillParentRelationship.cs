using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class MillParentRelationship
    {
        public int RelationshipId { get; set; }
        public int? FkMillId { get; set; }
        public int? FkParentCompanyId { get; set; }
        public string Relationship { get; set; }
        public int? PercentOwned { get; set; }
        public bool? Ncasimember { get; set; }

        public virtual MillInformation FkMill { get; set; }
        public virtual ParentCompany FkParentCompany { get; set; }
    }
}
