using AutoMapper;
using MediatR;
using MusbookingTask.Application.Common.Exceptions;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IBaseRepository<Order> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = await _repository.GetById(request.Id);

                if (order == null || order.Id != request.Id)
                {
                    throw new NotFoundException(nameof(Order), request.Id);
                }

                Order update = _mapper.Map<Order>(request);
                update.CreatedAt = order.CreatedAt;

                update.UpdatedAt = DateTime.UtcNow;

                await _repository.Update(update, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                return update.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new Exception();
            }
        }
    }
}
