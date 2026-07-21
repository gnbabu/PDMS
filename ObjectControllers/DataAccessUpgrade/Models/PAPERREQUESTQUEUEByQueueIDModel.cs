using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class PAPERREQUESTQUEUEByQueueIDModel
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
}
