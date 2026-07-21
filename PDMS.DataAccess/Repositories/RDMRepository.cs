using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class RDMRepository : Interfaces.IRDMRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public RDMRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<RDMCodeSetstatusModel> SelectRDMCodeSetstatusByName(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectRDMCodeSetstatus", parameters, MapSelectRDMCodeSetstatusModel).ToList();
        }

        public int SelectRDMCodeSetChangeCount(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_ReviewAndUpdateRDMCodeSetCount", parameters);
        }

        private RDMCodeSetstatusModel MapSelectRDMCodeSetstatusModel(SqlDataReader reader)
        {
            return new RDMCodeSetstatusModel()
            {
                ApprovalStatus = reader.GetNullableString("ApprovalStatus") ?? string.Empty,
                LoadDate = reader.GetNullableString("LoadDate") ?? string.Empty,
                ReviewDate = reader.GetNullableString("ReviewDate") ?? string.Empty
            };
        }


    }
}
