namespace FolhaPonto.Domain.Resquest
{
    public class TimeTrackersRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TimeZoneId { get; set; }
        public Guid TasksId { get; set; }
        public Guid CollaboratorsId { get; set; }
    }
}
