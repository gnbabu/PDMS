using System.Collections.Generic;
using System.Data.SqlClient;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IStagingDataRepository
    {
        List<AddressStagingTypesModel> SelectAddressStagingTypes(SqlParameter[] parameters);
        List<StagingProviderEnrollmentByTransactionQueueIDModel> GetStagingProviderEnrollment(SqlParameter[] parameters);
    }
}
