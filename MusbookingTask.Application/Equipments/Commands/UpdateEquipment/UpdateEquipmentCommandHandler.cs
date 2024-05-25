using AutoMapper;
using MediatR;
using MusbookingTask.Application.Common.Exceptions;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Equipments.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand, int>
    {
        private readonly IBaseRepository<Equipment> _repository;
        private readonly IMapper _mapper;

        public UpdateEquipmentCommandHandler(IBaseRepository<Equipment> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<int> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Equipment equipment = _mapper.Map<Equipment>(request);

                if (equipment == null || equipment.Id != request.Id)
                {
                    throw new NotFoundException(nameof(Equipment), request.Id);
                }

                _repository.Update(equipment);
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
