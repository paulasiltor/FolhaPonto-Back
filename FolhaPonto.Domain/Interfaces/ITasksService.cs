using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;

namespace FolhaPonto.Domain.Interfaces
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks>> BuscarAll();
        Task<Tasks> BuscarId(Guid tasksId);
        void Post(TasksRequest request);
        Task<Tasks> Put(Guid tasksId, TasksRequest request);
        Task<Tasks> Delete(Guid tasksId);
    }
}
