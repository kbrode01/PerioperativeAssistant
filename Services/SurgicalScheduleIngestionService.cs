using Microsoft.EntityFrameworkCore;
using PerioperativeAssistant.Data;
using PerioperativeAssistant.DTOs;
using PerioperativeAssistant.Models;

namespace PerioperativeAssistant.Services
{
    public class SurgicalScheduleIngestionService
    {
        private readonly ApplicationDbContext _context;

        public SurgicalScheduleIngestionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ScheduleImportResultDto> ImportScheduleAsync(
            IEnumerable<SurgicalScheduleImportDto> incomingCases)
        {
            var cases = incomingCases.ToList();

            var result = new ScheduleImportResultDto
            {
                Received = cases.Count
            };

            foreach (var incomingCase in cases)
            {
                var existingCase = await _context.SurgicalCases
                    .FirstOrDefaultAsync(c =>
                        c.CaseNumber == incomingCase.CaseNumber);

                if (existingCase == null)
                {
                    var surgicalCase = new SurgicalCase
                    {
                        CaseNumber = incomingCase.CaseNumber,
                        Location = incomingCase.Location,
                        Service = incomingCase.Service,
                        ProcedureType = incomingCase.ProcedureType,
                        ProcedureCode = incomingCase.ProcedureCode,
                        ProcedureCodeSystem = incomingCase.ProcedureCodeSystem,
                        ScheduledStart = incomingCase.ScheduledStart,
                        ScheduledDurationMinutes =
                            incomingCase.ScheduledDurationMinutes,
                        AnesthesiaType = incomingCase.AnesthesiaType,
                        Status = "Scheduled",
                        IsSynthetic = true
                    };

                    _context.SurgicalCases.Add(surgicalCase);

                    result.Created++;

                    continue;
                }

                if (HasScheduleChanged(existingCase, incomingCase))
                {
                    UpdateScheduleFields(existingCase, incomingCase);

                    result.Updated++;

                    continue;
                }

                result.Unchanged++;
            }

            await _context.SaveChangesAsync();

            return result;
        }

        private static bool HasScheduleChanged(
            SurgicalCase existingCase,
            SurgicalScheduleImportDto incomingCase)
        {
            return
                existingCase.Location != incomingCase.Location ||
                existingCase.Service != incomingCase.Service ||
                existingCase.ProcedureType != incomingCase.ProcedureType ||
                existingCase.ProcedureCode != incomingCase.ProcedureCode ||
                existingCase.ProcedureCodeSystem !=
                    incomingCase.ProcedureCodeSystem ||
                existingCase.ScheduledStart != incomingCase.ScheduledStart ||
                existingCase.ScheduledDurationMinutes !=
                    incomingCase.ScheduledDurationMinutes ||
                existingCase.AnesthesiaType != incomingCase.AnesthesiaType;
        }

        private static void UpdateScheduleFields(
            SurgicalCase existingCase,
            SurgicalScheduleImportDto incomingCase)
        {
            existingCase.Location = incomingCase.Location;
            existingCase.Service = incomingCase.Service;
            existingCase.ProcedureType = incomingCase.ProcedureType;
            existingCase.ProcedureCode = incomingCase.ProcedureCode;
            existingCase.ProcedureCodeSystem =
                incomingCase.ProcedureCodeSystem;
            existingCase.ScheduledStart = incomingCase.ScheduledStart;
            existingCase.ScheduledDurationMinutes =
                incomingCase.ScheduledDurationMinutes;
            existingCase.AnesthesiaType = incomingCase.AnesthesiaType;
        }
    }
}