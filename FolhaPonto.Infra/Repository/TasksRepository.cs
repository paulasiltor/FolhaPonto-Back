using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Infra.Contexto;

namespace FolhaPonto.Infra.Repository
{
    public class TasksRepository : BaseRepository<Tasks>, ITasksRepository
    {
        public TasksRepository(AppDbContext context) : base(context)
        {
        }
    }
}