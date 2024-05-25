using AutoMapper;
using MediatR;
using MusbookingTask.Application.Common.Exceptions;
using MusbookingTask.Application.Dto.OrderEquipments;
using MusbookingTask.Application.Dto.Orders;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDto>
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IBaseRepository<Order> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<OrderDto> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = await _repository.GetById(request.Id, cancellationToken);

                if (order == null)
                {
                    throw new NotFoundException(nameof(Order), request.Id);
                }

                OrderDto ordersDto = new OrderDto
                {
                    Id = order.Id,
                    Description = order.Description,
                    CreatedAt = order.CreatedAt,
                    UpdatedAt = order.UpdatedAt,
                    Price = order.Price,
                    OrderEquipment = order.OrderEquipments.Select(y => new OrderEquipmentCollectionDto
                    {
                        OrderId = y.OrderId,
                        EquipmentName = y.Equipment.Name,
                        Quantity = y.Quantity
                    }).ToList(),
                };

                return ordersDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new Exception();
            }
        }
    }
}
