using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class COMMITTEEMEMBERModel
    {
        public int? COMMITTEE_MEMBER_ID { get; set; }
        public string ROLE { get; set; }
        public string MEMBER_RANK { get; set; }
        public string MEMBER_NAME { get; set; }
        public string MEMBER_USERNAME { get; set; }
        public DateTime? LAST_MODIFIED_DATE_TIME { get; set; }
        public Guid? LAST_MODIFIED_USER { get; set; }
    }
}
