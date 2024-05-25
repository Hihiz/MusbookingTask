using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;
using MusbookingTask.Infrastructure.Data;
using MusbookingTask.Infrastructure.Repositories;

namespace MusbookingTask.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemory");
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.RepositoriesInit();

            return services;
        }

        public static void RepositoriesInit(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Order>, OrderRepository>();
            services.AddScoped<IBaseRepository<Equipment>, EquipmentRepository>();
            services.AddScoped<IBaseRepository<OrderEquipment>, OrderEquipmentRepository>();
        }
    }
}
