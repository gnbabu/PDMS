using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
     public class  StagingProviderEnrollmentByTransactionQueueIDModel
    {
        public int? MmisStagingGroupPK { get; set; }
        public int? TransactionTypeID { get; set; }
        public int? MmisStatusTypeID { get; set; }
        public string MedicaidID { get; set; }
        public string Name { get; set; }
        public string NPI { get; set; }
        public string TaxIDValue { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string ProviderType { get; set; }
        public string Specialty { get; set; }
        public string EnrollmentStatusCode { get; set; }
        public DateTime? TermDate { get; set; }
        public string ProviderCategory { get; set; }
        public string ProviderRiskLevel { get; set; }
        public int? TransactionQueueID { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
}
