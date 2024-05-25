namespace MusbookingTask.Application.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll(CancellationToken cancellationToken = default);
        Task<T> GetById(int id, CancellationToken cancellationToken = default);
        Task<T> Create(T entity, CancellationToken cancellationToken = default);
        Task<T> Update(T entity, CancellationToken cancellation = default);
        Task Delete(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        Task Attach(T entity, CancellationToken cancellationToken = default);
    }
}
