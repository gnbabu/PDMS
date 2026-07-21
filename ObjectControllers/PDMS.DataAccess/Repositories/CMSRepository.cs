using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class CMSRepository : Interfaces.ICMSRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public CMSRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<CMSCodeSetStatusModel> SelectCMSCodeSetStatusByName(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_Select_CMS_CodeSet_Status", parameters, MapSelectCMSCodeSetStatusModel).ToList();
        }

        public int SelectCMSCodeSetChangeCount(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_ReviewAndUpdate_CMS_CodeSet_Count", parameters);
        }

        private CMSCodeSetStatusModel MapSelectCMSCodeSetStatusModel(SqlDataReader reader)
        {
            return new CMSCodeSetStatusModel()
            {
                ApprovalStatus = reader.GetNullableString("ApprovalStatus") ?? string.Empty,
                LoadDate = reader.GetNullableString("LoadDate") ?? string.Empty,
                ReviewDate = reader.GetNullableString("ReviewDate") ?? string.Empty
            };
        }


    }
}
