using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class PAPERREQUESTDOCUMENTByQueueIDModel
    {
        public int? PAPER_REQUEST_QUEUE_ID { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string REG_PAGE_NAME { get; set; }
    }
}
