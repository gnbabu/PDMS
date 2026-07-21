using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class StagingDataRepository : Interfaces.IStagingDataRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public StagingDataRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<AddressStagingTypesModel> SelectAddressStagingTypes(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("sp_SelectAddressStagingTypes", parameters, MapSpSelectAddressStagingTypesModel).ToList();
        }

        public List<StagingProviderEnrollmentByTransactionQueueIDModel> GetStagingProviderEnrollment(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_GetStagingProviderEnrollmentByTransactionQueueID", parameters, MapGetStagingProviderEnrollmentByTransactionQueueIDModel).ToList();
        }

        private AddressStagingTypesModel MapSpSelectAddressStagingTypesModel(SqlDataReader reader)
        {
            return new AddressStagingTypesModel()
            {
                AddressStagingTypeID = reader.GetNullableInt("ADDRESS_STAGING_TYPE_ID"),
                Name = reader.GetNullableString("NAME") ?? string.Empty
            };
        }


        private StagingProviderEnrollmentByTransactionQueueIDModel MapGetStagingProviderEnrollmentByTransactionQueueIDModel(SqlDataReader reader)
        {
            return new StagingProviderEnrollmentByTransactionQueueIDModel()
            {
                MmisStagingGroupPK = reader.GetNullableInt("MMIS_STAGING_GROUP_PK"),
                TransactionTypeID = reader.GetNullableInt("TRANSACTION_TYPE_ID"),
                MmisStatusTypeID = reader.GetNullableInt("MMIS_STATUS_TYPE_ID"),
                MedicaidID = reader.GetNullableString("MEDICAID_ID") ?? string.Empty,
                Name = reader.GetNullableString("NAME") ?? string.Empty,
                NPI = reader.GetNullableString("NPI") ?? string.Empty,
                TaxIDValue = reader.GetNullableString("TAX_ID_VALUE") ?? string.Empty,
                EffectiveDate = reader.GetNullableDateTime("EFFECTIVE_DATE"),
                ProviderType = reader.GetNullableString("PROVIDER_TYPE") ?? string.Empty,
                Specialty = reader.GetNullableString("SPECIALTY") ?? string.Empty,
                EnrollmentStatusCode = reader.GetNullableString("ENROLLMENT_STATUS_CODE") ?? string.Empty,
                TermDate = reader.GetNullableDateTime("TERM_DATE"),
                ProviderCategory = reader.GetNullableString("PROVIDER_CATEGORY") ?? string.Empty,
                ProviderRiskLevel = reader.GetNullableString("PROVIDER_RISK_LEVEL") ?? string.Empty,
                TransactionQueueID = reader.GetNullableInt("TRANSACTION_QUEUE_ID"),
                LastModifiedDateTime = reader.GetNullableDateTime("LAST_MODIFIED_DATE_TIME")
            };
        }


    }
}
