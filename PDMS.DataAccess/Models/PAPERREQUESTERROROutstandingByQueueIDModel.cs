using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class PAPERREQUESTERROROutstandingByQueueIDModel
    {
        public int? PAPER_REQUEST_ERROR_ID { get; set; }
        public int? ERROR_TYPE_ID { get; set; }
        public string ERROR_CODE { get; set; }
        public string ERROR_NAME { get; set; }
        public int? ERROR_STATUS_TYPE_ID { get; set; }
        public string ERROR_STATUS_TYPE { get; set; }
        public DateTime? CREATED_ON_DATE_TIME { get; set; }
        public string CREATED_BY_USER { get; set; }
        public DateTime? LAST_MODIFIED_DATE_TIME { get; set; }
        public string LAST_MODIFIED_USER { get; set; }
        public int? PAPER_REQUEST_QUEUE_ID { get; set; }
    }
}
