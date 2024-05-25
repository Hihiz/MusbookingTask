﻿namespace MusbookingTask.Domain.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderEquipment> OrderEquipments { get; set; }
    }
}
