﻿using System.ComponentModel.DataAnnotations;

namespace Core.Data
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double TaxPercentage { get; set; }
        public double Cost { get; set; }
        public decimal Price { get; set; }
        public bool IsOrdered { get; set; }
    }
}
