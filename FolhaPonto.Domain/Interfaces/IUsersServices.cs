using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;

namespace FolhaPonto.Domain.Interfaces
{
    public interface IUsersServices
    {
        Task<IEnumerable<Users>> BuscarAll();
        Task<Users> BuscarId(Guid usersId);
        Task<bool> Post(UsersRequest request);
        Task<Users?> Put(Guid uderId, UsersRequest request);
        Task<Users> Delete(Guid uderId);
        Task<bool> Autorizar(UsersRequest users);
    }
}
