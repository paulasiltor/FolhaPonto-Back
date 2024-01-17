using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;

namespace FolhaPonto.Domain.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;

        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<IEnumerable<Projects>> BuscarAll()
        {
            return await _projectsRepository.GetAll();
        }

        public async Task<Projects> BuscarId(Guid projectsId)
        {
            return await _projectsRepository.GetById(projectsId);
        }

        public void Post(ProjectsRequest request)
        {
            Projects projects = new()
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            _projectsRepository.Add(projects);
        }

        public async Task<Projects> Put(Guid projectsId, ProjectsRequest request)
        {
            var item = await BuscarId(projectsId);

            if (item != null)
            {
                item.Name = request.Name;
                item.CreatedAt = DateTime.UtcNow;
                item.UpdateAt = DateTime.UtcNow;

                _projectsRepository.Update(item);
            }

            return item;
        }

        public async Task<Projects> Delete(Guid projectsId)
        {
            var item = await BuscarId(projectsId);

            if (item != null)
            {
                item.DeleteAt = DateTime.UtcNow;
                item.UpdateAt = DateTime.Now;

                _projectsRepository.Update(item);
            }

            return item;
        }
    }
}
