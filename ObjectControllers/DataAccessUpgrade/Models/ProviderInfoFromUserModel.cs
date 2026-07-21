using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
   
    public class ProviderInfoFromUserModel
    {
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? AccountExpires { get; set; }
        public DateTime? BadPasswordTime { get; set; }
        public int? BadPasswordCount { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string EmployeeID { get; set; }
        public string GivenName { get; set; }
        public DateTime? LastLogonTimestamp { get; set; }
        public int? LogonCount { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public DateTime? PwdLastSet { get; set; }
        public string SN { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime? WhenChanged { get; set; }
        public DateTime? WhenCreated { get; set; }
    }
}
