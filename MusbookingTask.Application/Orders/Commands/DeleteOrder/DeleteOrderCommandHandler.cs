using MediatR;
using MusbookingTask.Application.Common.Exceptions;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IBaseRepository<OrderEquipment> _repositoryOrderEquipmen;
        private readonly IBaseRepository<Equipment> _repositoryEquipment;

        public DeleteOrderCommandHandler(IBaseRepository<Order> repository, IBaseRepository<OrderEquipment> repositoryOrderEquipmen, IBaseRepository<Equipment> repositoryEquipment) =>
            (_repository, _repositoryOrderEquipmen, _repositoryEquipment) = (repository, repositoryOrderEquipmen, repositoryEquipment);

        public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = await _repository.GetById(request.Id, cancellationToken);

                if (order == null)
                {
                    throw new NotFoundException(nameof(Order), request.Id);
                }

                List<OrderEquipment> orderEquipments = await _repositoryOrderEquipmen.GetAll(cancellationToken);

                foreach (OrderEquipment i in orderEquipments)
                {
                    if (i.OrderId == order.Id)
                    {
                        i.Equipment.Amount += i.Quantity;

                        await _repositoryEquipment.Update(i.Equipment, cancellationToken);

                        _repositoryOrderEquipmen.Delete(i);
                    }

                }

                _repository.Attach(order);
                _repository.Delete(order);

                await _repository.SaveChangesAsync(cancellationToken);

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
