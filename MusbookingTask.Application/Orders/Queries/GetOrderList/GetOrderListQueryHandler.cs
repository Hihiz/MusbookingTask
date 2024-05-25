using AutoMapper;
using MediatR;
using MusbookingTask.Application.Dto.OrderEquipments;
using MusbookingTask.Application.Dto.Orders;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderDto>>
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IBaseRepository<Order> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<List<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Order> orders = await _repository.GetAll(cancellationToken);

                List<OrderDto> ordersDto = orders.Select(x => new OrderDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Price = x.Price,
                    OrderEquipment = x.OrderEquipments.Select(y => new OrderEquipmentCollectionDto
                    {
                        OrderId = y.OrderId,
                        EquipmentName = y.Equipment.Name,
                        Quantity = y.Quantity
                    }).ToList(),
                }).ToList();

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
