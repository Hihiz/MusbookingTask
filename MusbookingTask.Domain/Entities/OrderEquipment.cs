namespace MusbookingTask.Domain.Entities
{
    public class OrderEquipment
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }


        public int Quantity { get; set; }
    }
}
