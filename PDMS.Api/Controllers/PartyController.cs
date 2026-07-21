using System.Data.SqlClient;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMS.Api.Controllers
{
    /// <summary>
    /// API endpoints for party and dashboard statistics operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PartyController : ControllerBase
    {
        private readonly IPartyRepository _repository;
        private readonly ILogger<PartyController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartyController"/> class.
        /// </summary>
        /// <param name="repository">The party repository.</param>
        /// <param name="logger">The logger.</param>
        public PartyController(IPartyRepository repository, ILogger<PartyController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Selects dashboard statistics.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The dashboard statistics records.</returns>
        [HttpGet("SelectDashboardStatistics")]
        public ActionResult<List<DashboardStatisticsModel>> SelectDashboardStatistics([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectDashboardStatistics));
                var result = _repository.SelectDashboardStatistics(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectDashboardStatistics));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectDashboardStatistics));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects the dashboard provider summary.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The dashboard provider summary result.</returns>
        [HttpGet("SelectDashboardProviderSummary")]
        public ActionResult<DashboardProviderSummaryModelResult> SelectDashboardProviderSummary([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectDashboardProviderSummary));
                var result = _repository.SelectDashboardProviderSummary(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectDashboardProviderSummary));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectDashboardProviderSummary));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects dashboard statistics groups.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The dashboard statistics groups result.</returns>
        [HttpGet("SelectDashboardStatisticsGroups")]
        public ActionResult<DashboardStatisticsGroupsModelResult> SelectDashboardStatisticsGroups([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectDashboardStatisticsGroups));
                var result = _repository.SelectDashboardStatisticsGroups(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectDashboardStatisticsGroups));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectDashboardStatisticsGroups));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects dashboard statistics groups services.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The dashboard statistics groups services records.</returns>
        [HttpGet("SelectDashboardStatisticsGroups_Services")]
        public ActionResult<List<DashboardStatisticsGroupsServicesModel>> SelectDashboardStatisticsGroups_Services([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectDashboardStatisticsGroups_Services));
                var result = _repository.SelectDashboardStatisticsGroups_Services(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectDashboardStatisticsGroups_Services));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectDashboardStatisticsGroups_Services));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects dashboard statistics groups for a group member profile.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The group member profile dashboards result.</returns>
        [HttpGet("SelectDashboardStatisticsGroups_forGroupMemberProfile")]
        public ActionResult<GroupMemberProfileForDashboardsModelResult> SelectDashboardStatisticsGroups_forGroupMemberProfile([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectDashboardStatisticsGroups_forGroupMemberProfile));
                var result = _repository.SelectDashboardStatisticsGroups_forGroupMemberProfile(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectDashboardStatisticsGroups_forGroupMemberProfile));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectDashboardStatisticsGroups_forGroupMemberProfile));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects dashboard statistics group totals.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The dashboard statistics group totals result.</returns>
        [HttpGet("SelectDashboardStatisticsGroupTotals")]
        public ActionResult<DashboardStatisticsGroupTotalsModelResult> SelectDashboardStatisticsGroupTotals([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectDashboardStatisticsGroupTotals));
                var result = _repository.SelectDashboardStatisticsGroupTotals(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectDashboardStatisticsGroupTotals));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectDashboardStatisticsGroupTotals));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Selects party error history.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The party error history records.</returns>
        [HttpGet("SelectPartyErrorHistory")]
        public ActionResult<List<PARTYERRORHISTORYModel>> SelectPartyErrorHistory([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(SelectPartyErrorHistory));
                var result = _repository.SelectPartyErrorHistory(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(SelectPartyErrorHistory));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(SelectPartyErrorHistory));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Gets Medicaid identifiers by Medicaid identifier.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The Medicaid identifier records.</returns>
        [HttpGet("GetMedicaidIdsByMedicaidId")]
        public ActionResult<List<MedicaidIDsByMedicaidIDModel>> GetMedicaidIdsByMedicaidId([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(GetMedicaidIdsByMedicaidId));
                var result = _repository.GetMedicaidIdsByMedicaidId(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(GetMedicaidIdsByMedicaidId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(GetMedicaidIdsByMedicaidId));
                return Problem("An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Gets Medicaid identifiers by user name.
        /// </summary>
        /// <param name="parameters">The SQL parameters for the stored procedure.</param>
        /// <returns>The Medicaid identifier records.</returns>
        [HttpGet("GetMedicaidIdsByUserName")]
        public ActionResult<List<MedicaidIdByUserNameModel>> GetMedicaidIdsByUserName([FromBody] SqlParameter[] parameters)
        {
            try
            {
                _logger.LogInformation("Request received: {Action}", nameof(GetMedicaidIdsByUserName));
                var result = _repository.GetMedicaidIdsByUserName(parameters);
                _logger.LogInformation("Successfully executed: {Action}", nameof(GetMedicaidIdsByUserName));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {Action}", nameof(GetMedicaidIdsByUserName));
                return Problem("An error occurred while processing the request.");
            }
        }
    }
}
