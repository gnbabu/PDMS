using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for NUBC code set operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NUBCController : ControllerBase
    {
        private readonly INUBCRepository _repository;
        private readonly ILogger<NUBCController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NUBCController"/> class.
        /// </summary>
        /// <param name="repository">The NUBC repository.</param>
        /// <param name="logger">The logger.</param>
        public NUBCController(INUBCRepository repository, ILogger<NUBCController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Selects the NUBC code set status by name.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The NUBC code set status records.</returns>
        [HttpGet("SelectNUBCCodeSetStatusByName")]
        public ActionResult<List<NUBCCodeSetStatusModel>> SelectNUBCCodeSetStatusByName([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectNUBCCodeSetStatusByName));
                var result = _repository.SelectNUBCCodeSetStatusByName(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectNUBCCodeSetStatusByName));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectNUBCCodeSetStatusByName));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the NUBC code set change count.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The number of NUBC code set changes.</returns>
        [HttpGet("SelectNUBCCodeSetChangeCount")]
        public ActionResult<int> SelectNUBCCodeSetChangeCount([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectNUBCCodeSetChangeCount));
                var result = _repository.SelectNUBCCodeSetChangeCount(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectNUBCCodeSetChangeCount));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectNUBCCodeSetChangeCount));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
