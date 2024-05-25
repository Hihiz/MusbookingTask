using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Infrastructure.Data
{
    public static class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (db.Orders.Any())
                {
                    return;
                }

                List<Order> orders = new List<Order>()
                {
                    new Order
                    {
                        Id = 1,
                      Description = "Order1",
                      CreatedAt = DateTime.Now,
                      UpdatedAt = null,
                      Price = 1000,
                    },
                    new Order
                    {
                       Id = 2,
                      Description = "Order1",
                      CreatedAt = DateTime.Now,
                      UpdatedAt = null,
                      Price = 1000,
                    },
                    new Order
                    {
                       Id = 3,
                      Description = "Order1",
                      CreatedAt = DateTime.Now,
                      UpdatedAt = null,
                      Price = 1000,
                    }
                };

                await db.Orders.AddRangeAsync(orders);

                if (db.Equipments.Any())
                {
                    return;
                }

                List<Equipment> equipments = new List<Equipment>()
                {
                    new Equipment
                    {
                         Id = 1,
                       Name = "Микшерный пульт с процессором эффектов",
                       Amount = 2,
                       Price = 3000,
                    },
                    new Equipment
                    {
                           Id = 2,
                       Name = "Мониторная система",
                       Amount = 10,
                       Price = 1500,
                    },
                    new Equipment
                    {
                          Id = 3,
                       Name = "Микрофон",
                       Amount = 2,
                       Price = 2000,
                    }
                };

                await db.Equipments.AddRangeAsync(equipments);


                if (db.OrderEquipments.Any())
                {
                    return;
                }

                await db.OrderEquipments.AddRangeAsync(
                    new OrderEquipment
                    {
                        OrderId = orders[0].Id,
                        EquipmentId = equipments[0].Id,
                        Quantity = 1
                    },
                      new OrderEquipment
                      {
                          OrderId = orders[1].Id,
                          EquipmentId = equipments[1].Id,
                          Quantity = 2
                      },
                        new OrderEquipment
                        {
                            OrderId = orders[2].Id,
                            EquipmentId = equipments[2].Id,
                            Quantity = 3
                        }
                    );

                await db.SaveChangesAsync(new CancellationToken());
            }
        }
    }
}
