using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MAXIMUS.Controllers.PDMS.DataAccessUpgrade.DBHelpers;
using MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Models;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Repositories
{
    public class ACHRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public ACHRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<AchFeeInformationModel> SearchACHFeeInformation(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SearchAch_Fee_Information", parameters, MapSearchAchFeeInformationModel).ToList();
        }

        public List<AchFeeResultsModel> SelectACHFeeInformation(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectAch_Fee_Results", parameters, MapSelectAchFeeResultsModel).ToList();
        }

        public List<AchFeeInformationByPartyIDModel> SelectACHFeeInformationByPartyID(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectAch_Fee_InformationByPartyID", parameters, MapSelectAchFeeInformationByPartyIDModel).ToList();
        }

        public int InsertAchFeeInformation(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_InsertAchFeeInformation", parameters);
        }

        private AchFeeInformationModel MapSearchAchFeeInformationModel(SqlDataReader reader)
        {
            return new AchFeeInformationModel()
            {
                RegID = reader.GetNullableInt("REG_ID"),
                ProviderName = reader.GetNullableString("ProviderName") ?? string.Empty,
                TaxID = reader.GetNullableString("TaxID") ?? string.Empty,
                NPI = reader.GetNullableString("NPI") ?? string.Empty,
                MedicaidID = reader.GetNullableString("MedicaidID") ?? string.Empty,
                PaymentDate = reader.GetNullableDateTime("PAYMENT_DATE"),
                EdisonNumber = reader.GetNullableString("EDISON_NUMBER") ?? string.Empty,
                PaymentNumber = reader.GetNullableString("PAYMENT_NUMBER") ?? string.Empty,
                TotalResultCount = reader.GetNullableInt("TotalResultCount")
            };
        }


        private AchFeeResultsModel MapSelectAchFeeResultsModel(SqlDataReader reader)
        {
            return new AchFeeResultsModel()
            {
                RegID = reader.GetNullableInt("REG_ID"),
                ProviderName = reader.GetNullableString("ProviderName") ?? string.Empty,
                TaxID = reader.GetNullableString("TaxID") ?? string.Empty,
                NPI = reader.GetNullableString("NPI") ?? string.Empty,
                MedicaidID = reader.GetNullableString("MedicaidID") ?? string.Empty,
                PaymentDate = reader.GetNullableDateTime("PAYMENT_DATE"),
                EdisonNumber = reader.GetNullableString("EDISON_NUMBER") ?? string.Empty,
                PaymentNumber = reader.GetNullableString("PAYMENT_NUMBER") ?? string.Empty
            };
        }


        private AchFeeInformationByPartyIDModel MapSelectAchFeeInformationByPartyIDModel(SqlDataReader reader)
        {
            return new AchFeeInformationByPartyIDModel()
            {
                RegAchFeeInformationID = reader.GetNullableInt("REG_ACH_FEE_INFORMATION_ID"),
                RegID = reader.GetNullableInt("REG_ID"),
                PaymentDate = reader.GetNullableDateTime("PAYMENT_DATE"),
                EdisonNumber = reader.GetNullableString("EDISON_NUMBER") ?? string.Empty,
                PaymentNumber = reader.GetNullableString("PAYMENT_NUMBER") ?? string.Empty,
                CreateDateTime = reader.GetNullableDateTime("CREATE_DATE_TIME"),
                CreateUser = reader.GetNullableGuid("CREATE_USER"),
                LastModifiedDateTime = reader.GetNullableDateTime("LAST_MODIFIED_DATE_TIME"),
                LastModifiedUser = reader.GetNullableGuid("LAST_MODIFIED_USER"),
                AchFeeIdCore = reader.GetNullableInt("ACH_FEE_ID_CORE"),
                CreatedOnDateTime = reader.GetNullableDateTime("Created_On_Date_Time"),
                CreatedByUser = reader.GetNullableGuid("Created_By_User")
            };
        }


    }
}
