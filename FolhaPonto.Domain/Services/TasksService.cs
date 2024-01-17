using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;

namespace FolhaPonto.Domain.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<IEnumerable<Tasks>> BuscarAll()
        {
            return await _tasksRepository.GetAll();
        }

        public async Task<Tasks> BuscarId(Guid timeTrackersId)
        {
            return await _tasksRepository.GetById(timeTrackersId);
        }

        public void Post(TasksRequest request)
        {
            Tasks tasks = new()
            {
                Name = request.Name,
                Description = request.Description,
                ProjectsId = request.ProjectsId,
                CreatedAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            _tasksRepository.Add(tasks);
        }

        public async Task<Tasks> Put(Guid tasksId, TasksRequest request)
        {
            var item = await BuscarId(tasksId);

            if (item != null)
            {
                item.Name = request.Name;
                item.Description = request.Description;
                item.ProjectsId = request.ProjectsId;
                item.CreatedAt = DateTime.UtcNow;
                item.UpdateAt = DateTime.UtcNow;

                _tasksRepository.Update(item);
            }

            return item;
        }

        public async Task<Tasks> Delete(Guid tasksId)
        {
            var item = await BuscarId(tasksId);

            if (item != null)
            {
                item.DeleteAt = DateTime.UtcNow;
                item.UpdateAt = DateTime.Now;

                _tasksRepository.Update(item);
            }

            return item;
        }
    }
}