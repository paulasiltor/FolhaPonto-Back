using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Infra.Contexto;

namespace FolhaPonto.Infra.Repository
{
    public class TimeTrackersRepository : BaseRepository<TimeTrackers>, ITimeTrackersRepository
    {
        public TimeTrackersRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TimeTrackers>> GetByTask(Guid taskId)
        {
            return (await GetAll()).Where(x => x.TasksId == taskId).AsEnumerable();
        }
    }
}