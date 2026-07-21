using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class AuthenticationRepository : Interfaces.IAuthenticationRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public AuthenticationRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<ProviderInfoFromUserModel> GetProviderInfoFromUserName(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_GetProviderInfoFromUser", parameters, MapGetProviderInfoFromUserModel).ToList();
        }

        private ProviderInfoFromUserModel MapGetProviderInfoFromUserModel(SqlDataReader reader)
        {
            return new ProviderInfoFromUserModel()
            {
                UserId = reader.GetNullableGuid("UserId"),
                UserName = reader.GetNullableString("UserName") ?? string.Empty,
                AccountExpires = reader.GetNullableDateTime("AccountExpires"),
                BadPasswordTime = reader.GetNullableDateTime("BadPasswordTime"),
                BadPasswordCount = reader.GetNullableInt("BadPasswordCount"),
                Description = reader.GetNullableString("Description") ?? string.Empty,
                DisplayName = reader.GetNullableString("DisplayName") ?? string.Empty,
                EmployeeID = reader.GetNullableString("EmployeeID") ?? string.Empty,
                GivenName = reader.GetNullableString("GivenName") ?? string.Empty,
                LastLogonTimestamp = reader.GetNullableDateTime("LastLogonTimestamp"),
                LogonCount = reader.GetNullableInt("LogonCount"),
                Mail = reader.GetNullableString("Mail") ?? string.Empty,
                Name = reader.GetNullableString("Name") ?? string.Empty,
                PwdLastSet = reader.GetNullableDateTime("PwdLastSet"),
                SN = reader.GetNullableString("SN") ?? string.Empty,
                TelephoneNumber = reader.GetNullableString("TelephoneNumber") ?? string.Empty,
                WhenChanged = reader.GetNullableDateTime("WhenChanged"),
                WhenCreated = reader.GetNullableDateTime("WhenCreated")
            };
        }
    }
}
