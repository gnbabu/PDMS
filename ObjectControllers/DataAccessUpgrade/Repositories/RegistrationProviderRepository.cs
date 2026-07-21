using MAXIMUS.Controllers.PDMS.DataAccessUpgrade.DBHelpers;
using MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Services
{
    public class RegistrationProviderRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public RegistrationProviderRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public RegistrationProviderInfoModel GetRegistrationProvider(int regId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (regId > -1)
            {
                parameters.Add(new SqlParameter("@REG_ID", SqlDbType.Int)
                {
                    Value = regId
                });
            }

            return _dbHelper.ExecuteSingle("usp_SelectREG_PROVIDER", parameters.ToArray(),
                reader => MapRegistrationProvider(reader)
            );
        }


        private RegistrationProviderInfoModel MapRegistrationProvider(SqlDataReader reader)
        {
            return new RegistrationProviderInfoModel
            {
                // ================= BASIC =================
                REG_ID = reader.GetNullableInt("REG_ID") ?? 0,
                NAME = reader.GetNullableString("NAME"),
                DBA = reader.GetNullableString("DBA"),
                NPI = reader.GetNullableString("NPI"),
                TAX_ID = reader.GetNullableString("TAX_ID"),
                ENTITY_TYPE_ID = reader.GetNullableInt("ENTITY_TYPE_ID"),
                PROVIDER_TYPE_ID = reader.GetNullableInt("PROVIDER_TYPE_ID") ?? 0,

                // ================= CONTACT =================
                CONTACT_NAME = reader.GetNullableString("CONTACT_NAME"),
                CONTACT_TITLE = reader.GetNullableString("CONTACT_TITLE"),
                CONTACT_ADDRESS1 = reader.GetNullableString("CONTACT_ADDRESS1"),
                CONTACT_ADDRESS2 = reader.GetNullableString("CONTACT_ADDRESS2"),
                CONTACT_CITY = reader.GetNullableString("CONTACT_CITY"),
                CONTACT_STATE = reader.GetNullableString("CONTACT_STATE"),
                CONTACT_ZIP = reader.GetNullableString("CONTACT_ZIP"),
                CONTACT_EXT_ZIP = reader.GetNullableString("CONTACT_EXT_ZIP"),
                CONTACT_PHONE_NUMBER = reader.GetNullableString("CONTACT_PHONE_NUMBER"),
                CONTACT_PHONE_EXT = reader.GetNullableString("CONTACT_PHONE_EXT"),
                CONTACT_FAX_NUMBER = reader.GetNullableString("CONTACT_FAX_NUMBER"),
                CONTACT_EMAIL_ADDRESS = reader.GetNullableString("CONTACT_EMAIL_ADDRESS"),
                CONTACT_QUADRANT = reader.GetNullableString("CONTACT_QUADRANT"),
                CONTACT_WARD = reader.GetNullableString("CONTACT_WARD"),
                CONTACT_COUNTY = reader.GetNullableString("CONTACT_COUNTY"),

                // ================= STATUS =================
                EFFECTIVE_DATE = reader.GetNullableDateTime("EFFECTIVE_DATE"),
                TERM_DATE = reader.GetNullableDateTime("TERM_DATE"),
                ENROLLMENT_STATUS_CODE = reader.GetNullableInt("ENROLLMENT_STATUS_CODE"),
                ENROLLMENT_STATUS_REASON_ID = reader.GetNullableInt("ENROLLMENT_STATUS_REASON_ID"),
                ENROLLMENT_STATUS_CODE_DESCRIPTION = reader.GetNullableString("ENROLLMENT_STATUS_CODE_DESCRIPTION"),
                ENROLLMENT_STATUS_REASON = reader.GetNullableString("ENROLLMENT_STATUS_REASON"),
                ENROLL_STATUS_DESC = reader.GetNullableString("ENROLL_STATUS_DESC"),

                // ================= AUDIT =================
                MODIFIED_STATUS_TYPE_ID = reader.GetNullableInt("MODIFIED_STATUS_TYPE_ID"),
                LAST_MODIFIED_DATE_TIME = reader.GetNullableDateTime("LAST_MODIFIED_DATE_TIME"),
                LAST_MODIFIED_USER = reader.GetNullableGuid("LAST_MODIFIED_USER"),
                CREATED_ON_DATE_TIME = reader.GetNullableDateTime("CREATED_ON_DATE_TIME"),
                CREATED_BY_USER = reader.GetNullableGuid("CREATED_BY_USER"),

                // ================= PERSON =================
                FIRST_NAME = reader.GetNullableString("FIRST_NAME"),
                LAST_NAME = reader.GetNullableString("LAST_NAME"),
                MIDDLE_INITIAL = reader.GetNullableString("MIDDLE_INITIAL"),
                TITLE = reader.GetNullableString("TITLE"),
                GENDER = reader.GetNullableString("GENDER"),
                BIRTH_DATE = reader.GetNullableDateTime("BIRTH_DATE"),
                DEATH_DATE = reader.GetNullableDateTime("DEATH_DATE"),
                BIRTH_COUNTRY = reader.GetNullableString("BIRTH_COUNTRY"),
                BIRTH_STATE = reader.GetNullableString("BIRTH_STATE"),
                BIRTH_CITY = reader.GetNullableString("BIRTH_CITY"),
                IS_OHIO_RESIDENT = reader.GetNullableBool("IS_OHIO_RESIDENT"),

                // ================= PRACTICE =================
                END_DATE = reader.GetNullableDateTime("END_DATE"),
                TYPE_OF_PRACTICE_ID = reader.GetNullableInt("TYPE_OF_PRACTICE_ID"),
                PRACTICE_TYPE_ID = reader.GetNullableInt("PRACTICE_TYPE_ID"),
                OWNERSHIP_TYPE_ID = reader.GetNullableInt("OWNERSHIP_TYPE_ID"),

                // ================= RISK =================
                PROVIDER_RISK_LEVEL_ID = reader.GetNullableInt("PROVIDER_RISK_LEVEL_ID"),
                PROVIDER_RISK_LEVEL_NAME = reader.GetNullableString("PROVIDER_RISK_LEVEL_NAME"),
                PECOS_RISK_LEVEL_ID = reader.GetNullableInt("PECOS_RISK_LEVEL_ID"),
                PECOS_LAST_REVALIDATION_DATE = reader.GetNullableDateTime("PECOS_LAST_REVALIDATION_DATE"),
                PECOS_ENROLLED_STATE = reader.GetNullableString("PECOS_ENROLLED_STATE"),
                PECOS_BACKGROUND_COMPLETE = reader.GetNullableBool("PECOS_BACKGROUND_COMPLETE"),
                PECOS_BACKGROUND_DATE = reader.GetNullableDateTime("PECOS_BACKGROUND_DATE"),

                // ================= TAX =================
                TAX_ID_TYPE_ID = reader.GetNullableInt("TAX_ID_TYPE_ID"),
                ALT_TAX_ID = reader.GetNullableString("ALT_TAX_ID"),
                ALT_TAX_ID_TYPE = reader.GetNullableInt("ALT_TAX_ID_TYPE"),

                MEDICAID_ID = reader.GetNullableString("MEDICAID_ID"),
                TAXONOMY_CODE = reader.GetNullableString("TAXONOMY_CODE"),
                ODH_NUMBER = reader.GetNullableString("ODH_NUMBER"),

                // ================= PROFESSIONAL =================
                USMLE_NUMBER = reader.GetNullableString("USMLE_NUMBER"),
                USMLE_ISSUEDATE = reader.GetNullableDateTime("USMLE_ISSUEDATE"),
                ECFMG_CERTIFIED = reader.GetNullableBool("ECFMG_CERTIFIED"),
                OFFICE_MANAGER = reader.GetNullableString("OFFICE_MANAGER"),

                // ================= PROGRAMS =================
                THSTEPS_ENROLLED = reader.GetNullableBool("THSTEPS_ENROLLED"),
                THSTEPS_BEGINDATE = reader.GetNullableDateTime("THSTEPS_BEGINDATE"),
                THSTEPS_ENDDATE = reader.GetNullableDateTime("THSTEPS_ENDDATE"),

                CSHN_ENROLLED = reader.GetNullableBool("CSHN_ENROLLED"),
                CSHN_BEGINDATE = reader.GetNullableDateTime("CSHN_BEGINDATE"),
                CSHN_ENDDATE = reader.GetNullableDateTime("CSHN_ENDDATE"),

                MTMED_ENROLLED = reader.GetNullableBool("MTMED_ENROLLED"),
                MTMED_BEGINDATE = reader.GetNullableDateTime("MTMED_BEGINDATE"),
                MTMED_ENDDATE = reader.GetNullableDateTime("MTMED_ENDDATE"),

                MTCHIP_ENROLLED = reader.GetNullableBool("MTCHIP_ENROLLED"),
                MTCHIP_BEGINDATE = reader.GetNullableDateTime("MTCHIP_BEGINDATE"),
                MTCHIP_ENDDATE = reader.GetNullableDateTime("MTCHIP_ENDDATE"),

                MTBOTH_ENROLLED = reader.GetNullableBool("MTBOTH_ENROLLED"),

                // ================= FLAGS =================
                CHANGED_APPLICATION_TYPE = reader.GetNullableBool("CHANGED_APPLICATION_TYPE") ?? false,
                HAS_MALPRACTICE = reader.GetNullableBool("HAS_MALPRACTICE"),
                IS_PROVIDER_REACTIVATION = reader.GetNullableBool("IS_PROVIDER_REACTIVATION"),
                REQUIRE_NPI = reader.GetNullableBool("REQUIRE_NPI"),

                // ================= APPLICATION =================
                APPLICATION_TYPE_ID = reader.GetNullableInt("APPLICATION_TYPE_ID"),
                Waiver_TYPE_ID = reader.GetNullableInt("Waiver_TYPE_ID"),

                // ================= WORKFLOW =================
                CHANGE_EFFECTIVE_DATE = reader.GetNullableDateTime("CHANGE_EFFECTIVE_DATE"),
                REQUESTED_EFFECTIVE_DATE = reader.GetNullableDateTime("REQUESTED_EFFECTIVE_DATE"),
                WORKFLOW_EVENT_TYPE_ID = reader.GetNullableInt("WORKFLOW_EVENT_TYPE_ID"),
                SUBMIT_DATE_TIME = reader.GetNullableDateTime("SUBMIT_DATE_TIME"),
                RETRO_EFFECTIVE_DATE = reader.GetNullableBool("RETRO_EFFECTIVE_DATE"),

                // ================= EXTRA =================
                BUMP_UP_REASON_ID = reader.GetNullableInt("BUMP_UP_REASON_ID"),
                BUMP_UP_REASON_DESC = reader.GetNullableString("BUMP_UP_REASON_DESC"),
                REG_PROGRAM_STATUS_TYPE_ID = reader.GetNullableInt("REG_PROGRAM_STATUS_TYPE_ID"),
                REGISTRATION_STATUS_TYPE_ID = reader.GetNullableInt("REGISTRATION_STATUS_TYPE_ID"),
                InProviderDataEntry = reader.GetNullableInt("InProviderDataEntry") ?? 0,
                CAQH = reader.GetNullableString("CAQH"),
                IS_USED_IN_MMIS = reader.GetNullableString("IS_USED_IN_MMIS"),

                // ================= PROVIDER TYPE =================
                PROVIDER_TYPE_NAME = reader.GetNullableString("PROVIDER_TYPE_NAME"),
                PROVIDER_TYPE_ABBREVIATION = reader.GetNullableString("PROVIDER_TYPE_ABBREVIATION"),
                PROVIDER_CATEGORY_TYPE_ID = reader.GetNullableInt("PROVIDER_CATEGORY_TYPE_ID"),
                PROVIDER_CATEGORY_TYPE_NAME = reader.GetNullableString("PROVIDER_CATEGORY_TYPE_NAME"),
                MMIS_PROVIDER_TYPE_ID = reader.GetNullableString("MMIS_PROVIDER_TYPE_ID"),

                // ================= CPC / ODM =================
                CPC_Payment_Type_ID = reader.GetNullableInt("CPC_Payment_Type_ID"),
                CPC_PRACTICE_TYPE_ID = reader.GetNullableInt("CPC_PRACTICE_TYPE_ID"),
                ODM_Credentialing_Delegates_IsChecked = reader.GetNullableBool("ODM_Credentialing_Delegates_IsChecked"),
                ODM_Credentialing_Delegates_Changed = reader.GetNullableBool("ODM_Credentialing_Delegates_Changed"),

                // ================= TIMELINES =================
                START_DATE = reader.GetNullableDateTime("START_DATE"),
                CREDENTIALING_END_DATE = reader.GetNullableDateTime("CREDENTIALING_END_DATE"),
                PREVIOUS_END_DATE = reader.GetNullableDateTime("PREVIOUS_END_DATE"),
                TERMINATION_EXEMPT_DATE = reader.GetNullableDateTime("TERMINATION_EXEMPT_DATE"),
                SUSPENSION_EFFECTIVE_DATE = reader.GetNullableDateTime("SUSPENSION_EFFECTIVE_DATE"),
                REVALIDATION_DATE_PRIOR_TO_TERMINATION = reader.GetNullableDateTime("REVALIDATION_DATE_PRIOR_TO_TERMINATION"),

                // ================= PDMS =================
                PDMS_REG_ID = reader.GetNullableString("PDMS_REG_ID"),
                PDMS_NAME = reader.GetNullableString("PDMS_NAME"),
                PDMS_DBA = reader.GetNullableString("PDMS_DBA"),
                PDMS_NPI = reader.GetNullableString("PDMS_NPI"),
                PDMS_TAX_ID = reader.GetNullableString("PDMS_TAX_ID"),
                PDMS_ENTITY_TYPE_ID = reader.GetNullableInt("PDMS_ENTITY_TYPE_ID"),
                PDMS_PROVIDER_TYPE_ID = reader.GetNullableInt("PDMS_PROVIDER_TYPE_ID") ?? 0,

                PDMS_CONTACT_NAME = reader.GetNullableString("PDMS_CONTACT_NAME"),
                PDMS_CONTACT_TITLE = reader.GetNullableString("PDMS_CONTACT_TITLE"),
                PDMS_CONTACT_ADDRESS1 = reader.GetNullableString("PDMS_CONTACT_ADDRESS1"),
                PDMS_CONTACT_ADDRESS2 = reader.GetNullableString("PDMS_CONTACT_ADDRESS2"),
                PDMS_CONTACT_CITY = reader.GetNullableString("PDMS_CONTACT_CITY"),
                PDMS_CONTACT_STATE = reader.GetNullableString("PDMS_CONTACT_STATE"),
                PDMS_CONTACT_ZIP = reader.GetNullableString("PDMS_CONTACT_ZIP"),
                PDMS_CONTACT_EXT_ZIP = reader.GetNullableString("PDMS_CONTACT_EXT_ZIP"),
                PDMS_CONTACT_PHONE_NUMBER = reader.GetNullableString("PDMS_CONTACT_PHONE_NUMBER"),
                PDMS_CONTACT_PHONE_EXT = reader.GetNullableString("PDMS_CONTACT_PHONE_EXT"),
                PDMS_CONTACT_FAX_NUMBER = reader.GetNullableString("PDMS_CONTACT_FAX_NUMBER"),
                PDMS_CONTACT_EMAIL_ADDRESS = reader.GetNullableString("PDMS_CONTACT_EMAIL_ADDRESS"),

                PDMS_MODIFIED_STATUS_TYPE_ID = reader.GetNullableString("PDMS_MODIFIED_STATUS_TYPE_ID"),
                PDMS_LAST_MODIFIED_DATE_TIME = reader.GetNullableDateTime("PDMS_LAST_MODIFIED_DATE_TIME"),
                PDMS_LAST_MODIFIED_USER = reader.GetNullableGuid("PDMS_LAST_MODIFIED_USER")
            };
        }
    }
}