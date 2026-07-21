using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class CommitteeCredentialActivityModel
    {
        public int? COMMITTEE_MEMBER_ID { get; set; }
        public string ROLE { get; set; }
        public string MEMBER_NAME { get; set; }
        public string MEMBER_USERNAME { get; set; }
        public string MEMBER_RANK { get; set; }
        public string COMMITTEE_ACTIVITY_STATUS_NAME { get; set; }
        public int? COMMITTEE_CREDENTIAL_ACTIVITY_ID { get; set; }
        public int? CREDENTIALING_ID { get; set; }
        public int? COMMITTEE_ACTION_STATUS_ID { get; set; }
        public string COMMENTS { get; set; }
        public DateTime? ACTION_DATE { get; set; }
    }
}
