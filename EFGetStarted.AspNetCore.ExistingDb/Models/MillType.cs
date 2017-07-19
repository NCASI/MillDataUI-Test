using System;
using System.Collections.Generic;

namespace MillData.Models
{
    public partial class MillType
    {
        public MillType()
        {
            MillInformation = new HashSet<MillInformation>();
        }

        public int PkTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<MillInformation> MillInformation { get; set; }
    }
}
