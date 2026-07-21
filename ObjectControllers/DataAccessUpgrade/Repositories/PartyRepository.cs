using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MAXIMUS.Controllers.PDMS.DataAccessUpgrade.DBHelpers;
using MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Repositories
{
    public class PartyRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public PartyRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<DashboardStatisticsModel> SelectDashboardStatistics(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_DashboardStatistics", parameters, MapDashboardStatisticsModel).ToList();
        }

        public DashboardProviderSummaryModelResult SelectDashboardProviderSummary(SqlParameter[] parameters)
        {
            return ExecuteDashboardProviderSummaryModel(parameters);
        }

        public DashboardStatisticsGroupsModelResult SelectDashboardStatisticsGroups(SqlParameter[] parameters)
        {
            return ExecuteDashboardStatisticsGroupsModel(parameters);
        }

        public List<DashboardStatisticsGroupsServicesModel> SelectDashboardStatisticsGroups_Services(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_DashboardStatisticsGroups_Services", parameters, MapDashboardStatisticsGroupsServicesModel).ToList();
        }

        public GroupMemberProfileForDashboardsModelResult SelectDashboardStatisticsGroups_forGroupMemberProfile(SqlParameter[] parameters)
        {
            return ExecuteGetGroupMemberProfileForDashboardsModel(parameters);
        }

        public DashboardStatisticsGroupTotalsModelResult SelectDashboardStatisticsGroupTotals(SqlParameter[] parameters)
        {
            return ExecuteDashboardStatisticsGroupTotalsModel(parameters);
        }

        public List<PARTYERRORHISTORYModel> SelectPartyErrorHistory(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("sp_selectPARTY_ERROR_HISTORY", parameters, MapSpSelectPARTYERRORHISTORYModel).ToList();
        }

        public List<MedicaidIDsByMedicaidIDModel> GetMedicaidIdsByMedicaidId(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_MedicaidIDsByMedicaidID", parameters, MapMedicaidIDsByMedicaidIDModel).ToList();
        }

        public List<MedicaidIdByUserNameModel> GetMedicaidIdsByUserName(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_GetMedicaidIdByUserName", parameters, MapGetMedicaidIdByUserNameModel).ToList();
        }

        private DashboardStatisticsModel MapDashboardStatisticsModel(SqlDataReader reader)
        {
            return new DashboardStatisticsModel()
            {
            };
        }


        private DashboardProviderSummaryModelResultSet1 MapDashboardProviderSummaryModelResultSet1(SqlDataReader reader)
        {
            return new DashboardProviderSummaryModelResultSet1()
            {
                ProviderCategoryTypeID = reader.GetNullableInt("ProviderCategoryTypeID"),
                ProviderType = reader.GetNullableString("ProviderType") ?? string.Empty,
                RevalidationDue = reader.GetNullableInt("RevalidationDue"),
                RevalidationInProgress = reader.GetNullableInt("RevalidationInProgress"),
                Updates = reader.GetNullableInt("Updates"),
                New = reader.GetNullableInt("New"),
                Terminated = reader.GetNullableInt("Terminated"),
                Denied = reader.GetNullableInt("Denied"),
                Active = reader.GetNullableInt("Active"),
                InActive = reader.GetNullableInt("InActive"),
                Maintenance = reader.GetNullableInt("Maintenance"),
                Conversion = reader.GetNullableInt("Conversion")
            };
        }

        private DashboardProviderSummaryModelResultSet2 MapDashboardProviderSummaryModelResultSet2(SqlDataReader reader)
        {
            return new DashboardProviderSummaryModelResultSet2()
            {
            };
        }

        private DashboardProviderSummaryModelResultSet3 MapDashboardProviderSummaryModelResultSet3(SqlDataReader reader)
        {
            return new DashboardProviderSummaryModelResultSet3()
            {
                ProviderCategoryTypeID = reader.GetNullableInt("ProviderCategoryTypeID"),
                ProviderType = reader.GetNullableString("ProviderType") ?? string.Empty,
                RevalidationDue = reader.GetNullableDecimal("RevalidationDue"),
                RevalidationInProgress = reader.GetNullableDecimal("RevalidationInProgress"),
                Updates = reader.GetNullableDecimal("Updates"),
                New = reader.GetNullableDecimal("New"),
                Terminated = reader.GetNullableDecimal("Terminated"),
                Denied = reader.GetNullableDecimal("Denied"),
                Active = reader.GetNullableDecimal("Active"),
                InActive = reader.GetNullableDecimal("InActive"),
                Maintenance = reader.GetNullableDecimal("Maintenance"),
                Conversion = reader.GetNullableDecimal("Conversion")
            };
        }

        private DashboardProviderSummaryModelResult ExecuteDashboardProviderSummaryModel(SqlParameter[] parameters)
        {
            var result = new DashboardProviderSummaryModelResult();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("usp_Dashboard_Provider_Summary", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.ResultSet1 = new List<DashboardProviderSummaryModelResultSet1>();
                        while (reader.Read()) result.ResultSet1.Add(MapDashboardProviderSummaryModelResultSet1(reader));
                        reader.NextResult();
                        result.ResultSet2 = new List<DashboardProviderSummaryModelResultSet2>();
                        while (reader.Read()) result.ResultSet2.Add(MapDashboardProviderSummaryModelResultSet2(reader));
                        reader.NextResult();
                        result.ResultSet3 = new List<DashboardProviderSummaryModelResultSet3>();
                        while (reader.Read()) result.ResultSet3.Add(MapDashboardProviderSummaryModelResultSet3(reader));
                    }
                }
            }
            return result;
        }


        private DashboardStatisticsGroupsModelResultSet1 MapDashboardStatisticsGroupsModelResultSet1(SqlDataReader reader)
        {
            return new DashboardStatisticsGroupsModelResultSet1()
            {
                TableID = reader.GetNullableInt("TableID"),
                StatusID = reader.GetNullableInt("StatusID"),
                SortKey = reader.GetNullableDecimal("SortKey"),
                Status = reader.GetNullableString("Status") ?? string.Empty,
                Days0_30 = reader.GetNullableInt("Days0_30"),
                Days31_60 = reader.GetNullableInt("Days31_60"),
                Days61_90 = reader.GetNullableInt("Days61_90"),
                Days90Plus = reader.GetNullableInt("Days90Plus"),
                Total = reader.GetNullableInt("Total"),
                IsAssigned = reader.GetNullableBool("IsAssigned")
            };
        }

        private DashboardStatisticsGroupsModelResultSet2 MapDashboardStatisticsGroupsModelResultSet2(SqlDataReader reader)
        {
            return new DashboardStatisticsGroupsModelResultSet2()
            {
                TableID = reader.GetNullableInt("TableID"),
                StatusID = reader.GetNullableInt("StatusID"),
                Ordinal = reader.GetNullableInt("Ordinal"),
                REG_ID = reader.GetNullableInt("REG_ID"),
                IsAssigned = reader.GetNullableBool("IsAssigned")
            };
        }

        private DashboardStatisticsGroupsModelResultSet3 MapDashboardStatisticsGroupsModelResultSet3(SqlDataReader reader)
        {
            return new DashboardStatisticsGroupsModelResultSet3()
            {
            };
        }

        private DashboardStatisticsGroupsModelResultSet4 MapDashboardStatisticsGroupsModelResultSet4(SqlDataReader reader)
        {
            return new DashboardStatisticsGroupsModelResultSet4()
            {
                REG_ID = reader.GetNullableInt("REG_ID"),
                IsAssigned = reader.GetNullableBool("IsAssigned")
            };
        }

        private DashboardStatisticsGroupsModelResult ExecuteDashboardStatisticsGroupsModel(SqlParameter[] parameters)
        {
            var result = new DashboardStatisticsGroupsModelResult();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("usp_DashboardStatisticsGroups", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.ResultSet1 = new List<DashboardStatisticsGroupsModelResultSet1>();
                        while (reader.Read()) result.ResultSet1.Add(MapDashboardStatisticsGroupsModelResultSet1(reader));
                        reader.NextResult();
                        result.ResultSet2 = new List<DashboardStatisticsGroupsModelResultSet2>();
                        while (reader.Read()) result.ResultSet2.Add(MapDashboardStatisticsGroupsModelResultSet2(reader));
                        reader.NextResult();
                        result.ResultSet3 = new List<DashboardStatisticsGroupsModelResultSet3>();
                        while (reader.Read()) result.ResultSet3.Add(MapDashboardStatisticsGroupsModelResultSet3(reader));
                        reader.NextResult();
                        result.ResultSet4 = new List<DashboardStatisticsGroupsModelResultSet4>();
                        while (reader.Read()) result.ResultSet4.Add(MapDashboardStatisticsGroupsModelResultSet4(reader));
                    }
                }
            }
            return result;
        }


        private DashboardStatisticsGroupsServicesModel MapDashboardStatisticsGroupsServicesModel(SqlDataReader reader)
        {
            return new DashboardStatisticsGroupsServicesModel()
            {
            };
        }


        private GetGroupMemberProfileForDashboardsModelResultSet1 MapGetGroupMemberProfileForDashboardsModelResultSet1(SqlDataReader reader)
        {
            return new GetGroupMemberProfileForDashboardsModelResultSet1()
            {
                TableID = reader.GetNullableInt("TableID"),
                StatusID = reader.GetNullableInt("StatusID"),
                SortKey = reader.GetNullableDecimal("SortKey"),
                Status = reader.GetNullableString("Status") ?? string.Empty,
                Days0_30 = reader.GetNullableInt("Days0_30"),
                Days31_60 = reader.GetNullableInt("Days31_60"),
                Days61_90 = reader.GetNullableInt("Days61_90"),
                Days90Plus = reader.GetNullableInt("Days90Plus"),
                Total = reader.GetNullableInt("Total"),
                IsAssigned = reader.GetNullableBool("IsAssigned")
            };
        }

        private GetGroupMemberProfileForDashboardsModelResultSet2 MapGetGroupMemberProfileForDashboardsModelResultSet2(SqlDataReader reader)
        {
            return new GetGroupMemberProfileForDashboardsModelResultSet2()
            {
                TableID = reader.GetNullableInt("TableID"),
                StatusID = reader.GetNullableInt("StatusID"),
                Ordinal = reader.GetNullableInt("Ordinal"),
                REG_ID = reader.GetNullableInt("REG_ID"),
                IsAssigned = reader.GetNullableBool("IsAssigned")
            };
        }

        private GetGroupMemberProfileForDashboardsModelResultSet3 MapGetGroupMemberProfileForDashboardsModelResultSet3(SqlDataReader reader)
        {
            return new GetGroupMemberProfileForDashboardsModelResultSet3()
            {
                REG_ID = reader.GetNullableInt("REG_ID"),
                IsAssigned = reader.GetNullableBool("IsAssigned")
            };
        }

        private GroupMemberProfileForDashboardsModelResult ExecuteGetGroupMemberProfileForDashboardsModel(SqlParameter[] parameters)
        {
            var result = new GroupMemberProfileForDashboardsModelResult();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("usp_GetGroupMemberProfile_ForDashboards", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.ResultSet1 = new List<GetGroupMemberProfileForDashboardsModelResultSet1>();
                        while (reader.Read()) result.ResultSet1.Add(MapGetGroupMemberProfileForDashboardsModelResultSet1(reader));
                        reader.NextResult();
                        result.ResultSet2 = new List<GetGroupMemberProfileForDashboardsModelResultSet2>();
                        while (reader.Read()) result.ResultSet2.Add(MapGetGroupMemberProfileForDashboardsModelResultSet2(reader));
                        reader.NextResult();
                        result.ResultSet3 = new List<GetGroupMemberProfileForDashboardsModelResultSet3>();
                        while (reader.Read()) result.ResultSet3.Add(MapGetGroupMemberProfileForDashboardsModelResultSet3(reader));
                    }
                }
            }
            return result;
        }


        private DashboardStatisticsGroupTotalsModelResultSet1 MapDashboardStatisticsGroupTotalsModelResultSet1(SqlDataReader reader)
        {
            return new DashboardStatisticsGroupTotalsModelResultSet1()
            {
                REG_ID = reader.GetNullableInt("REG_ID")
            };
        }

        private DashboardStatisticsGroupTotalsModelResultSet2 MapDashboardStatisticsGroupTotalsModelResultSet2(SqlDataReader reader)
        {
            return new DashboardStatisticsGroupTotalsModelResultSet2()
            {
                TableId = reader.GetNullableInt("TableId"),
                Status = reader.GetNullableString("Status") ?? string.Empty,
                StatusID = reader.GetNullableInt("StatusID"),
                Maintenance = reader.GetNullableInt("Maintenance"),
                Conversion = reader.GetNullableInt("Conversion"),
                Updates = reader.GetNullableInt("Updates"),
                AdminReview = reader.GetNullableInt("AdminReview"),
                Total = reader.GetNullableInt("Total"),
                New = reader.GetNullableInt("New"),
                Terminated = reader.GetNullableInt("Terminated"),
                Suspended = reader.GetNullableInt("Suspended")
            };
        }

        private DashboardStatisticsGroupTotalsModelResult ExecuteDashboardStatisticsGroupTotalsModel(SqlParameter[] parameters)
        {
            var result = new DashboardStatisticsGroupTotalsModelResult();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("usp_DashboardStatisticsGroupTotals", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.ResultSet1 = new List<DashboardStatisticsGroupTotalsModelResultSet1>();
                        while (reader.Read()) result.ResultSet1.Add(MapDashboardStatisticsGroupTotalsModelResultSet1(reader));
                        reader.NextResult();
                        result.ResultSet2 = new List<DashboardStatisticsGroupTotalsModelResultSet2>();
                        while (reader.Read()) result.ResultSet2.Add(MapDashboardStatisticsGroupTotalsModelResultSet2(reader));
                    }
                }
            }
            return result;
        }


        private PARTYERRORHISTORYModel MapSpSelectPARTYERRORHISTORYModel(SqlDataReader reader)
        {
            return new PARTYERRORHISTORYModel()
            {
                RegErrorID = reader.GetNullableInt("REG_ERROR_ID"),
                ErrorStatusDateTime = reader.GetNullableDateTime("ERROR_STATUS_DATE_TIME"),
                ErrorStatusTypeID = reader.GetNullableInt("ERROR_STATUS_TYPE_ID"),
                CommunicationEventID = reader.GetNullableInt("COMMUNICATION_EVENT_ID"),
                ResolvingActionTypeID = reader.GetNullableInt("RESOLVING_ACTION_TYPE_ID"),
                ResolvingReasonTypeID = reader.GetNullableInt("RESOLVING_REASON_TYPE_ID"),
                LastModifiedDateTime = reader.GetNullableDateTime("LAST_MODIFIED_DATE_TIME"),
                LastModifiedUser = reader.GetNullableGuid("LAST_MODIFIED_USER")
            };
        }


        private MedicaidIDsByMedicaidIDModel MapMedicaidIDsByMedicaidIDModel(SqlDataReader reader)
        {
            return new MedicaidIDsByMedicaidIDModel()
            {
                MedicaidID = reader.GetNullableString("MedicaidID") ?? string.Empty
            };
        }


        private MedicaidIdByUserNameModel MapGetMedicaidIdByUserNameModel(SqlDataReader reader)
        {
            return new MedicaidIdByUserNameModel()
            {
                MedicaidID = reader.GetNullableString("MedicaidID") ?? string.Empty
            };
        }


    }
}
