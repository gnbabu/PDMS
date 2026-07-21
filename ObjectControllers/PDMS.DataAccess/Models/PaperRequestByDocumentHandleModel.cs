using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class PaperRequestByDocumentHandleModel
    {
        public int? PAPER_REQUEST_QUEUE_ID { get; set; }
        public int? PAPER_REQUEST_TYPE_ID { get; set; }
        public int? PAPER_REQUEST_DOCUMENT_TYPE_ID { get; set; }
        public int? DOCUMENT_HANDLE_ID { get; set; }
        public int? PAPER_REQUEST_STATUS_TYPE_ID { get; set; }
        public int? PROVIDER_TYPE_ID { get; set; }
        public int? SPECIALTY_TYPE_ID { get; set; }
        public int? TAXONOMY_TYPE_ID { get; set; }
        public string TAXONOMY_CODE { get; set; }
        public string TAX_ID { get; set; }
        public string NPI { get; set; }
        public string MEDICAID_ID { get; set; }
        public string ZIP { get; set; }
        public string EXT_ZIP { get; set; }
        public DateTime? CREATED_ON_DATE_TIME { get; set; }
        public Guid? CREATED_BY_USER { get; set; }
        public DateTime? LAST_MODIFIED_DATE_TIME { get; set; }
        public Guid? LAST_MODIFIED_USER { get; set; }
        public string COMMENTS { get; set; }
        public int? APPLICATION_TYPE_ID { get; set; }
    }
}
