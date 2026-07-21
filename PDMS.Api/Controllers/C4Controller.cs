using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for C4 code set operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class C4Controller : ControllerBase
    {
        private readonly IC4Repository _repository;
        private readonly ILogger<C4Controller> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="C4Controller"/> class.
        /// </summary>
        /// <param name="repository">The C4 repository.</param>
        /// <param name="logger">The logger.</param>
        public C4Controller(IC4Repository repository, ILogger<C4Controller> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Selects the C4 code set status by name.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The C4 code set status records.</returns>
        [HttpGet("SelectC4CodeSetStatusByName")]
        public ActionResult<List<C4CodeSetStatusModel>> SelectC4CodeSetStatusByName([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectC4CodeSetStatusByName));
                var result = _repository.SelectC4CodeSetStatusByName(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectC4CodeSetStatusByName));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectC4CodeSetStatusByName));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the C4 code set change count.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The number of C4 code set changes.</returns>
        [HttpGet("SelectC4CodeSetChangeCount")]
        public ActionResult<int> SelectC4CodeSetChangeCount([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectC4CodeSetChangeCount));
                var result = _repository.SelectC4CodeSetChangeCount(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectC4CodeSetChangeCount));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectC4CodeSetChangeCount));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
