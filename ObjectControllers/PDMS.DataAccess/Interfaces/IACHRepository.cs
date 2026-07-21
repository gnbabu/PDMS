using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IACHRepository
    {
        List<AchFeeInformationModel> SearchACHFeeInformation(SqlParameter[] parameters);
        List<AchFeeResultsModel> SelectACHFeeInformation(SqlParameter[] parameters);
        List<AchFeeInformationByPartyIDModel> SelectACHFeeInformationByPartyID(SqlParameter[] parameters);
        int InsertAchFeeInformation(SqlParameter[] parameters);
    }
}
