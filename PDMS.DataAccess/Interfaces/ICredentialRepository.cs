using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface ICredentialRepository
    {
        List<PROVIDERCredentialingModel> SelectProviderCredentialingData(SqlParameter[] parameters);
        CredentialingScreeningActivityModelResult SelectProviderCredentialActivityData(SqlParameter[] parameters);
        CredentialActivityByIdModelResult SelectProviderCredentialActivityMatchData(SqlParameter[] parameters);
        List<ScreeningActivityUrlModel> SelectCredentialActivityUrl(SqlParameter[] parameters);
        List<COMMITTEEMEMBERModel> GetCredentialCommitteeMembers(SqlParameter[] parameters);
        List<InsertCommitteeCredentialActivityModel> InsertProviderCredentialingCommitteeMember(SqlParameter[] parameters);
        UpdateCOMMITTEECREDENTIALACTIVITYModelResult UpdateCredentialingCommitteeMember(SqlParameter[] parameters);
        List<CommitteeCredentialActivityModel> SelectCredentialingCommitteeActivity(SqlParameter[] parameters);
        List<COMMITTEEACTIVITYSTATUSModel> GetCommitteeActivityStatuses(SqlParameter[] parameters);
        List<CredentialingResultModel> SelectCredentialingResult(SqlParameter[] parameters);
        List<REGCredentialingCOMMENTSModel> SelectCredentialingComments(SqlParameter[] parameters);
        REGHEALTHCAREFACILITYAFFILIATIONModelResult IsHospitalBasedProvider(SqlParameter[] parameters);
    }
}
