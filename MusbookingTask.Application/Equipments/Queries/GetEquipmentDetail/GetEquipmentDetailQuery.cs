using MediatR;
using MusbookingTask.Application.Dto.Equipments;

namespace MusbookingTask.Application.Equipments.Queries.GetEquipmentDetail
{
    public class GetEquipmentDetailQuery : IRequest<EquipmentDto>
    {
        public int Id { get; set; }

        public GetEquipmentDetailQuery(int id) => Id = id;
    }
}
