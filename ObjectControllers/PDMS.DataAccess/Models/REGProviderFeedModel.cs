using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class REGProviderFeedModel
    {
        public int? reg_provider_feed_id { get; set; }
        public int? reg_id { get; set; }
        public DateTime? Notes_Date { get; set; }
        public string InitiatedBy { get; set; }
        public string person_reviewed_by { get; set; }
        public string enrollment_type { get; set; }
        public string Final_Disposition { get; set; }
        public string HistoricTmNotes { get; set; }
        public Guid? InitiatedByUserId { get; set; }
        public Guid? person_reviewed_by_userid { get; set; }
        public int? processid { get; set; }
        public int? ProviderFeedProcessId { get; set; }
    }
}
