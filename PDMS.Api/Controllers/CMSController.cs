using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for CMS code set operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CMSController : ControllerBase
    {
        private readonly ICMSRepository _repository;
        private readonly ILogger<CMSController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CMSController"/> class.
        /// </summary>
        /// <param name="repository">The CMS repository.</param>
        /// <param name="logger">The logger.</param>
        public CMSController(ICMSRepository repository, ILogger<CMSController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Selects the CMS code set status by name.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The CMS code set status records.</returns>
        [HttpGet("SelectCMSCodeSetStatusByName")]
        public ActionResult<List<CMSCodeSetStatusModel>> SelectCMSCodeSetStatusByName([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectCMSCodeSetStatusByName));
                var result = _repository.SelectCMSCodeSetStatusByName(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectCMSCodeSetStatusByName));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectCMSCodeSetStatusByName));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the CMS code set change count.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The number of CMS code set changes.</returns>
        [HttpGet("SelectCMSCodeSetChangeCount")]
        public ActionResult<int> SelectCMSCodeSetChangeCount([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectCMSCodeSetChangeCount));
                var result = _repository.SelectCMSCodeSetChangeCount(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectCMSCodeSetChangeCount));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectCMSCodeSetChangeCount));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
