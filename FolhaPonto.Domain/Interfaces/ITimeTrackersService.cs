using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;

namespace FolhaPonto.Domain.Interfaces
{
    public interface ITimeTrackersService
    {
        Task<IEnumerable<TimeTrackers>> BuscarAll();
        Task<TimeTrackers> BuscarId(Guid timeTrackersId);
        Task<bool> Post(TimeTrackersRequest request);
        Task<TimeTrackers?> Put(Guid timeTrackersId, TimeTrackersRequest request);
        Task<TimeTrackers> Delete(Guid timeTrackersId);
    }
}
