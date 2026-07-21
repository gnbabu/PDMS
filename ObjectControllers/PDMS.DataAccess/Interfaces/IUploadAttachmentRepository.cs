using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IUploadAttachmentRepository
    {
        List<UploadAttachmentStatusModel> GetUploadAttachmentStatus(SqlParameter[] parameters, out int totalResultCount);
    }
}
