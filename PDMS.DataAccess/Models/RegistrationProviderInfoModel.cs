using System;

namespace PDMS.DataAccess.Models
{
    public class RegistrationProviderInfoModel
    {
        // ================= BASIC =================
        public int REG_ID { get; set; }
        public string NAME { get; set; }
        public string DBA { get; set; }
        public string NPI { get; set; }
        public string TAX_ID { get; set; }

        public int? ENTITY_TYPE_ID { get; set; }
        public int PROVIDER_TYPE_ID { get; set; }

        // ================= CONTACT =================
        public string CONTACT_NAME { get; set; }
        public string CONTACT_TITLE { get; set; }
        public string CONTACT_ADDRESS1 { get; set; }
        public string CONTACT_ADDRESS2 { get; set; }
        public string CONTACT_CITY { get; set; }
        public string CONTACT_STATE { get; set; }
        public string CONTACT_ZIP { get; set; }
        public string CONTACT_EXT_ZIP { get; set; }
        public string CONTACT_PHONE_NUMBER { get; set; }
        public string CONTACT_PHONE_EXT { get; set; }
        public string CONTACT_FAX_NUMBER { get; set; }
        public string CONTACT_EMAIL_ADDRESS { get; set; }
        public string CONTACT_QUADRANT { get; set; }
        public string CONTACT_WARD { get; set; }
        public string CONTACT_COUNTY { get; set; }

        // ================= STATUS =================
        public DateTime? EFFECTIVE_DATE { get; set; }
        public int? ENROLLMENT_STATUS_CODE { get; set; }
        public int? ENROLLMENT_STATUS_REASON_ID { get; set; }
        public string ENROLLMENT_STATUS_CODE_DESCRIPTION { get; set; }
        public string ENROLLMENT_STATUS_REASON { get; set; }
        public string ENROLL_STATUS_DESC { get; set; }

        public DateTime? TERM_DATE { get; set; }
        public int? TERM_REASON_ID { get; set; }

        // ================= AUDIT =================
        public int? MODIFIED_STATUS_TYPE_ID { get; set; }
        public DateTime? LAST_MODIFIED_DATE_TIME { get; set; }
        public Guid? LAST_MODIFIED_USER { get; set; }

        public DateTime? CREATED_ON_DATE_TIME { get; set; }
        public Guid? CREATED_BY_USER { get; set; }

        // ================= PERSON =================
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string MIDDLE_INITIAL { get; set; }
        public string TITLE { get; set; }
        public string GENDER { get; set; }

        public DateTime? BIRTH_DATE { get; set; }
        public DateTime? DEATH_DATE { get; set; }
        public string BIRTH_COUNTRY { get; set; }
        public string BIRTH_STATE { get; set; }
        public string BIRTH_CITY { get; set; }
        public bool? IS_OHIO_RESIDENT { get; set; }

        // ================= PRACTICE / RISK =================
        public DateTime? END_DATE { get; set; }
        public int? TYPE_OF_PRACTICE_ID { get; set; }
        public int? PRACTICE_TYPE_ID { get; set; }
        public int? OWNERSHIP_TYPE_ID { get; set; }

        public int? PROVIDER_RISK_LEVEL_ID { get; set; }
        public string PROVIDER_RISK_LEVEL_NAME { get; set; }
        public int? PECOS_RISK_LEVEL_ID { get; set; }
        public DateTime? PECOS_LAST_REVALIDATION_DATE { get; set; }
        public string PECOS_ENROLLED_STATE { get; set; }
        public bool? PECOS_BACKGROUND_COMPLETE { get; set; }
        public DateTime? PECOS_BACKGROUND_DATE { get; set; }

        // ================= TAX / IDS =================
        public int? TAX_ID_TYPE_ID { get; set; }
        public string ALT_TAX_ID { get; set; }
        public int? ALT_TAX_ID_TYPE { get; set; }

        public string MEDICAID_ID { get; set; }
        public string TAXONOMY_CODE { get; set; }
        public string ODH_NUMBER { get; set; }

        // ================= PROFESSIONAL =================
        public string USMLE_NUMBER { get; set; }
        public DateTime? USMLE_ISSUEDATE { get; set; }
        public bool? ECFMG_CERTIFIED { get; set; }
        public string OFFICE_MANAGER { get; set; }

        // ================= PROGRAMS =================
        public bool? THSTEPS_ENROLLED { get; set; }
        public DateTime? THSTEPS_BEGINDATE { get; set; }
        public DateTime? THSTEPS_ENDDATE { get; set; }

        public bool? CSHN_ENROLLED { get; set; }
        public DateTime? CSHN_BEGINDATE { get; set; }
        public DateTime? CSHN_ENDDATE { get; set; }

