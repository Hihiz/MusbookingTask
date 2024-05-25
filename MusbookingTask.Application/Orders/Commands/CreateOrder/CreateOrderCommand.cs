using MediatR;

namespace MusbookingTask.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }

        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
    }
}
