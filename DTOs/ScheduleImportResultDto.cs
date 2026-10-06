namespace PerioperativeAssistant.DTOs
{
    public class ScheduleImportResultDto
    {
        public int Received { get; set; }

        public int Created { get; set; }

        public int Updated { get; set; }

        public int Unchanged { get; set; }

        public int Rejected { get; set; }
    }
}