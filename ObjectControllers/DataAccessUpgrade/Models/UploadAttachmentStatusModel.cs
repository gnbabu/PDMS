using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class UploadAttachmentStatusModel
    {
        public string OutBound_Document_Uploads_ID { get; set; }
        public string UploadType { get; set; }
        public string Member_ID { get; set; }
        public string provider_id { get; set; }
        public string OriginalDocumentName { get; set; }
        public string UploadedToS3 { get; set; }
        public string Documentname { get; set; }
        public string ZipFileCreated { get; set; }
    }
}
