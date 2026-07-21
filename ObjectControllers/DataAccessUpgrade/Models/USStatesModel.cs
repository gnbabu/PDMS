using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class USStatesModel
    {
        public string STATE_ABBREV { get; set; }
        public string STATE_NAME { get; set; }
        public DateTime? LAST_MODIFIED_DATE_TIME { get; set; }
        public string LAST_MODIFIED_USER { get; set; }
        public string US_STATE { get; set; }
        public string FIPS_CODE { get; set; }
        public string REQUIRE_CDS { get; set; }
    }
}
