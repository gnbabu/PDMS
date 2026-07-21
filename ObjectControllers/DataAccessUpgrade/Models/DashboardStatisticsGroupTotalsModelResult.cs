using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class DashboardStatisticsGroupTotalsModelResult
    {
        public List<DashboardStatisticsGroupTotalsModelResultSet1> ResultSet1 { get; set; }
        public List<DashboardStatisticsGroupTotalsModelResultSet2> ResultSet2 { get; set; }
    }


    public class DashboardStatisticsGroupTotalsModelResultSet1
    {
        public int? REG_ID { get; set; }
    }


     public class DashboardStatisticsGroupTotalsModelResultSet2
    {
        public int? TableId { get; set; }
        public string Status { get; set; }
        public int? StatusID { get; set; }
        public int? Maintenance { get; set; }
        public int? Conversion { get; set; }
        public int? Updates { get; set; }
        public int? AdminReview { get; set; }
        public int? Total { get; set; }
        public int? New { get; set; }
        public int? Terminated { get; set; }
        public int? Suspended { get; set; }
    }

}
