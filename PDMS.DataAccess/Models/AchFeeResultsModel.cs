using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{

    public class AchFeeResultsModel
    {
        public int? RegID { get; set; }
        public string ProviderName { get; set; }
        public string TaxID { get; set; }
        public string NPI { get; set; }
        public string MedicaidID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string EdisonNumber { get; set; }
        public string PaymentNumber { get; set; }
    }
}
