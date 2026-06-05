namespace PerioperativeAssistant.DTOs
{
    public class SurgicalCaseDto
    {
        public string CaseNumber { get; set; } = string.Empty;
        public string PatientId { get; set; } = string.Empty;

        public string SurgeonName { get; set; } = string.Empty;
        public string AnesthesiologistName { get; set; } = string.Empty;
        public string CrnaName { get; set; } = string.Empty;
        public string AnesTechName { get; set; } = string.Empty;

        public DateTime SurgeryDate { get; set; }

        public string ProcedureType { get; set; } = string.Empty;
        public string AnesthesiaType { get; set; } = string.Empty;

        public string Status { get; set; } = "Scheduled";
        public string Notes { get; set; } = string.Empty;
    }
}