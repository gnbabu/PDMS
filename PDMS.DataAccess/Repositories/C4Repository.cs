using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class C4Repository : Interfaces.IC4Repository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public C4Repository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<C4CodeSetStatusModel> SelectC4CodeSetStatusByName(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_Select_C4_CodeSet_Status", parameters, MapSelectC4CodeSetStatusModel).ToList();
        }

        public int SelectC4CodeSetChangeCount(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_ReviewAndUpdate_C4_CodeSet_Count", parameters);
        }

        private C4CodeSetStatusModel MapSelectC4CodeSetStatusModel(SqlDataReader reader)
        {
            return new C4CodeSetStatusModel()
            {
                ApprovalStatus = reader.GetNullableString("ApprovalStatus") ?? string.Empty,
                LoadDate = reader.GetNullableString("LoadDate") ?? string.Empty,
                ReviewDate = reader.GetNullableString("ReviewDate") ?? string.Empty
            };
        }


    }
}
