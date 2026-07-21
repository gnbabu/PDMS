using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface INUBCRepository
    {
        List<NUBCCodeSetStatusModel> SelectNUBCCodeSetStatusByName(SqlParameter[] parameters);
        int SelectNUBCCodeSetChangeCount(SqlParameter[] parameters);
    }
}
