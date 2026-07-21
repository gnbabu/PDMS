using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class REGHEALTHCAREFACILITYAFFILIATIONModelResult
    {
        public List<REGHEALTHCAREFACILITYAFFILIATIONModelResultSet1> ResultSet1 { get; set; }
        public List<REGHEALTHCAREFACILITYAFFILIATIONModelResultSet2> ResultSet2 { get; set; }
    }


    public class REGHEALTHCAREFACILITYAFFILIATIONModelResultSet1
    {
        public string FacilityName { get; set; }
        public bool IsInpatientSetting { get; set; }
    }


    public class REGHEALTHCAREFACILITYAFFILIATIONModelResultSet2
    {
        public int? REG_HEALTH_CARE_FACILITY_AFFILIATION_ID { get; set; }
        public bool? Is_Primary_Facility { get; set; }
        public int? REG_ID { get; set; }
        public string FacilityName { get; set; }
        public string StaffCategory { get; set; }
        public string StatusOfPrivileges { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsRestrictedPrivilege { get; set; }
        public string Reason { get; set; }
        public DateTime? LAST_MODIFIED_DATE_TIME { get; set; }
        public Guid? LAST_MODIFIED_USER { get; set; }
        public DateTime? Created_On_Date_Time { get; set; }
        public Guid? Created_By_User { get; set; }
        public string FacilityMedicaidID { get; set; }
        public bool? IsInpatientSetting { get; set; }
        public bool? IsHospitalPrivileges { get; set; }
        public string HospitalPrivilegesReason { get; set; }
        public string AHAHospitalID { get; set; }
    }

}
