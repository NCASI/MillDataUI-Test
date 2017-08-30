using System;

namespace MillData.Models
{
    public partial class HistoricalMillInfo
    {
        public int PkInfoId { get; set; }
        public int? FkMillKey { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string Company { get; set; }
        public int? ProdCategory1 { get; set; }
        public int? ProdCategory2 { get; set; }
        public string WhatChanged { get; set; }
        public string Comments { get; set; }

        public virtual MillInformation FkMillKeyNavigation { get; set; }
        public virtual NcasiprodCat ProdCategory2Navigation { get; set; }
    }
}
