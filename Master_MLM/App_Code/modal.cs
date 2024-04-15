using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_MLM.App_Code
{
    public class modal
    {
        
    }

    public class SponsorDetails
    {
        public string SponsorCode { get; set; }
        public string Position { get; set; }
    }

    public class StatusCode
    {
        public string MFAStatus { get; set; }               // 0, 1, 2.
        public bool IsMFA { get; set; }
    }
}