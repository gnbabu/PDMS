using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for upload attachment status operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UploadAttachmentController : ControllerBase
    {
        private readonly IUploadAttachmentRepository _repository;
        private readonly ILogger<UploadAttachmentController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadAttachmentController"/> class.
        /// </summary>
        /// <param name="repository">The upload attachment repository.</param>
        /// <param name="logger">The logger.</param>
        public UploadAttachmentController(IUploadAttachmentRepository repository, ILogger<UploadAttachmentController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Gets the upload attachment status along with the total result count.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The upload attachment status records and the total result count.</returns>
        [HttpGet("GetUploadAttachmentStatus")]
        public IActionResult GetUploadAttachmentStatus([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(GetUploadAttachmentStatus));
                var result = _repository.GetUploadAttachmentStatus(parameters, out int totalResultCount);
                _logger.LogInformation("Successfully executed: {Action}", nameof(GetUploadAttachmentStatus));
                return Ok(new { data = result, totalResultCount });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(GetUploadAttachmentStatus));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
