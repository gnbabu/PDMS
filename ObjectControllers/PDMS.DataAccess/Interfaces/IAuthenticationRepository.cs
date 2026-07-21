using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IAuthenticationRepository
    {
        List<ProviderInfoFromUserModel> GetProviderInfoFromUserName(SqlParameter[] parameters);
    }
}
