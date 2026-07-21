using System.Configuration;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.Helpers
{
    public static class AppConfigHelper
    {
        public static bool GetBool(string key, bool defaultValue = false)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(value))
                return defaultValue;

            bool result;
            return bool.TryParse(value, out result) ? result : defaultValue;
        }

        public static bool SelectRegistrationData_Provider
        {
            get
            {
                return GetBool("SelectRegistrationData_Provider");
            }
        }
    }
}
