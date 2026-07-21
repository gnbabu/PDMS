using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MAXIMUS.Controllers.PDMS.DataAccessUpgrade.DBHelpers;
using MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Repositories
{
    public class RDMRepository
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
