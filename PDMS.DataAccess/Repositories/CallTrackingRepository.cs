using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class CallTrackingRepository : Interfaces.ICallTrackingRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public CallTrackingRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public int InsertCallTrackingCall(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_InsertCALLTRACKING_CALL", parameters);
        }

        public List<CALLTRACKINGCALLSBYRANGEModel> SelectCallsByRange(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectCALLTRACKING_CALLS_BYRANGE", parameters, MapSelectCALLTRACKINGCALLSBYRANGEModel).ToList();
        }

        private CALLTRACKINGCALLSBYRANGEModel MapSelectCALLTRACKINGCALLSBYRANGEModel(SqlDataReader reader)
        {
            return new CALLTRACKINGCALLSBYRANGEModel()
            {
                CallID = reader.GetNullableInt("CallID"),
                SourceID = reader.GetNullableInt("SourceID"),
                SubjectID = reader.GetNullableInt("SubjectID"),
                NextActionID = reader.GetNullableInt("NextActionID"),
                ResolutionID = reader.GetNullableInt("ResolutionID"),
                SourceName = reader.GetNullableString("SourceName") ?? string.Empty,
                SubjectName = reader.GetNullableString("SubjectName") ?? string.Empty,
                NextActionName = reader.GetNullableString("NextActionName") ?? string.Empty,
                ResolutionName = reader.GetNullableString("ResolutionName") ?? string.Empty,
                StartTime = reader.GetNullableDateTime("StartTime"),
                EndTime = reader.GetNullableDateTime("EndTime"),
                Duration = reader.GetNullableString("Duration") ?? string.Empty,
                UserID = reader.GetNullableInt("UserID"),
                UserName = reader.GetNullableString("UserName") ?? string.Empty,
                RegID = reader.GetNullableInt("RegID"),
                MemberID = reader.GetNullableInt("MemberID"),
                JudicialDistrict = reader.GetNullableString("JudicialDistrict") ?? string.Empty,
                CaseWorkerName = reader.GetNullableString("CaseWorkerName") ?? string.Empty,
                CallerOther = reader.GetNullableString("CallerOther") ?? string.Empty,
                ReasonOther = reader.GetNullableString("ReasonOther") ?? string.Empty,
                CallDetails = reader.GetNullableString("CallDetails") ?? string.Empty,
                NPI = reader.GetNullableString("NPI") ?? string.Empty,
                MedicaidID = reader.GetNullableString("MedicaidID") ?? string.Empty
            };
        }


    }
}
