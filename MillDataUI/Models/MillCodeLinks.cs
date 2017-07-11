using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class MillCodeLinks
    {
        public int MillCodeLinkId { get; set; }
        public int? Nims { get; set; }
        public int? Lwp { get; set; }
        public string Fisher { get; set; }
        public int? Fpac { get; set; }
    }
}
