using System;
using System.Collections.Generic;

namespace MillData.Models
{
    public partial class MillContactInfo
    {
        public int PkMillContactId { get; set; }
        public int? FkMillKey { get; set; }
        public short? ContactOrder { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string Mi { get; set; }
        public string LastName { get; set; }
        public string AreaCode { get; set; }
        public string Phone { get; set; }
        public string Ext { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string AddressPrefix { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string AddressSuffix { get; set; }
        public bool? ToMail { get; set; }
        public bool? EmailOnly { get; set; }
        public bool? EmailWrong { get; set; }
        public bool? Speaker { get; set; }
        public bool? Cc { get; set; }
        public bool? Bog { get; set; }
        public bool? Oc { get; set; }
        public bool? Rc { get; set; }
        public bool? Other { get; set; }
        public string ExpirationDate { get; set; }
        public string Assistant { get; set; }
        public string AssistantContactInfo { get; set; }
        public string Comments { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual MillInformation FkMillKeyNavigation { get; set; }
    }
}
