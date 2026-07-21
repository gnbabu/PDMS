using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IPartyRepository
    {
        List<DashboardStatisticsModel> SelectDashboardStatistics(SqlParameter[] parameters);
        DashboardProviderSummaryModelResult SelectDashboardProviderSummary(SqlParameter[] parameters);
        DashboardStatisticsGroupsModelResult SelectDashboardStatisticsGroups(SqlParameter[] parameters);
        List<DashboardStatisticsGroupsServicesModel> SelectDashboardStatisticsGroups_Services(SqlParameter[] parameters);
        GroupMemberProfileForDashboardsModelResult SelectDashboardStatisticsGroups_forGroupMemberProfile(SqlParameter[] parameters);
        DashboardStatisticsGroupTotalsModelResult SelectDashboardStatisticsGroupTotals(SqlParameter[] parameters);
        List<PARTYERRORHISTORYModel> SelectPartyErrorHistory(SqlParameter[] parameters);
        List<MedicaidIDsByMedicaidIDModel> GetMedicaidIdsByMedicaidId(SqlParameter[] parameters);
        List<MedicaidIdByUserNameModel> GetMedicaidIdsByUserName(SqlParameter[] parameters);
    }
}
