using MediatR;

namespace MusbookingTask.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal Price { get; set; }

        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
    }
}
