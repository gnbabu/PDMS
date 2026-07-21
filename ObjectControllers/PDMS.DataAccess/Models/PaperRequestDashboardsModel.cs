using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class PaperRequestDashboardsModel
    {
        public string PAPER_REQUEST_TYPE_NAME { get; set; }
        public int? PAPER_REQUEST_TYPE_ID { get; set; }
        public decimal? UNASSIGNED { get; set; }
        public decimal? ASSIGNED { get; set; }
    }
}
