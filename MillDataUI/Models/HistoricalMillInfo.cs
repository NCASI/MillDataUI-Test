using System;
using System.Collections.Generic;

namespace MillDataUI.Models
{
    public partial class HistoricalMillInfo
    {
        public int InfoId { get; set; }
        public int? FkMillId { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string Company { get; set; }
        public int? ProdCategory1 { get; set; }
        public int? ProdCategory2 { get; set; }
        public string WhatChanged { get; set; }
        public string Comments { get; set; }

        public virtual MillInformation FkMill { get; set; }
        public virtual NcasiprodCat ProdCategory2Navigation { get; set; }
    }
}
