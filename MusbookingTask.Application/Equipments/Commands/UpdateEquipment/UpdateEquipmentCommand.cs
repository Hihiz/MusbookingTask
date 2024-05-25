using MediatR;

namespace MusbookingTask.Application.Equipments.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
