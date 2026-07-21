using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MAXIMUS.Controllers.PDMS.DataAccessUpgrade.DBHelpers;
using MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Repositories
{
    public class CredentialRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public CredentialRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<PROVIDERCredentialingModel> SelectProviderCredentialingData(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectPROVIDER_Credentialing", parameters, MapSelectPROVIDERCredentialingModel).ToList();
        }

        public CredentialingScreeningActivityModelResult SelectProviderCredentialActivityData(SqlParameter[] parameters)
        {
            return ExecuteSelectCredentialingScreeningActivityModel(parameters);
        }

        public CredentialActivityByIdModelResult SelectProviderCredentialActivityMatchData(SqlParameter[] parameters)
        {
            return ExecuteSelectCredentialActivityByIdModel(parameters);
        }

        public List<ScreeningActivityUrlModel> SelectCredentialActivityUrl(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectScreeningActivityUrl", parameters, MapSelectScreeningActivityUrlModel).ToList();
        }

        public List<COMMITTEEMEMBERModel> GetCredentialCommitteeMembers(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectCOMMITTEE_MEMBER", parameters, MapSelectCOMMITTEEMEMBERModel).ToList();
        }

        public List<InsertCommitteeCredentialActivityModel> InsertProviderCredentialingCommitteeMember(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_insertCommitteeCredentialActivity", parameters, MapInsertCommitteeCredentialActivityModel).ToList();
        }

        public UpdateCOMMITTEECREDENTIALACTIVITYModelResult UpdateCredentialingCommitteeMember(SqlParameter[] parameters)
        {
            return ExecuteUpdateCOMMITTEECREDENTIALACTIVITYModel(parameters);
        }

        public List<CommitteeCredentialActivityModel> SelectCredentialingCommitteeActivity(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectCommitteeCredentialActivity", parameters, MapSelectCommitteeCredentialActivityModel).ToList();
        }

        public List<COMMITTEEACTIVITYSTATUSModel> GetCommitteeActivityStatuses(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectCOMMITTEE_ACTIVITY_STATUS", parameters, MapSelectCOMMITTEEACTIVITYSTATUSModel).ToList();
        }

        public List<CredentialingResultModel> SelectCredentialingResult(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_Select_Credentialing_Result", parameters, MapSelectCredentialingResultModel).ToList();
        }

        public List<REGCredentialingCOMMENTSModel> SelectCredentialingComments(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectREG_Credentialing_COMMENTS", parameters, MapSelectREGCredentialingCOMMENTSModel).ToList();
        }

        public REGHEALTHCAREFACILITYAFFILIATIONModelResult IsHospitalBasedProvider(SqlParameter[] parameters)
        {
            return ExecuteSelectREGHEALTHCAREFACILITYAFFILIATIONModel(parameters);
        }

        private PROVIDERCredentialingModel MapSelectPROVIDERCredentialingModel(SqlDataReader reader)
        {
            return new PROVIDERCredentialingModel()
            {
                credentialing_id = reader.GetNullableInt("credentialing_id"),
                START_DATE_TIME = reader.GetNullableDateTime("START_DATE_TIME"),
                END_DATE_TIME = reader.GetNullableDateTime("END_DATE_TIME"),
                CREDENTIALING_STATUS_ID = reader.GetNullableInt("CREDENTIALING_STATUS_ID"),
                CREDENTIALING_RESULT_ID = reader.GetNullableInt("CREDENTIALING_RESULT_ID"),
                CREDENTIALING_STATUS_NAME = reader.GetNullableString("CREDENTIALING_STATUS_NAME") ?? string.Empty,
                CREDENTIALING_RESULT_NAME = reader.GetNullableString("CREDENTIALING_RESULT_NAME") ?? string.Empty,
                WORKFLOW_ID = reader.GetNullableInt("WORKFLOW_ID"),
                Name = reader.GetNullableString("Name") ?? string.Empty,
                RISK_LEVEL_ID = reader.GetNullableInt("RISK_LEVEL_ID"),
                RiskLevelName = reader.GetNullableString("RiskLevelName") ?? string.Empty
            };
        }


        private CredentialingScreeningActivityModelResultSet1 MapSelectCredentialingScreeningActivityModelResultSet1(SqlDataReader reader)
        {
            return new CredentialingScreeningActivityModelResultSet1()
            {
                CREDENTIAL_ACTIVITY_ID = reader.GetNullableInt("CREDENTIAL_ACTIVITY_ID"),
                CREDENTIALING_ID = reader.GetNullableInt("CREDENTIALING_ID"),
                ACTIVITY_TYPE_ID = reader.GetNullableInt("ACTIVITY_TYPE_ID"),
                NOTES = reader.GetNullableString("NOTES") ?? string.Empty,
                ORIGINAL_EFFECTIVE_DATE = reader.GetNullableDateTime("ORIGINAL_EFFECTIVE_DATE"),
                RENEWAL_DATE = reader.GetNullableDateTime("RENEWAL_DATE"),
                EXPIRATION_DATE = reader.GetNullableDateTime("EXPIRATION_DATE"),
                VERIFICATION_SOURCE_USED = reader.GetNullableString("VERIFICATION_SOURCE_USED") ?? string.Empty,
                VERIFICATION_SOURCE_DISPLAYNAME = reader.GetNullableString("VERIFICATION_SOURCE_DISPLAYNAME") ?? string.Empty,
                VERIFICATION_DATE = reader.GetNullableDateTime("VERIFICATION_DATE"),
                LAST_ACTION_DATE = reader.GetNullableDateTime("LAST_ACTION_DATE"),
                SCREENING_ACTIVITY_TYPE_NAME = reader.GetNullableString("SCREENING_ACTIVITY_TYPE_NAME") ?? string.Empty,
                EXTERNAL_CHECK_URL = reader.GetNullableString("EXTERNAL_CHECK_URL") ?? string.Empty,
                EXTERNAL_CHECK_URL_DESCRIPTION = reader.GetNullableString("EXTERNAL_CHECK_URL_DESCRIPTION") ?? string.Empty,
                DATARANK_TYPE_ID = reader.GetNullableInt("DATARANK_TYPE_ID"),
                DATARANKNAME = reader.GetNullableString("DATARANKNAME") ?? string.Empty,
                VERIFIED_BY = reader.GetNullableString("VERIFIED_BY") ?? string.Empty
            };
        }

        private CredentialingScreeningActivityModelResultSet2 MapSelectCredentialingScreeningActivityModelResultSet2(SqlDataReader reader)
        {
            return new CredentialingScreeningActivityModelResultSet2()
            {
                ORGANIZATION_NAME = reader.GetNullableString("ORGANIZATION_NAME") ?? string.Empty,
                NPI = reader.GetNullableString("NPI") ?? string.Empty,
                TAX_ID = reader.GetNullableInt("TAX_ID"),
                INDIVIDUAL_NAME = reader.GetNullableString("INDIVIDUAL_NAME") ?? string.Empty,
                PECOS_RISK_LEVEL_ID = reader.GetNullableInt("PECOS_RISK_LEVEL_ID"),
                PECOS_LAST_REVALIDATION_DATE = reader.GetNullableDateTime("PECOS_LAST_REVALIDATION_DATE"),
                PECOS_ENROLLED_STATE = reader.GetNullableString("PECOS_ENROLLED_STATE") ?? string.Empty,
                CITIZENSHIP_TYPE_NAME = reader.GetNullableString("CITIZENSHIP_TYPE_NAME") ?? string.Empty,
                IMMIGRATION_STATUS_NAME = reader.GetNullableString("IMMIGRATION_STATUS_NAME") ?? string.Empty,
                ALIEN_NUMBER = reader.GetNullableString("ALIEN_NUMBER") ?? string.Empty,
                PROVIDER_TYPE_ID = reader.GetNullableInt("PROVIDER_TYPE_ID"),
                ENTITYTYPE = reader.GetNullableString("ENTITYTYPE") ?? string.Empty,
                LASTNAME = reader.GetNullableString("LASTNAME") ?? string.Empty,
                FIRSTNAME = reader.GetNullableString("FIRSTNAME") ?? string.Empty,
                MIDDLENAME = reader.GetNullableString("MIDDLENAME") ?? string.Empty,
                MAILINGADDRESSSTATENAME = reader.GetNullableString("MAILINGADDRESSSTATENAME") ?? string.Empty
            };
        }

        private CredentialingScreeningActivityModelResultSet3 MapSelectCredentialingScreeningActivityModelResultSet3(SqlDataReader reader)
        {
            return new CredentialingScreeningActivityModelResultSet3()
            {
            };
        }

        private CredentialingScreeningActivityModelResult ExecuteSelectCredentialingScreeningActivityModel(SqlParameter[] parameters)
        {
            var result = new CredentialingScreeningActivityModelResult();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("usp_SelectCredentialingScreeningActivity", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.ResultSet1 = new List<CredentialingScreeningActivityModelResultSet1>();
                        while (reader.Read()) result.ResultSet1.Add(MapSelectCredentialingScreeningActivityModelResultSet1(reader));
                        reader.NextResult();
                        result.ResultSet2 = new List<CredentialingScreeningActivityModelResultSet2>();
                        while (reader.Read()) result.ResultSet2.Add(MapSelectCredentialingScreeningActivityModelResultSet2(reader));
                        reader.NextResult();
                        result.ResultSet3 = new List<CredentialingScreeningActivityModelResultSet3>();
                        while (reader.Read()) result.ResultSet3.Add(MapSelectCredentialingScreeningActivityModelResultSet3(reader));
                    }
                }
            }
            return result;
        }


        private CredentialActivityByIdModelResultSet1 MapSelectCredentialActivityByIdModelResultSet1(SqlDataReader reader)
        {
            return new CredentialActivityByIdModelResultSet1()
            {
                CREDENTIAL_ACTIVITY_ID = reader.GetNullableInt("CREDENTIAL_ACTIVITY_ID"),
                CREDENTIALING_ID = reader.GetNullableInt("CREDENTIALING_ID"),
                ACTIVITY_TYPE_ID = reader.GetNullableInt("ACTIVITY_TYPE_ID"),
                NOTES = reader.GetNullableString("NOTES") ?? string.Empty,
                ORIGINAL_EFFECTIVE_DATE = reader.GetNullableDateTime("ORIGINAL_EFFECTIVE_DATE"),
                RENEWAL_DATE = reader.GetNullableDateTime("RENEWAL_DATE"),
                EXPIRATION_DATE = reader.GetNullableDateTime("EXPIRATION_DATE"),
                VERIFICATION_SOURCE_USED = reader.GetNullableString("VERIFICATION_SOURCE_USED") ?? string.Empty,
                VERIFICATION_DATE = reader.GetNullableDateTime("VERIFICATION_DATE"),
                LAST_ACTION_DATE = reader.GetNullableDateTime("LAST_ACTION_DATE"),
                ATTESTATION_DATE = reader.GetNullableDateTime("ATTESTATION_DATE"),
                isBoardVerificationRequired = reader.GetNullableBool("isBoardVerificationRequired"),
                MATERNITY_LICENSE_DATE = reader.GetNullableDateTime("MATERNITY_LICENSE_DATE"),
                SITE_VISIT_DATE = reader.GetNullableDateTime("SITE_VISIT_DATE"),
                SCREENING_ACTIVITY_TYPE_NAME = reader.GetNullableString("SCREENING_ACTIVITY_TYPE_NAME") ?? string.Empty,
                EXTERNAL_CHECK_URL = reader.GetNullableString("EXTERNAL_CHECK_URL") ?? string.Empty,
                EXTERNAL_CHECK_URL_DESCRIPTION = reader.GetNullableString("EXTERNAL_CHECK_URL_DESCRIPTION") ?? string.Empty,
                ACTIVITY_DATARANK_ID = reader.GetNullableInt("ACTIVITY_DATARANK_ID"),
                display_NAME = reader.GetNullableString("display_NAME") ?? string.Empty,
                VERIFIED_BY = reader.GetNullableString("VERIFIED_BY") ?? string.Empty,
                EXTRA_EXTERNAL_CHECK_URL = reader.GetNullableString("EXTRA_EXTERNAL_CHECK_URL") ?? string.Empty,
                EXTRA_EXTERNAL_CHECK_URL_DESCRIPTION = reader.GetNullableString("EXTRA_EXTERNAL_CHECK_URL_DESCRIPTION") ?? string.Empty
            };
        }

        private CredentialActivityByIdModelResultSet2 MapSelectCredentialActivityByIdModelResultSet2(SqlDataReader reader)
        {
            return new CredentialActivityByIdModelResultSet2()
            {
                ORGANIZATION_NAME = reader.GetNullableString("ORGANIZATION_NAME") ?? string.Empty,
                NPI = reader.GetNullableString("NPI") ?? string.Empty,
                GENDER = reader.GetNullableString("GENDER") ?? string.Empty,
                TAX_ID = reader.GetNullableInt("TAX_ID"),
                BIRTH_DATE = reader.GetNullableDateTime("BIRTH_DATE"),
                INDIVIDUAL_NAME = reader.GetNullableString("INDIVIDUAL_NAME") ?? string.Empty,
                PECOS_RISK_LEVEL_ID = reader.GetNullableInt("PECOS_RISK_LEVEL_ID"),
                PECOS_LAST_REVALIDATION_DATE = reader.GetNullableDateTime("PECOS_LAST_REVALIDATION_DATE"),
                PECOS_ENROLLED_STATE = reader.GetNullableString("PECOS_ENROLLED_STATE") ?? string.Empty,
                CITIZENSHIP_TYPE_NAME = reader.GetNullableString("CITIZENSHIP_TYPE_NAME") ?? string.Empty,
                IMMIGRATION_STATUS_NAME = reader.GetNullableString("IMMIGRATION_STATUS_NAME") ?? string.Empty,
                ALIEN_NUMBER = reader.GetNullableString("ALIEN_NUMBER") ?? string.Empty,
                PROVIDER_TYPE_ID = reader.GetNullableInt("PROVIDER_TYPE_ID"),
                PROVIDER_TYPE_NAME = reader.GetNullableString("PROVIDER_TYPE_NAME") ?? string.Empty,
                ENTITYTYPE = reader.GetNullableString("ENTITYTYPE") ?? string.Empty,
                LASTNAME = reader.GetNullableString("LASTNAME") ?? string.Empty,
                FIRSTNAME = reader.GetNullableString("FIRSTNAME") ?? string.Empty,
                MIDDLENAME = reader.GetNullableString("MIDDLENAME") ?? string.Empty,
                MAILINGADDRESSSTATENAME = reader.GetNullableString("MAILINGADDRESSSTATENAME") ?? string.Empty
            };
        }

        private CredentialActivityByIdModelResult ExecuteSelectCredentialActivityByIdModel(SqlParameter[] parameters)
        {
            var result = new CredentialActivityByIdModelResult();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("usp_SelectCredentialActivityById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.ResultSet1 = new List<CredentialActivityByIdModelResultSet1>();
                        while (reader.Read()) result.ResultSet1.Add(MapSelectCredentialActivityByIdModelResultSet1(reader));
                        reader.NextResult();
                        result.ResultSet2 = new List<CredentialActivityByIdModelResultSet2>();
                        while (reader.Read()) result.ResultSet2.Add(MapSelectCredentialActivityByIdModelResultSet2(reader));
                    }
                }
            }
            return result;
        }


        private ScreeningActivityUrlModel MapSelectScreeningActivityUrlModel(SqlDataReader reader)
        {
            return new ScreeningActivityUrlModel()
            {
                EXTERNAL_CHECK_URL_DESCRIPTION = reader.GetNullableString("EXTERNAL_CHECK_URL_DESCRIPTION") ?? string.Empty,
                SCREENING_ACTIVITY_TYPE_ID = reader.GetNullableInt("SCREENING_ACTIVITY_TYPE_ID"),
                EXTERNAL_CHECK_URL = reader.GetNullableString("EXTERNAL_CHECK_URL") ?? string.Empty
            };
        }


        private COMMITTEEMEMBERModel MapSelectCOMMITTEEMEMBERModel(SqlDataReader reader)
        {
            return new COMMITTEEMEMBERModel()
            {
                COMMITTEE_MEMBER_ID = reader.GetNullableInt("COMMITTEE_MEMBER_ID"),
                ROLE = reader.GetNullableString("ROLE") ?? string.Empty,
                MEMBER_RANK = reader.GetNullableString("MEMBER_RANK") ?? string.Empty,
                MEMBER_NAME = reader.GetNullableString("MEMBER_NAME") ?? string.Empty,
                MEMBER_USERNAME = reader.GetNullableString("MEMBER_USERNAME") ?? string.Empty,
                LAST_MODIFIED_DATE_TIME = reader.GetNullableDateTime("LAST_MODIFIED_DATE_TIME"),
                LAST_MODIFIED_USER = reader.GetNullableGuid("LAST_MODIFIED_USER")
            };
        }


        private InsertCommitteeCredentialActivityModel MapInsertCommitteeCredentialActivityModel(SqlDataReader reader)
        {
            return new InsertCommitteeCredentialActivityModel()
            {
            };
        }


        private UpdateCOMMITTEECREDENTIALACTIVITYModelResultSet1 MapUpdateCOMMITTEECREDENTIALACTIVITYModelResultSet1(SqlDataReader reader)
        {
            return new UpdateCOMMITTEECREDENTIALACTIVITYModelResultSet1()
            {
                Expr = reader.GetNullableString("Expr") ?? string.Empty
            };
        }

        private UpdateCOMMITTEECREDENTIALACTIVITYModelResultSet2 MapUpdateCOMMITTEECREDENTIALACTIVITYModelResultSet2(SqlDataReader reader)
        {
            return new UpdateCOMMITTEECREDENTIALACTIVITYModelResultSet2()
            {
            };
        }

        private UpdateCOMMITTEECREDENTIALACTIVITYModelResult ExecuteUpdateCOMMITTEECREDENTIALACTIVITYModel(SqlParameter[] parameters)
        {
            var result = new UpdateCOMMITTEECREDENTIALACTIVITYModelResult();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("updateCOMMITTEE_CREDENTIAL_ACTIVITY", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.ResultSet1 = new List<UpdateCOMMITTEECREDENTIALACTIVITYModelResultSet1>();
                        while (reader.Read()) result.ResultSet1.Add(MapUpdateCOMMITTEECREDENTIALACTIVITYModelResultSet1(reader));
                        reader.NextResult();
                        result.ResultSet2 = new List<UpdateCOMMITTEECREDENTIALACTIVITYModelResultSet2>();
                        while (reader.Read()) result.ResultSet2.Add(MapUpdateCOMMITTEECREDENTIALACTIVITYModelResultSet2(reader));
                    }
                }
            }
            return result;
        }


        private CommitteeCredentialActivityModel MapSelectCommitteeCredentialActivityModel(SqlDataReader reader)
        {
            return new CommitteeCredentialActivityModel()
            {
                COMMITTEE_MEMBER_ID = reader.GetNullableInt("COMMITTEE_MEMBER_ID"),
                ROLE = reader.GetNullableString("ROLE") ?? string.Empty,
                MEMBER_NAME = reader.GetNullableString("MEMBER_NAME") ?? string.Empty,
                MEMBER_USERNAME = reader.GetNullableString("MEMBER_USERNAME") ?? string.Empty,
                MEMBER_RANK = reader.GetNullableString("MEMBER_RANK") ?? string.Empty,
                COMMITTEE_ACTIVITY_STATUS_NAME = reader.GetNullableString("COMMITTEE_ACTIVITY_STATUS_NAME") ?? string.Empty,
                COMMITTEE_CREDENTIAL_ACTIVITY_ID = reader.GetNullableInt("COMMITTEE_CREDENTIAL_ACTIVITY_ID"),
                CREDENTIALING_ID = reader.GetNullableInt("CREDENTIALING_ID"),
                COMMITTEE_ACTION_STATUS_ID = reader.GetNullableInt("COMMITTEE_ACTION_STATUS_ID"),
                COMMENTS = reader.GetNullableString("COMMENTS") ?? string.Empty,
                ACTION_DATE = reader.GetNullableDateTime("ACTION_DATE")
            };
        }


        private COMMITTEEACTIVITYSTATUSModel MapSelectCOMMITTEEACTIVITYSTATUSModel(SqlDataReader reader)
        {
            return new COMMITTEEACTIVITYSTATUSModel()
            {
                COMMITTEE_ACTIVITY_STATUS_ID = reader.GetNullableInt("COMMITTEE_ACTIVITY_STATUS_ID"),
                COMMITTEE_ACTIVITY_STATUS_NAME = reader.GetNullableString("COMMITTEE_ACTIVITY_STATUS_NAME") ?? string.Empty
            };
        }


        private CredentialingResultModel MapSelectCredentialingResultModel(SqlDataReader reader)
        {
            return new CredentialingResultModel()
            {
                CREDENTIALING_RESULT_ID = reader.GetNullableInt("CREDENTIALING_RESULT_ID"),
                CREDENTIALING_RESULT_NAME = reader.GetNullableString("CREDENTIALING_RESULT_NAME") ?? string.Empty
            };
        }


        private REGCredentialingCOMMENTSModel MapSelectREGCredentialingCOMMENTSModel(SqlDataReader reader)
        {
            return new REGCredentialingCOMMENTSModel()
            {
                REG_CREDENTIALING_COMMENTS_ID = reader.GetNullableInt("REG_CREDENTIALING_COMMENTS_ID"),
                REG_ID = reader.GetNullableInt("REG_ID"),
                CREDENTIALING_ID = reader.GetNullableInt("CREDENTIALING_ID"),
                COMMENTS = reader.GetNullableString("COMMENTS") ?? string.Empty,
                LAST_MODIFIED_DATE_TIME = reader.GetNullableDateTime("LAST_MODIFIED_DATE_TIME"),
                LAST_MODIFIED_USER = reader.GetNullableString("LAST_MODIFIED_USER") ?? string.Empty,
                USERNAME = reader.GetNullableString("USERNAME") ?? string.Empty,
                ROLENAME = reader.GetNullableString("ROLENAME") ?? string.Empty
            };
        }


        private REGHEALTHCAREFACILITYAFFILIATIONModelResultSet1 MapSelectREGHEALTHCAREFACILITYAFFILIATIONModelResultSet1(SqlDataReader reader)
        {
            return new REGHEALTHCAREFACILITYAFFILIATIONModelResultSet1()
            {
                FacilityName = reader.GetNullableString("FacilityName") ?? string.Empty,
                IsInpatientSetting = reader.GetNullableBool("IsInpatientSetting") ?? false
            };
        }

        private REGHEALTHCAREFACILITYAFFILIATIONModelResultSet2 MapSelectREGHEALTHCAREFACILITYAFFILIATIONModelResultSet2(SqlDataReader reader)
        {
            return new REGHEALTHCAREFACILITYAFFILIATIONModelResultSet2()
            {
                REG_HEALTH_CARE_FACILITY_AFFILIATION_ID = reader.GetNullableInt("REG_HEALTH_CARE_FACILITY_AFFILIATION_ID"),
                Is_Primary_Facility = reader.GetNullableBool("Is_Primary_Facility"),
                REG_ID = reader.GetNullableInt("REG_ID"),
                FacilityName = reader.GetNullableString("FacilityName") ?? string.Empty,
                StaffCategory = reader.GetNullableString("StaffCategory") ?? string.Empty,
                StatusOfPrivileges = reader.GetNullableString("StatusOfPrivileges") ?? string.Empty,
                StartDate = reader.GetNullableDateTime("StartDate"),
                EndDate = reader.GetNullableDateTime("EndDate"),
                IsRestrictedPrivilege = reader.GetNullableBool("IsRestrictedPrivilege"),
                Reason = reader.GetNullableString("Reason") ?? string.Empty,
                LAST_MODIFIED_DATE_TIME = reader.GetNullableDateTime("LAST_MODIFIED_DATE_TIME"),
                LAST_MODIFIED_USER = reader.GetNullableGuid("LAST_MODIFIED_USER"),
                Created_On_Date_Time = reader.GetNullableDateTime("Created_On_Date_Time"),
                Created_By_User = reader.GetNullableGuid("Created_By_User"),
                FacilityMedicaidID = reader.GetNullableString("FacilityMedicaidID") ?? string.Empty,
                IsInpatientSetting = reader.GetNullableBool("IsInpatientSetting"),
                IsHospitalPrivileges = reader.GetNullableBool("IsHospitalPrivileges"),
                HospitalPrivilegesReason = reader.GetNullableString("HospitalPrivilegesReason") ?? string.Empty,
                AHAHospitalID = reader.GetNullableString("AHAHospitalID") ?? string.Empty
            };
        }

        private REGHEALTHCAREFACILITYAFFILIATIONModelResult ExecuteSelectREGHEALTHCAREFACILITYAFFILIATIONModel(SqlParameter[] parameters)
        {
            var result = new REGHEALTHCAREFACILITYAFFILIATIONModelResult();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("usp_SelectREG_HEALTH_CARE_FACILITY_AFFILIATION", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.ResultSet1 = new List<REGHEALTHCAREFACILITYAFFILIATIONModelResultSet1>();
                        while (reader.Read()) result.ResultSet1.Add(MapSelectREGHEALTHCAREFACILITYAFFILIATIONModelResultSet1(reader));
                        reader.NextResult();
                        result.ResultSet2 = new List<REGHEALTHCAREFACILITYAFFILIATIONModelResultSet2>();
                        while (reader.Read()) result.ResultSet2.Add(MapSelectREGHEALTHCAREFACILITYAFFILIATIONModelResultSet2(reader));
                    }
                }
            }
            return result;
        }


    }
}
