using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for provider feed operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderFeedController : ControllerBase
    {
        private readonly IProviderFeedRepository _repository;
        private readonly ILogger<ProviderFeedController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderFeedController"/> class.
        /// </summary>
        /// <param name="repository">The provider feed repository.</param>
        /// <param name="logger">The logger.</param>
        public ProviderFeedController(IProviderFeedRepository repository, ILogger<ProviderFeedController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Gets the provider feed.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The provider feed records.</returns>
        [HttpGet("GetProviderFeed")]
        public ActionResult<List<REGProviderFeedModel>> GetProviderFeed([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(GetProviderFeed));
                var result = _repository.GetProviderFeed(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(GetProviderFeed));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(GetProviderFeed));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Gets historic notes.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The historic notes result.</returns>
        [HttpGet("GetHistoricNotes")]
        public ActionResult<ProviderNotesModelResult> GetHistoricNotes([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(GetHistoricNotes));
                var result = _repository.GetHistoricNotes(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(GetHistoricNotes));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(GetHistoricNotes));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
