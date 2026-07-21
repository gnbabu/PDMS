using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IRDMRepository
    {
        List<RDMCodeSetstatusModel> SelectRDMCodeSetstatusByName(SqlParameter[] parameters);
        int SelectRDMCodeSetChangeCount(SqlParameter[] parameters);
    }
}
