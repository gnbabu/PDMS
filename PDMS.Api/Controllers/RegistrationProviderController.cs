using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for registration provider operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationProviderController : ControllerBase
    {
        private readonly IRegistrationProviderRepository _repository;
        private readonly ILogger<RegistrationProviderController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationProviderController"/> class.
        /// </summary>
        /// <param name="repository">The registration provider repository.</param>
        /// <param name="logger">The logger.</param>
        public RegistrationProviderController(IRegistrationProviderRepository repository, ILogger<RegistrationProviderController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Gets registration provider information by registration identifier.
        /// </summary>
        /// <param name="regId">The registration identifier.</param>
        /// <returns>The registration provider information, or <c>404</c> if not found.</returns>
        [HttpGet("GetRegistrationProvider/{regId:int}")]
        public ActionResult<RegistrationProviderInfoModel> GetRegistrationProvider(int regId)
        {
            try
            {
                _logger.LogInformation("Request received: {Action} for regId {RegId}", nameof(GetRegistrationProvider), regId);
                var result = _repository.GetRegistrationProvider(regId);
                if (result == null)
                {
                    _logger.LogInformation("No registration provider found for regId {RegId}", regId);
                    return NotFound();
                }

                _logger.LogInformation("Successfully executed: {Action}", nameof(GetRegistrationProvider));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(GetRegistrationProvider));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
