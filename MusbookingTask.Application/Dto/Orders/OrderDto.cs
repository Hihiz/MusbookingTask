using MusbookingTask.Application.Dto.OrderEquipments;

namespace MusbookingTask.Application.Dto.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderEquipmentCollectionDto> OrderEquipment { get; set; } = new List<OrderEquipmentCollectionDto>();
    }
}
