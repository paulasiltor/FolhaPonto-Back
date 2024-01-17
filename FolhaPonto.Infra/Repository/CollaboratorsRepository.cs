using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Infra.Contexto;

namespace FolhaPonto.Infra.Repository
{
    public class CollaboratorsRepository : BaseRepository<Collaborators>, ICollaboratorsRepository
    {
        public CollaboratorsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
