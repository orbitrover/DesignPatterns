﻿using System.ComponentModel.DataAnnotations;

namespace Core.Data
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double TaxPercentage { get; set; }
        public double Cost { get; set; }
        public decimal Price { get; set; }
    }
}
