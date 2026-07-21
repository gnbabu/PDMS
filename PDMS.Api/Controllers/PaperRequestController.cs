using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for paper request operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PaperRequestController : ControllerBase
    {
        private readonly IPaperRequestRepository _repository;
        private readonly ILogger<PaperRequestController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaperRequestController"/> class.
        /// </summary>
        /// <param name="repository">The paper request repository.</param>
        /// <param name="logger">The logger.</param>
        public PaperRequestController(IPaperRequestRepository repository, ILogger<PaperRequestController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Inserts a paper request queue entry.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The number of affected records or generated identifier.</returns>
        [HttpPost("InsertPaperRequestQueue")]
        public ActionResult<int> InsertPaperRequestQueue([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(InsertPaperRequestQueue));
                var result = _repository.InsertPaperRequestQueue(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(InsertPaperRequestQueue));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(InsertPaperRequestQueue));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the paper request queue by user identifier.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The paper request queue by user identifier result.</returns>
        [HttpGet("SelectPaperRequestQueueByUserID")]
        public ActionResult<PAPERREQUESTQUEUEByUserIDModelResult> SelectPaperRequestQueueByUserID([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectPaperRequestQueueByUserID));
                var result = _repository.SelectPaperRequestQueueByUserID(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectPaperRequestQueueByUserID));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectPaperRequestQueueByUserID));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the provider operator dashboard by user identifier.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The paper request dashboard records.</returns>
        [HttpGet("SelectProviderOperatorDashboardByUserID")]
        public ActionResult<List<PaperRequestDashboardsModel>> SelectProviderOperatorDashboardByUserID([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectProviderOperatorDashboardByUserID));
                var result = _repository.SelectProviderOperatorDashboardByUserID(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectProviderOperatorDashboardByUserID));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectProviderOperatorDashboardByUserID));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the paper request queue by queue identifier.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The paper request queue records.</returns>
        [HttpGet("SelectPaperRequestQueueByQueueID")]
        public ActionResult<List<PAPERREQUESTQUEUEByQueueIDModel>> SelectPaperRequestQueueByQueueID([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectPaperRequestQueueByQueueID));
                var result = _repository.SelectPaperRequestQueueByQueueID(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectPaperRequestQueueByQueueID));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectPaperRequestQueueByQueueID));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Inserts a paper request error.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The number of affected records or generated identifier.</returns>
        [HttpPost("InsertPaperRequestError")]
        public ActionResult<int> InsertPaperRequestError([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(InsertPaperRequestError));
                var result = _repository.InsertPaperRequestError(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(InsertPaperRequestError));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(InsertPaperRequestError));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects paper request errors by queue identifier.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The outstanding paper request error records.</returns>
        [HttpGet("SelectPaperRequestErrorsByQueueID")]
        public ActionResult<List<PAPERREQUESTERROROutstandingByQueueIDModel>> SelectPaperRequestErrorsByQueueID([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectPaperRequestErrorsByQueueID));
                var result = _repository.SelectPaperRequestErrorsByQueueID(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectPaperRequestErrorsByQueueID));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectPaperRequestErrorsByQueueID));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects paper request match data.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The paper request match data records.</returns>
        [HttpGet("SelectPaperRequestMatchData")]
        public ActionResult<List<PAPERREQUESTQUEUEMatchDataModel>> SelectPaperRequestMatchData([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectPaperRequestMatchData));
                var result = _repository.SelectPaperRequestMatchData(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectPaperRequestMatchData));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectPaperRequestMatchData));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects a paper request by document handle.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The paper request by document handle records.</returns>
        [HttpGet("SelectPaperRequestByDocumentHandle")]
        public ActionResult<List<PaperRequestByDocumentHandleModel>> SelectPaperRequestByDocumentHandle([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectPaperRequestByDocumentHandle));
                var result = _repository.SelectPaperRequestByDocumentHandle(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectPaperRequestByDocumentHandle));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectPaperRequestByDocumentHandle));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the next unassigned paper request.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The identifier of the next unassigned paper request.</returns>
        [HttpGet("SelectNextUnassignedPaperRequest")]
        public ActionResult<int> SelectNextUnassignedPaperRequest([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectNextUnassignedPaperRequest));
                var result = _repository.SelectNextUnassignedPaperRequest(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectNextUnassignedPaperRequest));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectNextUnassignedPaperRequest));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects paper request documents by queue identifier.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The paper request document records.</returns>
        [HttpGet("SelectPaperRequestDocumentsByQueueID")]
        public ActionResult<List<PAPERREQUESTDOCUMENTByQueueIDModel>> SelectPaperRequestDocumentsByQueueID([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectPaperRequestDocumentsByQueueID));
                var result = _repository.SelectPaperRequestDocumentsByQueueID(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectPaperRequestDocumentsByQueueID));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectPaperRequestDocumentsByQueueID));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Inserts a paper request document.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The number of affected records or generated identifier.</returns>
        [HttpPost("InsertPaperRequestDocument")]
        public ActionResult<int> InsertPaperRequestDocument([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(InsertPaperRequestDocument));
                var result = _repository.InsertPaperRequestDocument(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(InsertPaperRequestDocument));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(InsertPaperRequestDocument));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
