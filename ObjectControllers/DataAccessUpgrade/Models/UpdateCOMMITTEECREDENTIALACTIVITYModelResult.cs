using System;
using System.Collections.Generic;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models
{
    public class UpdateCOMMITTEECREDENTIALACTIVITYModelResult
    {
        public List<UpdateCOMMITTEECREDENTIALACTIVITYModelResultSet1> ResultSet1 { get; set; }
        public List<UpdateCOMMITTEECREDENTIALACTIVITYModelResultSet2> ResultSet2 { get; set; }
    }


    public class UpdateCOMMITTEECREDENTIALACTIVITYModelResultSet1
    {
        public string Expr { get; set; }
    }


    public class UpdateCOMMITTEECREDENTIALACTIVITYModelResultSet2
    {
    }

}
