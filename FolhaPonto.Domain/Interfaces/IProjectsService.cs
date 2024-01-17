using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;

namespace FolhaPonto.Domain.Interfaces
{
    public interface IProjectsService
    {
        Task<IEnumerable<Projects>> BuscarAll();
        Task<Projects> BuscarId(Guid projectsId);
        void Post(ProjectsRequest request);
        Task<Projects> Put(Guid projectsId, ProjectsRequest request);
        Task<Projects> Delete(Guid projectsId);
    }
}
