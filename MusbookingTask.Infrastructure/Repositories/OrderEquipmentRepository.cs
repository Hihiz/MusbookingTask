using Microsoft.EntityFrameworkCore;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;
using MusbookingTask.Infrastructure.Data;

namespace MusbookingTask.Infrastructure.Repositories
{
    public class OrderEquipmentRepository : IBaseRepository<OrderEquipment>
    {
        private readonly ApplicationDbContext _db;

        public OrderEquipmentRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<OrderEquipment>> GetAll(CancellationToken cancellationToken = default) => await _db.OrderEquipments
                                                                                                .AsNoTracking()
                                                                                                .Include(o => o.Order)
                                                                                                .Include(o => o.Equipment)
                                                                                                .ToListAsync(cancellationToken);

        public async Task<OrderEquipment> GetById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderEquipment> Create(OrderEquipment entity, CancellationToken cancellationToken = default)
        {
            await _db.AddAsync(entity, cancellationToken);

            await _db.Entry(entity).Reference(o => o.Order).LoadAsync(cancellationToken);
            await _db.Entry(entity).Reference(o => o.Equipment).LoadAsync(cancellationToken);

            return entity;
        }

        public async Task<OrderEquipment> Update(OrderEquipment entity, CancellationToken cancellationToken = default)
        {
            _db.Update(entity);

            await _db.Entry(entity).Reference(o => o.Order).LoadAsync(cancellationToken);
            await _db.Entry(entity).Reference(o => o.Equipment).LoadAsync(cancellationToken);

            return entity;
        }

        public async Task Delete(OrderEquipment entity) => _db.OrderEquipments.Remove(entity);


        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);

        public Task Attach(OrderEquipment entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
