using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Infra.Contexto;

namespace FolhaPonto.Infra.Repository
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        public UsersRepository(AppDbContext context) : base(context)
        {
        }
    }
}
