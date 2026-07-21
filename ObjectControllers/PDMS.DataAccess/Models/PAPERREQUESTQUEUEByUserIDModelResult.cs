using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class PAPERREQUESTQUEUEByUserIDModelResult
    {
        public int TotalCount { get; set; }
        public List<PAPERREQUESTQUEUEByUserIDModelResultSet1> ResultSet1 { get; set; }
        public List<PAPERREQUESTQUEUEByUserIDModelResultSet2> ResultSet2 { get; set; }
    }


    public class PAPERREQUESTQUEUEByUserIDModelResultSet1
    {
        public int? PaperRequestQueueID { get; set; }
        public Guid? UserID { get; set; }
        public int? PaperRequestTypeID { get; set; }
        public int? PaperRequestStatusTypeID { get; set; }
        public string ProviderName { get; set; }
        public string PaperRequestTypeName { get; set; }
        public string TaxID { get; set; }
        public string NPI { get; set; }
        public string SpecialtyTypeName { get; set; }
        public string PracticeLocationZip { get; set; }
        public int? Aging { get; set; }
    }


    public class PAPERREQUESTQUEUEByUserIDModelResultSet2
    {
    }

}
