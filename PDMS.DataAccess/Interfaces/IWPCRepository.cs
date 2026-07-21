using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IWPCRepository
    {
        List<WPCCodeSetStatusModel> SelectWPCCodeSetStatusByName(SqlParameter[] parameters);
        int SelectWPCCodeSetChangeCount(SqlParameter[] parameters);
    }
}
