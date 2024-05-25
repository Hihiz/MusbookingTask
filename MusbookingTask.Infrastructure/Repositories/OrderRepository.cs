using Microsoft.EntityFrameworkCore;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;
using MusbookingTask.Infrastructure.Data;

namespace MusbookingTask.Infrastructure.Repositories
{
    public class OrderRepository : IBaseRepository<Order>
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<Order>> GetAll(CancellationToken cancellationToken = default) => await _db.Orders
                                                                                                    .AsNoTracking()
                                                                                                    .Include(o => o.OrderEquipments).ThenInclude(o => o.Equipment)
                                                                                                    .OrderBy(o => o.CreatedAt)
                                                                                                    .ToListAsync(cancellationToken);

        public async Task<Order> GetById(int id, CancellationToken cancellationToken = default) => await _db.Orders
                                                                                                        .AsNoTracking()
                                                                                                        .Include(o => o.OrderEquipments).ThenInclude(o => o.Equipment)
                                                                                                        .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        public async Task<Order> Create(Order entity, CancellationToken cancellation = default)
        {
            await _db.Orders.AddAsync(entity, cancellation);

            return entity;
        }
        public async Task<Order> Update(Order entity, CancellationToken cancellation = default)
        {
            _db.Orders.Update(entity);

            return entity;
        }

        public async Task Delete(Order entity)
        {
            _db.Orders.Remove(entity);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);

        public async Task Attach(Order entity, CancellationToken cancellationToken = default)
        {
            _db.Attach(entity);
        }
    }
}
