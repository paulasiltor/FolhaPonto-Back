namespace FolhaPonto.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
