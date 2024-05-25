using AutoMapper;
using MediatR;
using MusbookingTask.Application.Common.Exceptions;
using MusbookingTask.Application.Dto.Equipments;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Equipments.Queries.GetEquipmentDetail
{
    public class GetEquipmentDetailQueryHandler : IRequestHandler<GetEquipmentDetailQuery, EquipmentDto>
    {
        private readonly IBaseRepository<Equipment> _repository;
        private readonly IMapper _mapper;

        public GetEquipmentDetailQueryHandler(IBaseRepository<Equipment> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<EquipmentDto> Handle(GetEquipmentDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Equipment equipment = await _repository.GetById(request.Id, cancellationToken);

                if (equipment == null)
                {
                    throw new NotFoundException(nameof(Equipment), request.Id);
                }

                return _mapper.Map<EquipmentDto>(equipment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new Exception();
            }
        }
    }
}
