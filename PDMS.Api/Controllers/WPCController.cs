using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for WPC code set operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WPCController : ControllerBase
    {
        private readonly IWPCRepository _repository;
        private readonly ILogger<WPCController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WPCController"/> class.
        /// </summary>
        /// <param name="repository">The WPC repository.</param>
        /// <param name="logger">The logger.</param>
        public WPCController(IWPCRepository repository, ILogger<WPCController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Selects the WPC code set status by name.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The WPC code set status records.</returns>
        [HttpGet("SelectWPCCodeSetStatusByName")]
        public ActionResult<List<WPCCodeSetStatusModel>> SelectWPCCodeSetStatusByName([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectWPCCodeSetStatusByName));
                var result = _repository.SelectWPCCodeSetStatusByName(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectWPCCodeSetStatusByName));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectWPCCodeSetStatusByName));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the WPC code set change count.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The number of WPC code set changes.</returns>
        [HttpGet("SelectWPCCodeSetChangeCount")]
        public ActionResult<int> SelectWPCCodeSetChangeCount([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectWPCCodeSetChangeCount));
                var result = _repository.SelectWPCCodeSetChangeCount(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectWPCCodeSetChangeCount));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectWPCCodeSetChangeCount));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
