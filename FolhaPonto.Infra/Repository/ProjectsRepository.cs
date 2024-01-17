using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Infra.Contexto;

namespace FolhaPonto.Infra.Repository
{
    public class ProjectsRepository : BaseRepository<Projects>, IProjectsRepository
    {
        public ProjectsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
