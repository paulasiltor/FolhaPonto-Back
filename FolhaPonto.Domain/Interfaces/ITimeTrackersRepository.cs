using FolhaPonto.Domain.Models;

namespace FolhaPonto.Domain.Interfaces
{
    public interface ITimeTrackersRepository : IBaseRepository<TimeTrackers>
    {
        Task<IEnumerable<TimeTrackers>> GetByTask(Guid taskId);
    }
}
