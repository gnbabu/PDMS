using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class PAPERREQUESTQUEUEMatchDataModel
    {
        public int? PaperRequestQueueID { get; set; }
        public Guid? UserID { get; set; }
        public int? ApplicationTypeID { get; set; }
        public int? ProviderTypeID { get; set; }
        public int? ProviderCategoryTypeID { get; set; }
        public int? SpecialtyTypeID { get; set; }
        public string SpecialtyTypeName { get; set; }
        public int? TaxonomyTypeID { get; set; }
        public string TaxonomyCode { get; set; }
        public string ProviderName { get; set; }
        public string TaxID { get; set; }
        public string NPI { get; set; }
        public string MedicaidID { get; set; }
        public string ZipCode { get; set; }
        public string ZipExt { get; set; }
        public string PracticeLocationZip { get; set; }
        public string CurrentStatusType { get; set; }
        public int? RegID { get; set; }
        public int? DIDDReferralID { get; set; }
        public int? ReferralTypeID { get; set; }
        public DateTime? RevalidationDate { get; set; }
        public int? PendingConvertedProvider { get; set; }
    }
}
