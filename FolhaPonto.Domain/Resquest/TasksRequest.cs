namespace FolhaPonto.Domain.Resquest
{
    public class TasksRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectsId { get; set; }
    }
}
