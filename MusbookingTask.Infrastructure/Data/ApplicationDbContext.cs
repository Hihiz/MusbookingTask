using Microsoft.EntityFrameworkCore;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<OrderEquipment> OrderEquipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEquipment>()
                .HasKey(oe => new { oe.OrderId, oe.EquipmentId });

            modelBuilder.Entity<OrderEquipment>()
                .HasOne(oe => oe.Order)
                .WithMany(o => o.OrderEquipments)
                .HasForeignKey(oe => oe.OrderId);

            modelBuilder.Entity<OrderEquipment>()
                .HasOne(oe => oe.Equipment)
                .WithMany(e => e.OrderEquipments)
                .HasForeignKey(oe => oe.EquipmentId);
        }
    }
}
