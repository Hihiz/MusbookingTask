namespace MusbookingTask.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderEquipment> OrderEquipments { get; set; } = new List<OrderEquipment>();
 
    }
}
