using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IC4Repository
    {
        List<C4CodeSetStatusModel> SelectC4CodeSetStatusByName(SqlParameter[] parameters);
        int SelectC4CodeSetChangeCount(SqlParameter[] parameters);
    }
}
