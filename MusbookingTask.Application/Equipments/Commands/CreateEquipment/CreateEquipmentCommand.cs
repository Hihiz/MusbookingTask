using MediatR;

namespace MusbookingTask.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
