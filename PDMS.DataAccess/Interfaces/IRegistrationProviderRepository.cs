using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Interfaces
{
    public interface IRegistrationProviderRepository
    {
        RegistrationProviderInfoModel GetRegistrationProvider(int regId);
    }
}
