using MAXIMUS.Core.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using CON = MAXIMUS.Core.Libraries.Constants;

namespace MAXIMUS.Controllers.PDMS
{
    public static class CredentialController
    {

        public static DataSet SelectProviderCredentialingData(int regID)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                // Only add the RegistrationId if it is greater than -1
                if (regID > -1) parameters.Add(SqlParms.CreateParameter("REG_ID", DbType.Int32, regID, true));
                DataSet ds = new DataSet();
                string storedProc = "usp_SelectPROVIDER_Credentialing";
                ds = DataAccess.ExecuteStoredProcedure(storedProc, parameters, "CredentialingData");
                ds.Tables[0].TableName = "CredentialingData";
                return ds;
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }
        public static DataSet SelectProviderCredentialActivityData(int reg_id, int credentialingID)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("REG_ID", DbType.Int32, reg_id, true));
                parameters.Add(SqlParms.CreateParameter("CREDENTIALING_ID", DbType.Int32, credentialingID, true));
                DataSet ds = new DataSet();
                string storedProc = "usp_SelectCredentialingScreeningActivity";
                ds = DataAccess.ExecuteStoredProcedure(storedProc, parameters, "ActivityData");
                ds.Tables[0].TableName = "ActivityData";
                return ds;
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }
        public static DataSet SelectProviderCredentialActivityMatchData(int credentialActivityID, int regID)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                // Only add the RegistrationId if it is greater than -1
                if (credentialActivityID > -1) parameters.Add(SqlParms.CreateParameter("CREDENTIAL_ACTIVITY_ID", DbType.Int32, credentialActivityID, true));
                if (regID > -1) parameters.Add(SqlParms.CreateParameter("REG_ID", DbType.Int32, regID, true));
               
                DataSet ds = new DataSet();
                string storedProc = "usp_SelectCredentialActivityById";
                ds = DataAccess.ExecuteStoredProcedure(storedProc, parameters, "CredentialActivityMatchData");
            
                return ds;
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }

        public static DataSet SelectCredentialActivityUrl(int activityTypeId, int IsIndividual)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                // Only add the RegistrationId if it is greater than -1
                if (activityTypeId > -1) parameters.Add(SqlParms.CreateParameter("SCREENING_ACTIVITY_TYPE_ID", DbType.Int32, activityTypeId, true));
                parameters.Add(SqlParms.CreateParameter("IS_INDIVIDUAL", DbType.Int32, IsIndividual, true));
                DataSet ds = new DataSet();
                string storedProc = "usp_SelectScreeningActivityUrl";
                ds = DataAccess.ExecuteStoredProcedure(storedProc, parameters, "CredentialActivityUrl");

                return ds;
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }
        public static void UpdateCredentialActivity(int credentialActivityID, int reg_id, int activityTypeId, int dataRankId, string notes, DateTime? OrigEffDate, DateTime? renewalDate, 
            DateTime? expiraationDate, int veriSourId, DateTime? verificationDate, DateTime? lastActionDate,  string verifiedBy, DateTime? attestationdate, bool isBoardVerificationRequired, 
            DateTime? maternityLicDate, DateTime? siteAccredDate, bool isMediaCareOutput)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("CREDENTIAL_ACTIVITY_ID", DbType.Int32, credentialActivityID, true));
                parameters.Add(SqlParms.CreateParameter("REG_ID", DbType.Int32, reg_id, true));
                parameters.Add(SqlParms.CreateParameter("ACTIVITY_TYPE_ID", DbType.Int32, activityTypeId, true));
                parameters.Add(SqlParms.CreateParameter("DATA_RANK_ID", DbType.Int32, dataRankId, true));
                parameters.Add(SqlParms.CreateParameter("NOTES", DbType.String, notes, true));
                parameters.Add(SqlParms.CreateParameter("ORIGINAL_EFFECTIVE_DATE", DbType.DateTime, OrigEffDate, true));
                parameters.Add(SqlParms.CreateParameter("RENEWAL_DATE", DbType.DateTime, renewalDate, true));
                parameters.Add(SqlParms.CreateParameter("EXPIRATION_DATE", DbType.DateTime, expiraationDate, true));
                parameters.Add(SqlParms.CreateParameter("VERIFICATION_SOURCE_USED", DbType.Int32, veriSourId, true));
                parameters.Add(SqlParms.CreateParameter("VERIFICATION_DATE", DbType.DateTime, verificationDate, true));
                parameters.Add(SqlParms.CreateParameter("LAST_ACTION_DATE", DbType.DateTime, lastActionDate, true));
                parameters.Add(SqlParms.CreateParameter("VERIFIED_BY", DbType.Guid, verifiedBy, true));
                parameters.Add(SqlParms.CreateParameter("ATTESTATION_DATE", DbType.Guid, attestationdate, true));
                parameters.Add(SqlParms.CreateParameter("isBoardVerificationRequired", DbType.Boolean, isBoardVerificationRequired, true));
                parameters.Add(SqlParms.CreateParameter("MATERNITY_LICENSE_DATE", DbType.DateTime, maternityLicDate, true));
                parameters.Add(SqlParms.CreateParameter("SITE_VISIT_DATE", DbType.DateTime, siteAccredDate, true));
                parameters.Add(SqlParms.CreateParameter("ISMEDICARE_OPTOUT", DbType.Boolean, isMediaCareOutput, true));
                DataAccess.ExecuteStoredProcedure("usp_UpdateCREDENTIALING_SCREENING_ACTIVITY", parameters);
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }
        //get credential committee members
        public static DataSet GetCredentialCommitteeMembers()
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                DataSet dsMembers = new DataSet();
               dsMembers= DataAccess.ExecuteStoredProcedure("usp_SelectCOMMITTEE_MEMBER", parameters,"Members");
               return dsMembers;
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }
        public static bool InsertProviderCredentialingCommitteeMember(int credentialingId, int memberId,string memberUserName, DateTime? changedDate, string userID)
        {
            bool rtnVal = false;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("CREDENTIALING_ID", DbType.Int32, credentialingId, true));
                parameters.Add(SqlParms.CreateParameter("COMMITTEE_MEMBER_ID", DbType.Int32, memberId, true));
                parameters.Add(SqlParms.CreateParameter("COMMITTEE_MEMBER_USERNAME", DbType.String, memberUserName, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_DATE_TIME", DbType.DateTime, changedDate, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_USER", DbType.Guid, userID, true));
                DataAccess.ExecuteStoredProcedure("usp_insertCommitteeCredentialActivity", parameters);
                rtnVal = true;
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
            return rtnVal;
        }

        public static bool UpdateCredentialingCommitteeMember(int credentialingId, int actionStatusId, string memberUserName, string comments,DateTime actionDate, DateTime? changedDate, string userID)
        {
            bool rtnVal = false;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("CREDENTIALING_ID", DbType.Int32, credentialingId, true));
                parameters.Add(SqlParms.CreateParameter("action_status_id", DbType.Int32, actionStatusId, true));
                parameters.Add(SqlParms.CreateParameter("MEMBER_USERNAME", DbType.String, memberUserName, true));
                parameters.Add(SqlParms.CreateParameter("comments", DbType.String, comments, true));
                parameters.Add(SqlParms.CreateParameter("action_date", DbType.DateTime, actionDate, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_DATE_TIME", DbType.DateTime, changedDate, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_USER", DbType.Guid, userID, true));
                DataAccess.ExecuteStoredProcedure("updateCOMMITTEE_CREDENTIAL_ACTIVITY", parameters);
                rtnVal = true;
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
            return rtnVal;
        }

        public static DataSet SelectCredentialingCommitteeActivity(int Reg_id)
        {
            DataSet dsCommitee = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("Reg_ID", DbType.Int32, Reg_id, true));
                dsCommitee= DataAccess.ExecuteStoredProcedure("usp_SelectCommitteeCredentialActivity", parameters,"memberActivity");                
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
            return dsCommitee;
        }
        public static DataSet GetCommitteeActivityStatuses()
        {
            try
            {
               
                DataSet ds = new DataSet();
                List<SqlParameter> parameters = new List<SqlParameter>();
                string storedProc = "usp_SelectCOMMITTEE_ACTIVITY_STATUS";
                ds = DataAccess.ExecuteStoredProcedure(storedProc, parameters, "CredentialingStatus");
                ds.Tables[0].TableName = "CredentialingStatus";
                return ds;
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }
        public static string GetReviewStatusByCommiteeMember(int regId, string username)
        {
            string retval = "1";

            string logMsg = String.Format(Constants.LogString.MethodSignature, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name);
            Logging log = new Logging(new Guid(), logMsg); 
            
            try
            {
                DataSet ds = SelectCredentialingCommitteeActivity(regId);
                if (ObjectControllerHelper.HasRows(ds))
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.RowFilter = "MEMBER_USERNAME ='" + username+"'";
                    DataTable dtuser = dv.ToTable();
                    retval = dtuser.Rows[0]["COMMITTEE_ACTION_STATUS_ID"].ToString();
                }

            }
            catch (Exception ex)
            {
                log.CreateLogEntry("Failed to Review Status By Commitee Member"
                                                 + " Exception Message " + ex.Message + " Exception Stack = "
                                                 + ex.StackTrace, Logging.LogPriority.Error);
            }

            return retval;
        }
        public static void UpdateCredentialStatus(int regID, int statusID, DateTime? changedDate, string changedBy)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("REG_ID", DbType.Int32, regID, true));
                parameters.Add(SqlParms.CreateParameter("STATUS_ID", DbType.Int32, statusID, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_DATE_TIME", DbType.DateTime, changedDate, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_USER", DbType.Guid, changedBy, true));
                DataAccess.ExecuteStoredProcedure("usp_UpdateCREDENTIALING_STATUS", parameters);
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }

        public static void UpdateCredentialDiscontinueDate(int regID, DateTime? changedDate, string changedBy)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("REG_ID", DbType.Int32, regID, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_DATE_TIME", DbType.DateTime, changedDate, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_USER", DbType.Guid, changedBy, true));
                DataAccess.ExecuteStoredProcedure("usp_UpdateCredentialingDisContinue_Date", parameters);
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }


        public static void UpdateEnrollmentStatusReasonID(int regID, int reasonCodeID, DateTime? changedDate, string changedBy)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("REG_ID", DbType.Int32, regID, true));
                parameters.Add(SqlParms.CreateParameter("ENROLLMENT_STATUS_REASON_ID", DbType.Int32, reasonCodeID, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_DATE_TIME", DbType.DateTime, changedDate, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_USER", DbType.Guid, changedBy, true));
                DataAccess.ExecuteStoredProcedure("usp_UpdateEnrollmentStatusReasonIDByRegID", parameters);
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }

        public static void UpdateCredentialResult(int regId, int resultID, DateTime dateTime, string changedBy)
        {
            
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("REG_ID", DbType.Int32, regId, true));
                parameters.Add(SqlParms.CreateParameter("RESULT_ID", DbType.Int32, resultID, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_DATE_TIME", DbType.DateTime, dateTime, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_USER", DbType.Guid, changedBy, true));
                DataAccess.ExecuteStoredProcedure("usp_UpdateCREDENTIALING_RESULT", parameters);
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }

        public static bool HasPendingCredentialActivities(int regId)
        {
            DataSet dsCredential = null;          
            int credentialingId = 0;
            bool retPending = true;
            try
            {
                dsCredential = SelectProviderCredentialingData(regId);
                if (ObjectControllerHelper.HasRows(dsCredential))
                {
                    credentialingId = Convert.ToInt32(dsCredential.Tables[0].Rows[0]["credentialing_id"]);
                    if (credentialingId > 0)
                    {
                        DataSet dsActivities = SelectProviderCredentialActivityData(regId, credentialingId);
                        if (ObjectControllerHelper.HasRows(dsActivities))
                        {

                            DataRow[] drPending = dsActivities.Tables[0].Select("DATARANK_TYPE_ID=" + CON.ActivityDataRankId.pending);
                            //Has Pending activies
                            retPending = (drPending.Length > 0) ? true : false;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
            return retPending; 
        }

        public static bool IsRiskLevelAssigned(int regId)
        {
            DataSet dsCredential = SelectProviderCredentialingData(regId);
            int riskLevelid = 0;
            bool retPending = true;
            try
            {
                if (ObjectControllerHelper.HasRows(dsCredential))
                {
                    riskLevelid = Convert.ToInt32(dsCredential.Tables[0].Rows[0]["RISK_LEVEL_ID"]);
                    retPending = (riskLevelid > 0) ? true : false;
                }

            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
            return retPending;
        }

        public static void UpdateCredentialRisk(int CredentialingID, int riskID, DateTime dateTime, string changedBy)
        {

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("CREDENTIALING_ID", DbType.Int32, CredentialingID, true));
                parameters.Add(SqlParms.CreateParameter("RISK_ID", DbType.Int32, riskID, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_DATE_TIME", DbType.DateTime, dateTime, true));
                parameters.Add(SqlParms.CreateParameter("LAST_MODIFIED_USER", DbType.Guid, changedBy, true));
                DataAccess.ExecuteStoredProcedure("usp_UpdateCREDENTIALING_RISK", parameters);
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }

        public static DataSet SelectCredentialingResult()
        {
            try
            {

                DataSet ds = new DataSet();
                List<SqlParameter> parameters = new List<SqlParameter>();
                string storedProc = "usp_Select_Credentialing_Result";
                ds = DataAccess.ExecuteStoredProcedure(storedProc, parameters, "CredentialingResult");
                ds.Tables[0].TableName = "CredentialingResult";
                return ds;
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }

        public static DataSet SelectCredentialingComments(int regId, int credentialingId)
        {
            try
            {

                DataSet ds = new DataSet();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("REG_ID", DbType.Int32, regId, true));
                parameters.Add(SqlParms.CreateParameter("Credentialing_id", DbType.Int32, credentialingId, true));                
                string storedProc = "usp_SelectREG_Credentialing_COMMENTS";
                ds = DataAccess.ExecuteStoredProcedure(storedProc, parameters, "CredentialingComments");
                ds.Tables[0].TableName = "CredentialingComments";
                return ds;
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
        }

        public static bool IsHospitalBasedProvider(int regId)
        {
            //OHPNM-17233: if there are any current active hospital affiliations where the provider is NOT inpatient only then provider should go through credentialing 
            bool hospitalProvider = true;
            try
            {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlParms.CreateParameter("REG_ID", DbType.Int32, regId, false));
                DataSet ds = DataAccess.ExecuteStoredProcedure("usp_SelectREG_HEALTH_CARE_FACILITY_AFFILIATION", parameters, "HospitalAffiliations");

                if (ObjectControllerHelper.HasRows(ds))
                {
                    int rowCount = ds.Tables[0].Rows.Count;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        bool IsInpatientSetting = ObjectControllerHelper.GetBool("IsInpatientSetting", dr);

                        if (IsInpatientSetting == false)
                        {
                            hospitalProvider = false;
                        }                       
                    } 
                }
                else
                {
                    hospitalProvider = false;
                }
            }
            catch (Exception ex)
            {
                throw CoreException.ThrowException(ex);
            }
            return hospitalProvider;
        }
    }
}
