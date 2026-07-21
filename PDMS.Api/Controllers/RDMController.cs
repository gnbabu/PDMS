using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for RDM code set operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RDMController : ControllerBase
    {
        private readonly IRDMRepository _repository;
        private readonly ILogger<RDMController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RDMController"/> class.
        /// </summary>
        /// <param name="repository">The RDM repository.</param>
        /// <param name="logger">The logger.</param>
        public RDMController(IRDMRepository repository, ILogger<RDMController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Selects the RDM code set status by name.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The RDM code set status records.</returns>
        [HttpGet("SelectRDMCodeSetstatusByName")]
        public ActionResult<List<RDMCodeSetstatusModel>> SelectRDMCodeSetstatusByName([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectRDMCodeSetstatusByName));
                var result = _repository.SelectRDMCodeSetstatusByName(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectRDMCodeSetstatusByName));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectRDMCodeSetstatusByName));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the RDM code set change count.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The number of RDM code set changes.</returns>
        [HttpGet("SelectRDMCodeSetChangeCount")]
        public ActionResult<int> SelectRDMCodeSetChangeCount([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectRDMCodeSetChangeCount));
                var result = _repository.SelectRDMCodeSetChangeCount(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectRDMCodeSetChangeCount));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectRDMCodeSetChangeCount));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
