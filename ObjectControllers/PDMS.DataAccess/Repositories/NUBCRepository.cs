using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class NUBCRepository : Interfaces.INUBCRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public NUBCRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<NUBCCodeSetStatusModel> SelectNUBCCodeSetStatusByName(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_Select_NUBC_CodeSet_Status", parameters, MapSelectNUBCCodeSetStatusModel).ToList();
        }

        public int SelectNUBCCodeSetChangeCount(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_ReviewAndUpdate_NUBC_CodeSet_Count", parameters);
        }

        private NUBCCodeSetStatusModel MapSelectNUBCCodeSetStatusModel(SqlDataReader reader)
        {
            return new NUBCCodeSetStatusModel()
            {
                ApprovalStatus = reader.GetNullableString("ApprovalStatus") ?? string.Empty,
                LoadDate = reader.GetNullableString("LoadDate") ?? string.Empty,
                ReviewDate = reader.GetNullableString("ReviewDate") ?? string.Empty
            };
        }


    }
}
