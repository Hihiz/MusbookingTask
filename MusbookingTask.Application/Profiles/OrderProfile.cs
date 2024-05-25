using AutoMapper;
using MusbookingTask.Application.Dto.Orders;
using MusbookingTask.Application.Orders.Commands.CreateOrder;
using MusbookingTask.Application.Orders.Commands.UpdateOrder;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
