using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class StateRepository : Interfaces.IStateRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public StateRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<StatesModel> SelectStates(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectStates", parameters, MapSelectStatesModel).ToList();
        }

        public List<REQUIRECDSStatesModel> SelectCDSRequireStates(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectREQUIRE_CDSStates", parameters, MapSelectREQUIRECDSStatesModel).ToList();
        }

        public List<USStatesModel> SelectUSStates(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectUSStates", parameters, MapSelectUSStatesModel).ToList();
        }

        private StatesModel MapSelectStatesModel(SqlDataReader reader)
        {
            return new StatesModel()
            {
                StateId = reader.GetNullableInt("StateId"),
                StateName = reader.GetNullableString("StateName") ?? string.Empty,
                LastModifiedDateTime = reader.GetNullableDateTime("LastModifiedDateTime"),
                LastModifiedUser = reader.GetNullableString("LastModifiedUser") ?? string.Empty,
                RecordStatus = reader.GetNullableInt("RecordStatus") ?? 0
            };
        }


        private REQUIRECDSStatesModel MapSelectREQUIRECDSStatesModel(SqlDataReader reader)
        {
            return new REQUIRECDSStatesModel()
            {
                StateId = reader.GetNullableInt("StateId"),
                StateName = reader.GetNullableString("StateName") ?? string.Empty
            };
        }


        private USStatesModel MapSelectUSStatesModel(SqlDataReader reader)
        {
            return new USStatesModel()
            {
                STATE_ABBREV = reader.GetNullableString("STATE_ABBREV") ?? string.Empty,
                STATE_NAME = reader.GetNullableString("STATE_NAME") ?? string.Empty,
                LAST_MODIFIED_DATE_TIME = reader.GetNullableDateTime("LAST_MODIFIED_DATE_TIME"),
                LAST_MODIFIED_USER = reader.GetNullableString("LAST_MODIFIED_USER") ?? string.Empty,
                US_STATE = reader.GetNullableString("US_STATE") ?? string.Empty,
                FIPS_CODE = reader.GetNullableString("FIPS_CODE") ?? string.Empty,
                REQUIRE_CDS = reader.GetNullableString("REQUIRE_CDS") ?? string.Empty
            };
        }


    }
}
