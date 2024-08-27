﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        public bool IsOrdered { get; set; }
    }
}