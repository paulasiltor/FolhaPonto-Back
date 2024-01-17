using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;

namespace FolhaPonto.Domain.Services
{
    public class CollaboratorsService : ICollaboratorsService
    {
        private readonly ICollaboratorsRepository _collaboratorsRepository;

        public CollaboratorsService(ICollaboratorsRepository collaboratorsRepository)
        {
            _collaboratorsRepository = collaboratorsRepository;
        }

        public async Task<IEnumerable<Collaborators>> BuscarAll()
        {
            return await _collaboratorsRepository.GetAll();
        }

        public async Task<Collaborators> BuscarId(Guid collaboratorsId)
        {
            return await _collaboratorsRepository.GetById(collaboratorsId);
        }

        public void Post(CollaboratorsRequest request)
        {
            Collaborators users = new()
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            _collaboratorsRepository.Add(users);
        }

        public async Task<Collaborators> Put(Guid collaboratorsId, CollaboratorsRequest request)
        {
            var item = await BuscarId(collaboratorsId);

            if (item != null)
            {
                item.Name = request.Name;
                item.CreatedAt = DateTime.UtcNow;
                item.UpdateAt = DateTime.UtcNow;

                _collaboratorsRepository.Update(item);
            }

            return item;
        }

        public async Task<Collaborators> Delete(Guid collaboratorsId)
        {
            var item = await BuscarId(collaboratorsId);

            if (item != null)
            {
                item.DeleteAt = DateTime.UtcNow;
                item.UpdateAt = DateTime.Now;

                _collaboratorsRepository.Update(item);
            }

            return item;
        }
    }
}
