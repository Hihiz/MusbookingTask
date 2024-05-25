using AutoMapper;
using MediatR;
using MusbookingTask.Application.Dto.Equipments;
using MusbookingTask.Application.Interfaces;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Equipments.Queries.GetEquipmentList
{
    public class GetEquipmentListQueryHandler : IRequestHandler<GetEquipmentListQuery, List<EquipmentDto>>
    {
        private readonly IBaseRepository<Equipment> _repository;
        private readonly IMapper _mapper;

        public GetEquipmentListQueryHandler(IBaseRepository<Equipment> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<List<EquipmentDto>> Handle(GetEquipmentListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Equipment> equipments = await _repository.GetAll(cancellationToken);

                return _mapper.Map<List<EquipmentDto>>(equipments);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new Exception();
            }
        }
    }
}
