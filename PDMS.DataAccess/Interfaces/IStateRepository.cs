using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IStateRepository
    {
        List<StatesModel> SelectStates(SqlParameter[] parameters);
        List<REQUIRECDSStatesModel> SelectCDSRequireStates(SqlParameter[] parameters);
        List<USStatesModel> SelectUSStates(SqlParameter[] parameters);
    }
}
