﻿using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.ExistingDb.Models
{
    public partial class FiberType
    {
        public int PkFiberTypeId { get; set; }
        public string FiberType1 { get; set; }
        public string FiberSource { get; set; }
        public string FiberGroup { get; set; }
    }
}
