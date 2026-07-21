using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class StatesModel
    {
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public string LastModifiedUser { get; set; }
        public int RecordStatus { get; set; }
    }
}
