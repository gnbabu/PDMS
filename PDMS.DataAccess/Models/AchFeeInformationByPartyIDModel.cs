using System;
using System.Collections.Generic;

namespace PDMS.DataAccess.Models
{
    public class AchFeeInformationByPartyIDModel
    {
        public int? RegAchFeeInformationID { get; set; }
        public int? RegID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string EdisonNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public Guid? CreateUser { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public Guid? LastModifiedUser { get; set; }
        public int? AchFeeIdCore { get; set; }
        public DateTime? CreatedOnDateTime { get; set; }
        public Guid? CreatedByUser { get; set; }
    }
}
