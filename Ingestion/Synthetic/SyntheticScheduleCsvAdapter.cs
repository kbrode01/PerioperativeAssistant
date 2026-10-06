using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using PerioperativeAssistant.DTOs;

namespace PerioperativeAssistant.Ingestion.Synthetic
{
    public class SyntheticScheduleCsvAdapter
    {
        public List<SurgicalScheduleImportDto> Parse(Stream csvStream)
        {
            using var reader = new StreamReader(csvStream);

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
                TrimOptions = TrimOptions.Trim
            };

            using var csv = new CsvReader(reader, configuration);

            var records = csv.GetRecords<SyntheticScheduleCsvRow>().ToList();

            return records
                .Select(MapToImportDto)
                .ToList();
        }

        private static SurgicalScheduleImportDto MapToImportDto(
            SyntheticScheduleCsvRow row)
        {
            return new SurgicalScheduleImportDto
            {
                CaseNumber = row.CaseNumber,
                Location = row.Location,
                Service = row.Service,
                ProcedureType = row.ProcedureType,
                ProcedureCode = row.ProcedureCode,
                ProcedureCodeSystem = row.ProcedureCodeSystem,
                ScheduledStart = row.ScheduledStart,
                ScheduledDurationMinutes = row.ScheduledDurationMinutes,
                AnesthesiaType = row.AnesthesiaType
            };
        }

        private class SyntheticScheduleCsvRow
        {
            public string CaseNumber { get; set; } = string.Empty;

            public string Location { get; set; } = string.Empty;

            public string Service { get; set; } = string.Empty;

            public string ProcedureType { get; set; } = string.Empty;

            public string ProcedureCode { get; set; } = string.Empty;

            public string ProcedureCodeSystem { get; set; } = string.Empty;

            public DateTime ScheduledStart { get; set; }

            public int ScheduledDurationMinutes { get; set; }

            public DateTime? ActualStart { get; set; }

            public DateTime? ActualEnd { get; set; }

            public int? ActualDurationMinutes { get; set; }

            public string AnesthesiaType { get; set; } = string.Empty;

            public string Status { get; set; } = string.Empty;

            public string Notes { get; set; } = string.Empty;

            public bool IsSynthetic { get; set; }
        }
    }
}