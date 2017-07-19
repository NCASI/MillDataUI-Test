using System;
using System.Collections.Generic;

namespace MillData.Models
{
    public partial class ParentCompany
    {
        public ParentCompany()
        {
            MillParentRelationship = new HashSet<MillParentRelationship>();
        }

        public int PkParentCompanyKey { get; set; }
        public int? ParentCompanyId { get; set; }
        public int? CorpId { get; set; }
        public string ParentCompany1 { get; set; }
        public bool? Afpamember { get; set; }
        public string MergeSplitStatus { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<MillParentRelationship> MillParentRelationship { get; set; }
    }
}
