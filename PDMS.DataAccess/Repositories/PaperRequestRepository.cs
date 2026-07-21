using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class PaperRequestRepository : Interfaces.IPaperRequestRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public PaperRequestRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public int InsertPaperRequestQueue(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_InsertPAPER_REQUEST_QUEUE", parameters);
        }

        public PAPERREQUESTQUEUEByUserIDModelResult SelectPaperRequestQueueByUserID(SqlParameter[] parameters)
        {
            return ExecuteSelectPAPERREQUESTQUEUEByUserIDModel(parameters);
        }

        public List<PaperRequestDashboardsModel> SelectProviderOperatorDashboardByUserID(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_PaperRequestDashboards", parameters, MapPaperRequestDashboardsModel).ToList();
        }

        public List<PAPERREQUESTQUEUEByQueueIDModel> SelectPaperRequestQueueByQueueID(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectPAPER_REQUEST_QUEUEByQueueID", parameters, MapSelectPAPERREQUESTQUEUEByQueueIDModel).ToList();
        }

        public int InsertPaperRequestError(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_InsertPAPER_REQUEST_ERROR", parameters);
        }

        public List<PAPERREQUESTERROROutstandingByQueueIDModel> SelectPaperRequestErrorsByQueueID(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectPAPER_REQUEST_ERROROutstandingByQueueID", parameters, MapSelectPAPERREQUESTERROROutstandingByQueueIDModel).ToList();
        }

        public List<PAPERREQUESTQUEUEMatchDataModel> SelectPaperRequestMatchData(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectPAPER_REQUEST_QUEUEMatchData", parameters, MapSelectPAPERREQUESTQUEUEMatchDataModel).ToList();
        }

        public List<PaperRequestByDocumentHandleModel> SelectPaperRequestByDocumentHandle(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectPaperRequestByDocumentHandle", parameters, MapSelectPaperRequestByDocumentHandleModel).ToList();
        }

        public int SelectNextUnassignedPaperRequest(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_SelectNextUnassignedPaperRequest", parameters);
        }

        public List<PAPERREQUESTDOCUMENTByQueueIDModel> SelectPaperRequestDocumentsByQueueID(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectPAPER_REQUEST_DOCUMENTByQueueID", parameters, MapSelectPAPERREQUESTDOCUMENTByQueueIDModel).ToList();
        }

        public int InsertPaperRequestDocument(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteScalar<int>("usp_InsertPAPER_REQUEST_DOCUMENT", parameters);
        }

        private PAPERREQUESTQUEUEByUserIDModelResultSet1 MapSelectPAPERREQUESTQUEUEByUserIDModelResultSet1(SqlDataReader reader)
        {
            return new PAPERREQUESTQUEUEByUserIDModelResultSet1()
            {
                PaperRequestQueueID = reader.GetNullableInt("PaperRequestQueueID"),
                UserID = reader.GetNullableGuid("UserID"),
                PaperRequestTypeID = reader.GetNullableInt("PaperRequestTypeID"),
                PaperRequestStatusTypeID = reader.GetNullableInt("PaperRequestStatusTypeID"),
                ProviderName = reader.GetNullableString("ProviderName") ?? string.Empty,
                PaperRequestTypeName = reader.GetNullableString("PaperRequestTypeName") ?? string.Empty,
                TaxID = reader.GetNullableString("TaxID") ?? string.Empty,
                NPI = reader.GetNullableString("NPI") ?? string.Empty,
                SpecialtyTypeName = reader.GetNullableString("SpecialtyTypeName") ?? string.Empty,
                PracticeLocationZip = reader.GetNullableString("PracticeLocationZip") ?? string.Empty,
                Aging = reader.GetNullableInt("Aging")
            };
        }

        private PAPERREQUESTQUEUEByUserIDModelResultSet2 MapSelectPAPERREQUESTQUEUEByUserIDModelResultSet2(SqlDataReader reader)
        {
            return new PAPERREQUESTQUEUEByUserIDModelResultSet2()
            {
            };
        }

        private PAPERREQUESTQUEUEByUserIDModelResult ExecuteSelectPAPERREQUESTQUEUEByUserIDModel(SqlParameter[] parameters)
        {
            var result = new PAPERREQUESTQUEUEByUserIDModelResult();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("usp_SelectPAPER_REQUEST_QUEUEByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    var totalParam = new SqlParameter("@TotalResultCount", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output,
                        Value = 0
                    };
                    command.Parameters.Add(totalParam);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.ResultSet1 = new List<PAPERREQUESTQUEUEByUserIDModelResultSet1>();
                        while (reader.Read()) result.ResultSet1.Add(MapSelectPAPERREQUESTQUEUEByUserIDModelResultSet1(reader));
                    }
                    result.TotalCount = totalParam.Value == DBNull.Value ? 0 : Convert.ToInt32(totalParam.Value);
                }
            }
            return result;
        }


        private PaperRequestDashboardsModel MapPaperRequestDashboardsModel(SqlDataReader reader)
        {
            return new PaperRequestDashboardsModel()
            {
                PAPER_REQUEST_TYPE_NAME = reader.GetNullableString("PAPER_REQUEST_TYPE_NAME") ?? string.Empty,
                PAPER_REQUEST_TYPE_ID = reader.GetNullableInt("PAPER_REQUEST_TYPE_ID"),
                UNASSIGNED = reader.GetNullableDecimal("UNASSIGNED"),
                ASSIGNED = reader.GetNullableDecimal("ASSIGNED")
            };
        }


        private PAPERREQUESTQUEUEByQueueIDModel MapSelectPAPERREQUESTQUEUEByQueueIDModel(SqlDataReader reader)
        {
            return new PAPERREQUESTQUEUEByQueueIDModel()
            {
                PaperRequestQueueID = reader.GetNullableInt("PaperRequestQueueID"),
                UserID = reader.GetNullableGuid("UserID"),
                PaperRequestTypeID = reader.GetNullableInt("PaperRequestTypeID"),
                PaperRequestStatusTypeID = reader.GetNullableInt("PaperRequestStatusTypeID"),
                ProviderName = reader.GetNullableString("ProviderName") ?? string.Empty,
                PaperRequestTypeName = reader.GetNullableString("PaperRequestTypeName") ?? string.Empty,
                TaxID = reader.GetNullableString("TaxID") ?? string.Empty,
                NPI = reader.GetNullableString("NPI") ?? string.Empty,
                SpecialtyTypeName = reader.GetNullableString("SpecialtyTypeName") ?? string.Empty,
                PracticeLocationZip = reader.GetNullableString("PracticeLocationZip") ?? string.Empty,
                Aging = reader.GetNullableInt("Aging")
            };
        }


        private PAPERREQUESTERROROutstandingByQueueIDModel MapSelectPAPERREQUESTERROROutstandingByQueueIDModel(SqlDataReader reader)
        {
            return new PAPERREQUESTERROROutstandingByQueueIDModel()
            {
                PAPER_REQUEST_ERROR_ID = reader.GetNullableInt("PAPER_REQUEST_ERROR_ID"),
                ERROR_TYPE_ID = reader.GetNullableInt("ERROR_TYPE_ID"),
                ERROR_CODE = reader.GetNullableString("ERROR_CODE") ?? string.Empty,
                ERROR_NAME = reader.GetNullableString("ERROR_NAME") ?? string.Empty,
                ERROR_STATUS_TYPE_ID = reader.GetNullableInt("ERROR_STATUS_TYPE_ID"),
                ERROR_STATUS_TYPE = reader.GetNullableString("ERROR_STATUS_TYPE") ?? string.Empty,
                CREATED_ON_DATE_TIME = reader.GetNullableDateTime("CREATED_ON_DATE_TIME"),
                CREATED_BY_USER = reader.GetNullableString("CREATED_BY_USER") ?? string.Empty,
                LAST_MODIFIED_DATE_TIME = reader.GetNullableDateTime("LAST_MODIFIED_DATE_TIME"),
                LAST_MODIFIED_USER = reader.GetNullableString("LAST_MODIFIED_USER") ?? string.Empty,
                PAPER_REQUEST_QUEUE_ID = reader.GetNullableInt("PAPER_REQUEST_QUEUE_ID")
            };
        }


        private PAPERREQUESTQUEUEMatchDataModel MapSelectPAPERREQUESTQUEUEMatchDataModel(SqlDataReader reader)
        {
            return new PAPERREQUESTQUEUEMatchDataModel()
            {
                PaperRequestQueueID = reader.GetNullableInt("PaperRequestQueueID"),
                UserID = reader.GetNullableGuid("UserID"),
                ApplicationTypeID = reader.GetNullableInt("ApplicationTypeID"),
                ProviderTypeID = reader.GetNullableInt("ProviderTypeID"),
                ProviderCategoryTypeID = reader.GetNullableInt("ProviderCategoryTypeID"),
                SpecialtyTypeID = reader.GetNullableInt("SpecialtyTypeID"),
                SpecialtyTypeName = reader.GetNullableString("SpecialtyTypeName") ?? string.Empty,
                TaxonomyTypeID = reader.GetNullableInt("TaxonomyTypeID"),
                TaxonomyCode = reader.GetNullableString("TaxonomyCode") ?? string.Empty,
                ProviderName = reader.GetNullableString("ProviderName") ?? string.Empty,
                TaxID = reader.GetNullableString("TaxID") ?? string.Empty,
                NPI = reader.GetNullableString("NPI") ?? string.Empty,
                MedicaidID = reader.GetNullableString("MedicaidID") ?? string.Empty,
                ZipCode = reader.GetNullableString("ZipCode") ?? string.Empty,
                ZipExt = reader.GetNullableString("ZipExt") ?? string.Empty,
                PracticeLocationZip = reader.GetNullableString("PracticeLocationZip") ?? string.Empty,
                CurrentStatusType = reader.GetNullableString("CurrentStatusType") ?? string.Empty,
                RegID = reader.GetNullableInt("RegID"),
                DIDDReferralID = reader.GetNullableInt("DIDDReferralID"),
                ReferralTypeID = reader.GetNullableInt("ReferralTypeID"),
                RevalidationDate = reader.GetNullableDateTime("RevalidationDate"),
                PendingConvertedProvider = reader.GetNullableInt("PendingConvertedProvider")
            };
        }


        private PaperRequestByDocumentHandleModel MapSelectPaperRequestByDocumentHandleModel(SqlDataReader reader)
        {
            return new PaperRequestByDocumentHandleModel()
            {
                PAPER_REQUEST_QUEUE_ID = reader.GetNullableInt("PAPER_REQUEST_QUEUE_ID"),
                PAPER_REQUEST_TYPE_ID = reader.GetNullableInt("PAPER_REQUEST_TYPE_ID"),
                PAPER_REQUEST_DOCUMENT_TYPE_ID = reader.GetNullableInt("PAPER_REQUEST_DOCUMENT_TYPE_ID"),
                DOCUMENT_HANDLE_ID = reader.GetNullableInt("DOCUMENT_HANDLE_ID"),
                PAPER_REQUEST_STATUS_TYPE_ID = reader.GetNullableInt("PAPER_REQUEST_STATUS_TYPE_ID"),
                PROVIDER_TYPE_ID = reader.GetNullableInt("PROVIDER_TYPE_ID"),
                SPECIALTY_TYPE_ID = reader.GetNullableInt("SPECIALTY_TYPE_ID"),
                TAXONOMY_TYPE_ID = reader.GetNullableInt("TAXONOMY_TYPE_ID"),
                TAXONOMY_CODE = reader.GetNullableString("TAXONOMY_CODE") ?? string.Empty,
                TAX_ID = reader.GetNullableString("TAX_ID") ?? string.Empty,
                NPI = reader.GetNullableString("NPI") ?? string.Empty,
                MEDICAID_ID = reader.GetNullableString("MEDICAID_ID") ?? string.Empty,
                ZIP = reader.GetNullableString("ZIP") ?? string.Empty,
                EXT_ZIP = reader.GetNullableString("EXT_ZIP") ?? string.Empty,
                CREATED_ON_DATE_TIME = reader.GetNullableDateTime("CREATED_ON_DATE_TIME"),
                CREATED_BY_USER = reader.GetNullableGuid("CREATED_BY_USER"),
                LAST_MODIFIED_DATE_TIME = reader.GetNullableDateTime("LAST_MODIFIED_DATE_TIME"),
                LAST_MODIFIED_USER = reader.GetNullableGuid("LAST_MODIFIED_USER"),
                COMMENTS = reader.GetNullableString("COMMENTS") ?? string.Empty,
                APPLICATION_TYPE_ID = reader.GetNullableInt("APPLICATION_TYPE_ID")
            };
        }


        private PAPERREQUESTDOCUMENTByQueueIDModel MapSelectPAPERREQUESTDOCUMENTByQueueIDModel(SqlDataReader reader)
        {
            return new PAPERREQUESTDOCUMENTByQueueIDModel()
            {
                PAPER_REQUEST_QUEUE_ID = reader.GetNullableInt("PAPER_REQUEST_QUEUE_ID"),
                UserName = reader.GetNullableString("UserName") ?? string.Empty,
                RoleName = reader.GetNullableString("RoleName") ?? string.Empty,
                REG_PAGE_NAME = reader.GetNullableString("REG_PAGE_NAME") ?? string.Empty
            };
        }


    }
}
