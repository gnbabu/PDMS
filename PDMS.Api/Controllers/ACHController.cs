using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for ACH fee information operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ACHController : ControllerBase
    {
        private readonly IACHRepository _repository;
        private readonly ILogger<ACHController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ACHController"/> class.
        /// </summary>
        /// <param name="repository">The ACH repository.</param>
        /// <param name="logger">The logger.</param>
        public ACHController(IACHRepository repository, ILogger<ACHController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Searches ACH fee information.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The matching ACH fee information records.</returns>
        [HttpGet("SearchACHFeeInformation")]
        public ActionResult<List<AchFeeInformationModel>> SearchACHFeeInformation([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SearchACHFeeInformation));
                var result = _repository.SearchACHFeeInformation(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SearchACHFeeInformation));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SearchACHFeeInformation));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects ACH fee information results.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The ACH fee results records.</returns>
        [HttpGet("SelectACHFeeInformation")]
        public ActionResult<List<AchFeeResultsModel>> SelectACHFeeInformation([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectACHFeeInformation));
                var result = _repository.SelectACHFeeInformation(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectACHFeeInformation));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectACHFeeInformation));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects ACH fee information by party identifier.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The ACH fee information records for the party.</returns>
        [HttpGet("SelectACHFeeInformationByPartyID")]
        public ActionResult<List<AchFeeInformationByPartyIDModel>> SelectACHFeeInformationByPartyID([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectACHFeeInformationByPartyID));
                var result = _repository.SelectACHFeeInformationByPartyID(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectACHFeeInformationByPartyID));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectACHFeeInformationByPartyID));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Inserts ACH fee information.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The number of affected records or generated identifier.</returns>
        [HttpPost("InsertAchFeeInformation")]
        public ActionResult<int> InsertAchFeeInformation([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(InsertAchFeeInformation));
                var result = _repository.InsertAchFeeInformation(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(InsertAchFeeInformation));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(InsertAchFeeInformation));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
