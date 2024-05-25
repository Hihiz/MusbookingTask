using MediatR;

namespace MusbookingTask.Application.Equipments.Commands.DeleteEquipment
{
    public class DeleteEquipmentCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteEquipmentCommand(int id) => Id = id;
    }
}
