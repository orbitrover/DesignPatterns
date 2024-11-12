using Core.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Data
{
    public interface IOrderState
    {
        void Handle(Order order);
    }
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public bool IsGift { get; private set; }
        public string GiftMessage { get; private set; }
        public void SetState(IOrderState state)
        {
            state.Handle(this);
        }
        public void CalculateTotal()
        {
            TotalAmount = Items.Sum(item => item.Price * item.Quantity);
        }

        public void SetGiftOption(bool isGift, string giftMessage = "")
        {
            IsGift = isGift;
            GiftMessage = giftMessage;
        }
    }
}
