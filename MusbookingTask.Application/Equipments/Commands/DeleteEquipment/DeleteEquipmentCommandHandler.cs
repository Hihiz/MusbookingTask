using MediatR;
using MusbookingTask.Application.Common.Exceptions;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Equipments.Commands.DeleteEquipment
{
    public class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand, int>
    {
        private readonly IBaseRepository<Equipment> _repository;

        public DeleteEquipmentCommandHandler(IBaseRepository<Equipment> repository) => (_repository) = (repository);

        public async Task<int> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Equipment equipment = await _repository.GetById(request.Id, cancellationToken);

                if (equipment == null)
                {
                    throw new NotFoundException(nameof(Equipment), request.Id);
                }

                _repository.Delete(equipment);
                await _repository.SaveChangesAsync(cancellationToken);

                return equipment.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new Exception();
            }
        }
    }
}
