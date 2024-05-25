using MediatR;
using MusbookingTask.Application.Dto.Equipments;

namespace MusbookingTask.Application.Equipments.Queries.GetEquipmentList
{
    public class GetEquipmentListQuery : IRequest<List<EquipmentDto>>
    {

    }
}
