using AutoMapper;
using MusbookingTask.Application.Orders.Commands.CreateOrder;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Profiles
{
    public class OrderEquipmentProfile : Profile
    {
        public OrderEquipmentProfile()
        {
            CreateMap<OrderEquipment, CreateOrderCommand>().ReverseMap();
        }
    }
}
