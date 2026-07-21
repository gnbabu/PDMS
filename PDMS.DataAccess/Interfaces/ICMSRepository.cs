using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface ICMSRepository
    {
        List<CMSCodeSetStatusModel> SelectCMSCodeSetStatusByName(SqlParameter[] parameters);
        int SelectCMSCodeSetChangeCount(SqlParameter[] parameters);
    }
}
