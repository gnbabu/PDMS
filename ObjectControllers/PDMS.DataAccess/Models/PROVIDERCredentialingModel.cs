using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class PROVIDERCredentialingModel
    {
        public int? credentialing_id { get; set; }
        public DateTime? START_DATE_TIME { get; set; }
        public DateTime? END_DATE_TIME { get; set; }
        public int? CREDENTIALING_STATUS_ID { get; set; }
        public int? CREDENTIALING_RESULT_ID { get; set; }
        public string CREDENTIALING_STATUS_NAME { get; set; }
        public string CREDENTIALING_RESULT_NAME { get; set; }
        public int? WORKFLOW_ID { get; set; }
        public string Name { get; set; }
        public int? RISK_LEVEL_ID { get; set; }
        public string RiskLevelName { get; set; }
    }
}
