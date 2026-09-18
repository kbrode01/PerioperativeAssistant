using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerioperativeAssistant.Data;
using PerioperativeAssistant.DTOs;
using PerioperativeAssistant.Models;

namespace PerioperativeAssistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurgicalCase>>> GetCases()
        {
            return await _context.SurgicalCases
                .OrderBy(c => c.ScheduledStart)
                .ToListAsync();
        }

        // GET: api/cases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurgicalCase>> GetCase(int id)
        {
            var surgicalCase = await _context.SurgicalCases
                .FirstOrDefaultAsync(c => c.Id == id);

            if (surgicalCase == null)
            {
                return NotFound($"Case with ID {id} not found.");
            }

            return surgicalCase;
        }

        // POST: api/cases
        [HttpPost]
        public async Task<ActionResult<SurgicalCase>> CreateCase(SurgicalCaseDto dto)
        {
            var surgicalCase = new SurgicalCase
            {
                CaseNumber = dto.CaseNumber,
                Location = dto.Location,
                Service = dto.Service,
                ProcedureType = dto.ProcedureType,
                ProcedureCode = dto.ProcedureCode,
                ProcedureCodeSystem = dto.ProcedureCodeSystem,
                ScheduledStart = dto.ScheduledStart,
                ScheduledDurationMinutes = dto.ScheduledDurationMinutes,
                AnesthesiaType = dto.AnesthesiaType,
                Status = dto.Status ?? "Scheduled",
                Notes = dto.Notes,
                IsSynthetic = dto.IsSynthetic
            };

            _context.SurgicalCases.Add(surgicalCase);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCase),
                new { id = surgicalCase.Id },
                surgicalCase);
        }
    }
}