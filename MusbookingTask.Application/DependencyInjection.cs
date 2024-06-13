using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MusbookingTask.Application.Equipments.Commands.CreateEquipment;
using MusbookingTask.Application.Equipments.Commands.UpdateEquipment;
using MusbookingTask.Application.Orders.Commands.CreateOrder;
using MusbookingTask.Application.Orders.Commands.UpdateOrder;
using System.Reflection;

namespace MusbookingTask.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

          

            return services;
        }

        private static void FluentValidatorInit(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateEquipmentCommand>, CreateEquipmentCommandValidator>();
            services.AddScoped<IValidator<UpdateEquipmentCommand>, UpdateEquipmentCommandValidator>();

            services.AddScoped<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();
            services.AddScoped<IValidator<UpdateOrderCommand>, UpdateOrderCommandValidator>();
        }
    }
}
