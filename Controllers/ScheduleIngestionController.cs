using Microsoft.AspNetCore.Mvc;
using PerioperativeAssistant.DTOs;
using PerioperativeAssistant.Services;
using PerioperativeAssistant.Ingestion.Synthetic;

namespace PerioperativeAssistant.Controllers
{
    [Route("api/ingestion/surgical-schedule")]
    [ApiController]
    public class ScheduleIngestionController : ControllerBase
    {
        private readonly SurgicalScheduleIngestionService _ingestionService;
        private readonly SyntheticScheduleCsvAdapter _csvAdapter;

        public ScheduleIngestionController(
            SurgicalScheduleIngestionService ingestionService,
            SyntheticScheduleCsvAdapter csvAdapter)
        {
            _ingestionService = ingestionService;
            _csvAdapter = csvAdapter;
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
        [HttpPost("synthetic-csv")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ScheduleImportResultDto>> ImportSyntheticCsv(
            IFormFile file)
        {
            if (file.Length == 0)
            {
                return BadRequest("The CSV file cannot be empty.");
            }

            await using var stream = file.OpenReadStream();

            var incomingCases = _csvAdapter.Parse(stream);

            if (incomingCases.Count == 0)
            {
                return BadRequest("The CSV file contains no surgical cases.");
            }

            var result = await _ingestionService.ImportScheduleAsync(incomingCases);

            return Ok(result);
        }
    }
}