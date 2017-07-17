using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.ExistingDb.Models
{
    public partial class MillParentRelationship
    {
        public int PkRelationshipId { get; set; }
        public int? FkMillKey { get; set; }
        public int? FkParentCompanyId { get; set; }
        public string Relationship { get; set; }
        public int? PercentOwned { get; set; }
        public bool? Ncasimember { get; set; }

        public virtual MillInformation FkMillKeyNavigation { get; set; }
        public virtual ParentCompany FkParentCompany { get; set; }
    }
}
