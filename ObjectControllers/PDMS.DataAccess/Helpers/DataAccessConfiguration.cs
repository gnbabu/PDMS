namespace PDMS.DataAccess.Helpers
{
    /// <summary>
    /// Central holder for the data-access connection string used by the
    /// <see cref="DBHelpers.SqlDataAccessHelper"/>. The hosting application
    /// (e.g. the Web API) is expected to set <see cref="ConnectionString"/>
    /// once during start-up, typically from configuration.
    /// </summary>
    public static class DataAccessConfiguration
    {
        /// <summary>
        /// Gets or sets the SQL Server connection string used by all repositories.
        /// </summary>
        public static string ConnectionString { get; set; }
    }
}

namespace MAXIMUS.Core.Libraries
{
    /// <summary>
    /// Lightweight replacement for the external <c>MAXIMUS.Core.Libraries.AppSettings</c>
    /// helper so that the extracted data-access layer can build and run on .NET 8
    /// without the legacy CoreLibraries dependency. The connection string is sourced
    /// from <see cref="PDMS.DataAccess.Helpers.DataAccessConfiguration"/>.
    /// </summary>
    public static class AppSettings
    {
        /// <summary>
        /// Returns the configured SQL Server connection string.
        /// </summary>
        /// <returns>The connection string, or <c>null</c> if not configured.</returns>
        public static string GetConnectionString()
        {
            return PDMS.DataAccess.Helpers.DataAccessConfiguration.ConnectionString;
        }
    }
}
