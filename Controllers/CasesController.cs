using Microsoft.AspNetCore.Mvc;
using PerioperativeAssistant.Data;
using PerioperativeAssistant.Models;
using PerioperativeAssistant.DTOs;
using Microsoft.EntityFrameworkCore;

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
                .OrderByDescending(c => c.SurgeryDate)
                .ToListAsync();
        }

        // GET: api/cases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurgicalCase>> GetCase(int id)
        {
            var surgicalCase = await _context.SurgicalCases.FindAsync(id);

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
                PatientId = dto.PatientId,
                SurgeonName = dto.SurgeonName,
                AnesthesiologistName = dto.AnesthesiologistName,
                CrnaName = dto.CrnaName,
                AnesTechName = dto.AnesTechName,
                SurgeryDate = dto.SurgeryDate,
                ProcedureType = dto.ProcedureType,
                AnesthesiaType = dto.AnesthesiaType,
                Status = dto.Status ?? "Scheduled",
                Notes = dto.Notes
            };

            _context.SurgicalCases.Add(surgicalCase);
            await _context.SaveChangesAsync();   // This generates the ID

            // Now Id should be populated
            return CreatedAtAction(nameof(GetCase), new { id = surgicalCase.Id }, surgicalCase);
        }
    }
}