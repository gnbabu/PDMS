using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
     public class PARTYERRORHISTORYModel
    {
        public int? RegErrorID { get; set; }
        public DateTime? ErrorStatusDateTime { get; set; }
        public int? ErrorStatusTypeID { get; set; }
        public int? CommunicationEventID { get; set; }
        public int? ResolvingActionTypeID { get; set; }
        public int? ResolvingReasonTypeID { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public Guid? LastModifiedUser { get; set; }
    }
}
