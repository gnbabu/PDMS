using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class ProviderNotesModelResult
    {
        public List<ProviderNotesModelResultSet1> ResultSet1 { get; set; }
        public List<ProviderNotesModelResultSet2> ResultSet2 { get; set; }
    }


    public class ProviderNotesModelResultSet1
    {
        public int? reg_id { get; set; }
        public string provider_note_type { get; set; }
        public string workflow_event_type { get; set; }
        public string NOTE_TEXT { get; set; }
        public string UserName { get; set; }
        public DateTime? NOTE_DATE_TIME { get; set; }
        public string screen { get; set; }
    }


    public class ProviderNotesModelResultSet2
    {
    }

}
