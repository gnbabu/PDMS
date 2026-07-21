using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class CALLTRACKINGCALLSBYRANGEModel
    {
        public int? CallID { get; set; }
        public int? SourceID { get; set; }
        public int? SubjectID { get; set; }
        public int? NextActionID { get; set; }
        public int? ResolutionID { get; set; }
        public string SourceName { get; set; }
        public string SubjectName { get; set; }
        public string NextActionName { get; set; }
        public string ResolutionName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Duration { get; set; }
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public int? RegID { get; set; }
        public int? MemberID { get; set; }
        public string JudicialDistrict { get; set; }
        public string CaseWorkerName { get; set; }
        public string CallerOther { get; set; }
        public string ReasonOther { get; set; }
        public string CallDetails { get; set; }
        public string NPI { get; set; }
        public string MedicaidID { get; set; }
    }
}
