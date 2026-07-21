using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for state lookup operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _repository;
        private readonly ILogger<StateController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateController"/> class.
        /// </summary>
        /// <param name="repository">The state repository.</param>
        /// <param name="logger">The logger.</param>
        public StateController(IStateRepository repository, ILogger<StateController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Selects states.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The state records.</returns>
        [HttpGet("SelectStates")]
        public ActionResult<List<StatesModel>> SelectStates([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectStates));
                var result = _repository.SelectStates(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectStates));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectStates));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects states that require CDS.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The CDS-required state records.</returns>
        [HttpGet("SelectCDSRequireStates")]
        public ActionResult<List<REQUIRECDSStatesModel>> SelectCDSRequireStates([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectCDSRequireStates));
                var result = _repository.SelectCDSRequireStates(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectCDSRequireStates));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectCDSRequireStates));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects US states.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The US state records.</returns>
        [HttpGet("SelectUSStates")]
        public ActionResult<List<USStatesModel>> SelectUSStates([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectUSStates));
                var result = _repository.SelectUSStates(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectUSStates));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectUSStates));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
