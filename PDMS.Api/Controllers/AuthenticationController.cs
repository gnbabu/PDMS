using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for authentication related provider lookups.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _repository;
        private readonly ILogger<AuthenticationController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="repository">The authentication repository.</param>
        /// <param name="logger">The logger.</param>
        public AuthenticationController(IAuthenticationRepository repository, ILogger<AuthenticationController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Gets provider information from a user name.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The provider information records.</returns>
        [HttpGet("GetProviderInfoFromUserName")]
        public ActionResult<List<ProviderInfoFromUserModel>> GetProviderInfoFromUserName([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(GetProviderInfoFromUserName));
                var result = _repository.GetProviderInfoFromUserName(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(GetProviderInfoFromUserName));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(GetProviderInfoFromUserName));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
