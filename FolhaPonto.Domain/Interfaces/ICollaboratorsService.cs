using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;

namespace FolhaPonto.Domain.Interfaces
{
    public interface ICollaboratorsService
    {
        Task<IEnumerable<Collaborators>> BuscarAll();
        Task<Collaborators> BuscarId(Guid collaboratorsId);
        void Post(CollaboratorsRequest request);
        Task<Collaborators> Put(Guid collaboratorsId, CollaboratorsRequest request);
        Task<Collaborators> Delete(Guid collaboratorsId);
    }
}
