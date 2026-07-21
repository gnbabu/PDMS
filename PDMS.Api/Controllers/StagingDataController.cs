using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for staging data operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StagingDataController : ControllerBase
    {
        private readonly IStagingDataRepository _repository;
        private readonly ILogger<StagingDataController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StagingDataController"/> class.
        /// </summary>
        /// <param name="repository">The staging data repository.</param>
        /// <param name="logger">The logger.</param>
        public StagingDataController(IStagingDataRepository repository, ILogger<StagingDataController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Selects address staging types.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The address staging type records.</returns>
        [HttpGet("SelectAddressStagingTypes")]
        public ActionResult<List<AddressStagingTypesModel>> SelectAddressStagingTypes([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectAddressStagingTypes));
                var result = _repository.SelectAddressStagingTypes(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectAddressStagingTypes));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectAddressStagingTypes));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Gets staging provider enrollment.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The staging provider enrollment records.</returns>
        [HttpGet("GetStagingProviderEnrollment")]
        public ActionResult<List<StagingProviderEnrollmentByTransactionQueueIDModel>> GetStagingProviderEnrollment([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(GetStagingProviderEnrollment));
                var result = _repository.GetStagingProviderEnrollment(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(GetStagingProviderEnrollment));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(GetStagingProviderEnrollment));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
