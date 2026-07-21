using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class WPCRepository : Interfaces.IWPCRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public WPCRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<WPCCodeSetStatusModel> SelectWPCCodeSetStatusByName(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_Select_WPC_CodeSet_Status", parameters, MapSelectWPCCodeSetStatusModel).ToList();
        }

        public int SelectWPCCodeSetChangeCount(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_ReviewAndUpdate_WPC_CodeSet_Count", parameters);
        }

        private WPCCodeSetStatusModel MapSelectWPCCodeSetStatusModel(SqlDataReader reader)
        {
            return new WPCCodeSetStatusModel()
            {
                ApprovalStatus = reader.GetNullableString("ApprovalStatus") ?? string.Empty,
                LoadDate = reader.GetNullableString("LoadDate") ?? string.Empty,
                ReviewDate = reader.GetNullableString("ReviewDate") ?? string.Empty
            };
        }


    }
}
