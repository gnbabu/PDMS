using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class DashboardProviderSummaryModelResult
    {
        public List<DashboardProviderSummaryModelResultSet1> ResultSet1 { get; set; }
        public List<DashboardProviderSummaryModelResultSet2> ResultSet2 { get; set; }
        public List<DashboardProviderSummaryModelResultSet3> ResultSet3 { get; set; }
    }


    public class DashboardProviderSummaryModelResultSet1
    {
        public int? ProviderCategoryTypeID { get; set; }
        public string ProviderType { get; set; }
        public int? RevalidationDue { get; set; }
        public int? RevalidationInProgress { get; set; }
        public int? Updates { get; set; }
        public int? New { get; set; }
        public int? Terminated { get; set; }
        public int? Denied { get; set; }
        public int? Active { get; set; }
        public int? InActive { get; set; }
        public int? Maintenance { get; set; }
        public int? Conversion { get; set; }
    }


    public class DashboardProviderSummaryModelResultSet2
    {
    }


    public class DashboardProviderSummaryModelResultSet3
    {
        public int? ProviderCategoryTypeID { get; set; }
        public string ProviderType { get; set; }
        public decimal? RevalidationDue { get; set; }
        public decimal? RevalidationInProgress { get; set; }
        public decimal? Updates { get; set; }
        public decimal? New { get; set; }
        public decimal? Terminated { get; set; }
        public decimal? Denied { get; set; }
        public decimal? Active { get; set; }
        public decimal? InActive { get; set; }
        public decimal? Maintenance { get; set; }
        public decimal? Conversion { get; set; }
    }

}
