using Microsoft.AspNetCore.Mvc;
using PerioperativeAssistant.DTOs;
using PerioperativeAssistant.Services;

namespace PerioperativeAssistant.Controllers
{
    [Route("api/ingestion/surgical-schedule")]
    [ApiController]
    public class ScheduleIngestionController : ControllerBase
    {
        private readonly SurgicalScheduleIngestionService _ingestionService;

        public ScheduleIngestionController(
            SurgicalScheduleIngestionService ingestionService)
        {
            _ingestionService = ingestionService;
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleImportResultDto>> ImportSchedule(
            [FromBody] List<SurgicalScheduleImportDto> incomingCases)
        {
            if (incomingCases.Count == 0)
            {
                return BadRequest("The surgical schedule cannot be empty.");
            }

            var result = await _ingestionService.ImportScheduleAsync(
                incomingCases);

            return Ok(result);
        }
    }
}