using AutoMapper;
using MediatR;
using MusbookingTask.Application.Common.Exceptions;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IBaseRepository<Equipment> _repositoryEquipment;
        private readonly IBaseRepository<OrderEquipment> _repositoryOrderEquipmen;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IBaseRepository<Order> repository, IBaseRepository<Equipment> repositoryEquipment,
            IBaseRepository<OrderEquipment> repositoryOrderEquipmen, IMapper mapper) =>
            (_repository, _repositoryEquipment, _repositoryOrderEquipmen, _mapper)
            = (repository, repositoryEquipment, repositoryOrderEquipmen, mapper);

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = new Order
                {
                    Description = request.Description,
                    CreatedAt = DateTime.UtcNow,
                    Price = request.Price,
                };

                await _repository.Create(order);
                await _repository.SaveChangesAsync(cancellationToken);

                Equipment equipment = await _repositoryEquipment.GetById(request.EquipmentId);

                if (equipment == null)
                {
                    throw new NotFoundException(nameof(Equipment), equipment.Id);
                }

                OrderEquipment eq = _mapper.Map<OrderEquipment>(request);
                eq.OrderId = order.Id;

                await _repositoryOrderEquipmen.Create(eq);
                await _repositoryOrderEquipmen.SaveChangesAsync(cancellationToken);

                return order.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new Exception();
            }
        }
    }
}
