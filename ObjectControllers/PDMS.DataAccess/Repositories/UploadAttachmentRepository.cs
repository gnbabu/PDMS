using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class UploadAttachmentRepository : Interfaces.IUploadAttachmentRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public UploadAttachmentRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<UploadAttachmentStatusModel> GetUploadAttachmentStatus(SqlParameter[] parameters, out int totalResultCount)
        {
            totalResultCount = 0;
            var result = new List<UploadAttachmentStatusModel>();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("usp_Get_Upload_Attachment_Status", connection))
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
                        while (reader.Read())
                        {
                            result.Add(MapUploadAttachmentStatusModel(reader));
                        }
                    }
                    totalResultCount = totalParam.Value == DBNull.Value ? 0 : Convert.ToInt32(totalParam.Value);
                }
            }
            return result;
        }

        private UploadAttachmentStatusModel MapUploadAttachmentStatusModel(SqlDataReader reader)
        {
            return new UploadAttachmentStatusModel()
            {
                OutBound_Document_Uploads_ID = reader.GetNullableString("OutBound_Document_Uploads_ID") ?? string.Empty,
                UploadType = reader.GetNullableString("UploadType") ?? string.Empty,
                Member_ID = reader.GetNullableString("Member_ID") ?? string.Empty,
                provider_id = reader.GetNullableString("provider_id") ?? string.Empty,
                OriginalDocumentName = reader.GetNullableString("OriginalDocumentName") ?? string.Empty,
                UploadedToS3 = reader.GetNullableString("Uploaded to S3") ?? string.Empty,
                Documentname = reader.GetNullableString("Documentname") ?? string.Empty,
                ZipFileCreated = reader.GetNullableString("Zip file created") ?? string.Empty
            };
        }
    }
}
