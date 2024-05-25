using Microsoft.EntityFrameworkCore;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;
using MusbookingTask.Infrastructure.Data;

namespace MusbookingTask.Infrastructure.Repositories
{
    public class EquipmentRepository : IBaseRepository<Equipment>
    {
        private readonly ApplicationDbContext _db;

        public EquipmentRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<Equipment>> GetAll(CancellationToken cancellationToken = default) => await _db.Equipments.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Equipment> GetById(int id, CancellationToken cancellationToken = default) => await _db.Equipments.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        public async Task<Equipment> Create(Equipment entity, CancellationToken cancellation = default)
        {
            await _db.Equipments.AddAsync(entity, cancellation);

            return entity;
        }

        public async Task<Equipment> Update(Equipment entity, CancellationToken cancellationToken = default)
        {
            _db.Equipments.Update(entity);

            return entity;
        }
        public async Task Delete(Equipment entity) => _db.Equipments.Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);

        public Task Attach(Equipment entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
