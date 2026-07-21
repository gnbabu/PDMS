using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class REGCredentialingCOMMENTSModel
    {
        public int? REG_CREDENTIALING_COMMENTS_ID { get; set; }
        public int? REG_ID { get; set; }
        public int? CREDENTIALING_ID { get; set; }
        public string COMMENTS { get; set; }
        public DateTime? LAST_MODIFIED_DATE_TIME { get; set; }
        public string LAST_MODIFIED_USER { get; set; }
        public string USERNAME { get; set; }
        public string ROLENAME { get; set; }
    }
}
