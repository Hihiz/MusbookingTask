using Microsoft.EntityFrameworkCore;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<OrderEquipment> OrderEquipments { get; set; }
    }
}
