using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IPaperRequestRepository
    {
        int InsertPaperRequestQueue(SqlParameter[] parameters);
        PAPERREQUESTQUEUEByUserIDModelResult SelectPaperRequestQueueByUserID(SqlParameter[] parameters);
        List<PaperRequestDashboardsModel> SelectProviderOperatorDashboardByUserID(SqlParameter[] parameters);
        List<PAPERREQUESTQUEUEByQueueIDModel> SelectPaperRequestQueueByQueueID(SqlParameter[] parameters);
        int InsertPaperRequestError(SqlParameter[] parameters);
        List<PAPERREQUESTERROROutstandingByQueueIDModel> SelectPaperRequestErrorsByQueueID(SqlParameter[] parameters);
        List<PAPERREQUESTQUEUEMatchDataModel> SelectPaperRequestMatchData(SqlParameter[] parameters);
        List<PaperRequestByDocumentHandleModel> SelectPaperRequestByDocumentHandle(SqlParameter[] parameters);
        int SelectNextUnassignedPaperRequest(SqlParameter[] parameters);
        List<PAPERREQUESTDOCUMENTByQueueIDModel> SelectPaperRequestDocumentsByQueueID(SqlParameter[] parameters);
        int InsertPaperRequestDocument(SqlParameter[] parameters);
    }
}
