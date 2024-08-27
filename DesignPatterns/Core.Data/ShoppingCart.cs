using System.ComponentModel.DataAnnotations;

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
