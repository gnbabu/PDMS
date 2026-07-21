using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class GroupMemberProfileForDashboardsModelResult
    {
        public List<GetGroupMemberProfileForDashboardsModelResultSet1> ResultSet1 { get; set; }
        public List<GetGroupMemberProfileForDashboardsModelResultSet2> ResultSet2 { get; set; }
        public List<GetGroupMemberProfileForDashboardsModelResultSet3> ResultSet3 { get; set; }
    }


     public class GetGroupMemberProfileForDashboardsModelResultSet1
    {
        public int? TableID { get; set; }
        public int? StatusID { get; set; }
        public decimal? SortKey { get; set; }
        public string Status { get; set; }
        public int? Days0_30 { get; set; }
        public int? Days31_60 { get; set; }
        public int? Days61_90 { get; set; }
        public int? Days90Plus { get; set; }
        public int? Total { get; set; }
        public bool? IsAssigned { get; set; }
    }


     public class GetGroupMemberProfileForDashboardsModelResultSet2
    {
        public int? TableID { get; set; }
        public int? StatusID { get; set; }
        public int? Ordinal { get; set; }
        public int? REG_ID { get; set; }
        public bool? IsAssigned { get; set; }
    }


    public class GetGroupMemberProfileForDashboardsModelResultSet3
    {
        public int? REG_ID { get; set; }
        public bool? IsAssigned { get; set; }
    }

}
