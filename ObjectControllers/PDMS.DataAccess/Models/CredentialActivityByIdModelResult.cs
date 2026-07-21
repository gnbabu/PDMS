using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class CredentialActivityByIdModelResult
    {
        public List<CredentialActivityByIdModelResultSet1> ResultSet1 { get; set; }
        public List<CredentialActivityByIdModelResultSet2> ResultSet2 { get; set; }
    }


    public class CredentialActivityByIdModelResultSet1
    {
        public int? CREDENTIAL_ACTIVITY_ID { get; set; }
        public int? CREDENTIALING_ID { get; set; }
        public int? ACTIVITY_TYPE_ID { get; set; }
        public string NOTES { get; set; }
        public DateTime? ORIGINAL_EFFECTIVE_DATE { get; set; }
        public DateTime? RENEWAL_DATE { get; set; }
        public DateTime? EXPIRATION_DATE { get; set; }
        public string VERIFICATION_SOURCE_USED { get; set; }
        public DateTime? VERIFICATION_DATE { get; set; }
        public DateTime? LAST_ACTION_DATE { get; set; }
        public DateTime? ATTESTATION_DATE { get; set; }
        public bool? isBoardVerificationRequired { get; set; }
        public DateTime? MATERNITY_LICENSE_DATE { get; set; }
        public DateTime? SITE_VISIT_DATE { get; set; }
        public string SCREENING_ACTIVITY_TYPE_NAME { get; set; }
        public string EXTERNAL_CHECK_URL { get; set; }
        public string EXTERNAL_CHECK_URL_DESCRIPTION { get; set; }
        public int? ACTIVITY_DATARANK_ID { get; set; }
        public string display_NAME { get; set; }
        public string VERIFIED_BY { get; set; }
        public string EXTRA_EXTERNAL_CHECK_URL { get; set; }
        public string EXTRA_EXTERNAL_CHECK_URL_DESCRIPTION { get; set; }
    }


    public class CredentialActivityByIdModelResultSet2
    {
        public string ORGANIZATION_NAME { get; set; }
        public string NPI { get; set; }
        public string GENDER { get; set; }
        public int? TAX_ID { get; set; }
        public DateTime? BIRTH_DATE { get; set; }
        public string INDIVIDUAL_NAME { get; set; }
        public int? PECOS_RISK_LEVEL_ID { get; set; }
        public DateTime? PECOS_LAST_REVALIDATION_DATE { get; set; }
        public string PECOS_ENROLLED_STATE { get; set; }
        public string CITIZENSHIP_TYPE_NAME { get; set; }
        public string IMMIGRATION_STATUS_NAME { get; set; }
        public string ALIEN_NUMBER { get; set; }
        public int? PROVIDER_TYPE_ID { get; set; }
        public string PROVIDER_TYPE_NAME { get; set; }
        public string ENTITYTYPE { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public string MAILINGADDRESSSTATENAME { get; set; }
    }

}
