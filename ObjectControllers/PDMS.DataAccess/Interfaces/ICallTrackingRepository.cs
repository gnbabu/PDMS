using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface ICallTrackingRepository
    {
        int InsertCallTrackingCall(SqlParameter[] parameters);
        List<CALLTRACKINGCALLSBYRANGEModel> SelectCallsByRange(SqlParameter[] parameters);
    }
}
