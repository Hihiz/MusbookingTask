namespace MusbookingTask.Application.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll(CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        Task Attach(T entity, CancellationToken cancellationToken = default);
    }
}