        public bool? MTMED_ENROLLED { get; set; }
        public DateTime? MTMED_BEGINDATE { get; set; }
        public DateTime? MTMED_ENDDATE { get; set; }

        public bool? MTCHIP_ENROLLED { get; set; }
        public DateTime? MTCHIP_BEGINDATE { get; set; }
        public DateTime? MTCHIP_ENDDATE { get; set; }

        public bool? MTBOTH_ENROLLED { get; set; }

        // ================= FLAGS =================
        public bool CHANGED_APPLICATION_TYPE { get; set; }
        public bool? HAS_MALPRACTICE { get; set; }
        public bool? IS_PROVIDER_REACTIVATION { get; set; }
        public bool? REQUIRE_NPI { get; set; }

        // ================= APPLICATION =================
        public int? APPLICATION_TYPE_ID { get; set; }
        public int? Waiver_TYPE_ID { get; set; }

        // ================= WORKFLOW =================
        public DateTime? CHANGE_EFFECTIVE_DATE { get; set; }
        public DateTime? REQUESTED_EFFECTIVE_DATE { get; set; }
        public int? WORKFLOW_EVENT_TYPE_ID { get; set; }
        public DateTime? SUBMIT_DATE_TIME { get; set; }
        public bool? RETRO_EFFECTIVE_DATE { get; set; }

        // ================= EXTRA =================
        public int? BUMP_UP_REASON_ID { get; set; }
        public string BUMP_UP_REASON_DESC { get; set; }

        public int? REG_PROGRAM_STATUS_TYPE_ID { get; set; }
        public int? REGISTRATION_STATUS_TYPE_ID { get; set; }

        public int InProviderDataEntry { get; set; }
        public string CAQH { get; set; }
        public string IS_USED_IN_MMIS { get; set; }

        // ================= PROVIDER TYPE =================
        public string PROVIDER_TYPE_NAME { get; set; }
        public string PROVIDER_TYPE_ABBREVIATION { get; set; }
        public int? PROVIDER_CATEGORY_TYPE_ID { get; set; }
        public string PROVIDER_CATEGORY_TYPE_NAME { get; set; }
        public string MMIS_PROVIDER_TYPE_ID { get; set; }

        // ================= CPC / ODM =================
        public int? CPC_Payment_Type_ID { get; set; }
        public int? CPC_PRACTICE_TYPE_ID { get; set; }
        public bool? ODM_Credentialing_Delegates_IsChecked { get; set; }
        public bool? ODM_Credentialing_Delegates_Changed { get; set; }

        // ================= TIMELINES =================
        public DateTime? START_DATE { get; set; }
        public DateTime? CREDENTIALING_END_DATE { get; set; }
        public DateTime? PREVIOUS_END_DATE { get; set; }
        public DateTime? TERMINATION_EXEMPT_DATE { get; set; }
        public DateTime? SUSPENSION_EFFECTIVE_DATE { get; set; }
        public DateTime? REVALIDATION_DATE_PRIOR_TO_TERMINATION { get; set; }

        // ================= PDMS =================
        public string PDMS_REG_ID { get; set; }
        public string PDMS_NAME { get; set; }
        public string PDMS_DBA { get; set; }
        public string PDMS_NPI { get; set; }
        public string PDMS_TAX_ID { get; set; }
        public int? PDMS_ENTITY_TYPE_ID { get; set; }
        public int PDMS_PROVIDER_TYPE_ID { get; set; }

        public string PDMS_CONTACT_NAME { get; set; }
        public string PDMS_CONTACT_TITLE { get; set; }
        public string PDMS_CONTACT_ADDRESS1 { get; set; }
        public string PDMS_CONTACT_ADDRESS2 { get; set; }
        public string PDMS_CONTACT_CITY { get; set; }
        public string PDMS_CONTACT_STATE { get; set; }
        public string PDMS_CONTACT_ZIP { get; set; }
        public string PDMS_CONTACT_EXT_ZIP { get; set; }
        public string PDMS_CONTACT_PHONE_NUMBER { get; set; }
        public string PDMS_CONTACT_PHONE_EXT { get; set; }
        public string PDMS_CONTACT_FAX_NUMBER { get; set; }
        public string PDMS_CONTACT_EMAIL_ADDRESS { get; set; }

        public string PDMS_MODIFIED_STATUS_TYPE_ID { get; set; }
        public DateTime? PDMS_LAST_MODIFIED_DATE_TIME { get; set; }
        public Guid? PDMS_LAST_MODIFIED_USER { get; set; }
    }
}
