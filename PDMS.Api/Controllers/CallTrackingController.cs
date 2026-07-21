using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for call tracking operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CallTrackingController : ControllerBase
    {
        private readonly ICallTrackingRepository _repository;
        private readonly ILogger<CallTrackingController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallTrackingController"/> class.
        /// </summary>
        /// <param name="repository">The call tracking repository.</param>
        /// <param name="logger">The logger.</param>
        public CallTrackingController(ICallTrackingRepository repository, ILogger<CallTrackingController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Inserts a call tracking call.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The number of affected records or generated identifier.</returns>
        [HttpPost("InsertCallTrackingCall")]
        public ActionResult<int> InsertCallTrackingCall([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(InsertCallTrackingCall));
                var result = _repository.InsertCallTrackingCall(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(InsertCallTrackingCall));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(InsertCallTrackingCall));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects calls within a range.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The matching call records.</returns>
        [HttpGet("SelectCallsByRange")]
        public ActionResult<List<CALLTRACKINGCALLSBYRANGEModel>> SelectCallsByRange([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectCallsByRange));
                var result = _repository.SelectCallsByRange(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectCallsByRange));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectCallsByRange));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
