using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for provider credentialing operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CredentialController : ControllerBase
    {
        private readonly ICredentialRepository _repository;
        private readonly ILogger<CredentialController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialController"/> class.
        /// </summary>
        /// <param name="repository">The credential repository.</param>
        /// <param name="logger">The logger.</param>
        public CredentialController(ICredentialRepository repository, ILogger<CredentialController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Selects provider credentialing data.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The provider credentialing records.</returns>
        [HttpGet("SelectProviderCredentialingData")]
        public ActionResult<List<PROVIDERCredentialingModel>> SelectProviderCredentialingData([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectProviderCredentialingData));
                var result = _repository.SelectProviderCredentialingData(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectProviderCredentialingData));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectProviderCredentialingData));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects provider credential activity data.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The credentialing screening activity result.</returns>
        [HttpGet("SelectProviderCredentialActivityData")]
        public ActionResult<CredentialingScreeningActivityModelResult> SelectProviderCredentialActivityData([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectProviderCredentialActivityData));
                var result = _repository.SelectProviderCredentialActivityData(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectProviderCredentialActivityData));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectProviderCredentialActivityData));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects provider credential activity match data.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The credential activity by identifier result.</returns>
        [HttpGet("SelectProviderCredentialActivityMatchData")]
        public ActionResult<CredentialActivityByIdModelResult> SelectProviderCredentialActivityMatchData([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectProviderCredentialActivityMatchData));
                var result = _repository.SelectProviderCredentialActivityMatchData(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectProviderCredentialActivityMatchData));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectProviderCredentialActivityMatchData));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the credential activity URL.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The screening activity URL records.</returns>
        [HttpGet("SelectCredentialActivityUrl")]
        public ActionResult<List<ScreeningActivityUrlModel>> SelectCredentialActivityUrl([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectCredentialActivityUrl));
                var result = _repository.SelectCredentialActivityUrl(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectCredentialActivityUrl));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectCredentialActivityUrl));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Gets the credential committee members.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The committee member records.</returns>
        [HttpGet("GetCredentialCommitteeMembers")]
        public ActionResult<List<COMMITTEEMEMBERModel>> GetCredentialCommitteeMembers([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(GetCredentialCommitteeMembers));
                var result = _repository.GetCredentialCommitteeMembers(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(GetCredentialCommitteeMembers));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(GetCredentialCommitteeMembers));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Inserts a provider credentialing committee member.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The inserted committee credential activity records.</returns>
        [HttpPost("InsertProviderCredentialingCommitteeMember")]
        public ActionResult<List<InsertCommitteeCredentialActivityModel>> InsertProviderCredentialingCommitteeMember([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(InsertProviderCredentialingCommitteeMember));
                var result = _repository.InsertProviderCredentialingCommitteeMember(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(InsertProviderCredentialingCommitteeMember));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(InsertProviderCredentialingCommitteeMember));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Updates a credentialing committee member.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The update committee credential activity result.</returns>
        [HttpPut("UpdateCredentialingCommitteeMember")]
        public ActionResult<UpdateCOMMITTEECREDENTIALACTIVITYModelResult> UpdateCredentialingCommitteeMember([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(UpdateCredentialingCommitteeMember));
                var result = _repository.UpdateCredentialingCommitteeMember(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(UpdateCredentialingCommitteeMember));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(UpdateCredentialingCommitteeMember));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects credentialing committee activity.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The committee credential activity records.</returns>
        [HttpGet("SelectCredentialingCommitteeActivity")]
        public ActionResult<List<CommitteeCredentialActivityModel>> SelectCredentialingCommitteeActivity([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectCredentialingCommitteeActivity));
                var result = _repository.SelectCredentialingCommitteeActivity(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectCredentialingCommitteeActivity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectCredentialingCommitteeActivity));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Gets committee activity statuses.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The committee activity status records.</returns>
        [HttpGet("GetCommitteeActivityStatuses")]
        public ActionResult<List<COMMITTEEACTIVITYSTATUSModel>> GetCommitteeActivityStatuses([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(GetCommitteeActivityStatuses));
                var result = _repository.GetCommitteeActivityStatuses(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(GetCommitteeActivityStatuses));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(GetCommitteeActivityStatuses));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the credentialing result.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The credentialing result records.</returns>
        [HttpGet("SelectCredentialingResult")]
        public ActionResult<List<CredentialingResultModel>> SelectCredentialingResult([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectCredentialingResult));
                var result = _repository.SelectCredentialingResult(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectCredentialingResult));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectCredentialingResult));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects credentialing comments.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The credentialing comment records.</returns>
        [HttpGet("SelectCredentialingComments")]
        public ActionResult<List<REGCredentialingCOMMENTSModel>> SelectCredentialingComments([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectCredentialingComments));
                var result = _repository.SelectCredentialingComments(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectCredentialingComments));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectCredentialingComments));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Determines whether the provider is hospital based.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The health care facility affiliation result.</returns>
        [HttpGet("IsHospitalBasedProvider")]
        public ActionResult<REGHEALTHCAREFACILITYAFFILIATIONModelResult> IsHospitalBasedProvider([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(IsHospitalBasedProvider));
                var result = _repository.IsHospitalBasedProvider(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(IsHospitalBasedProvider));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(IsHospitalBasedProvider));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
