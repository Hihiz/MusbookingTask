using AutoMapper;
using MediatR;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, int>
    {
        private readonly IBaseRepository<Equipment> _repository;
        private readonly IMapper _mapper;

        public CreateEquipmentCommandHandler(IBaseRepository<Equipment> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<int> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Equipment equipment = _mapper.Map<Equipment>(request);

                await _repository.Create(equipment, cancellationToken);
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
