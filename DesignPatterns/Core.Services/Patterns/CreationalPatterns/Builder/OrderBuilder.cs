using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.Services.CreationalPatterns.Builder
{
    public class BuildreService
    {
        public BuildreService() { }
        public void CreateOrderBuilder()
        {
            OrderBuilder builder = new OrderBuilder();
            var item = new OrderItem();
            var result1 = builder.AddProduct(item).SetCustomer("123456").SetShippingAddress("").Build();
            
        }
    }
    /// <summary>
    /// According to GOF, the Builder Design Pattern builds a complex object using many simple objects and a step-by-step approach. 
    /// The Process of constructing the complex object should be so generic that the same construction process can be used to create different representations of the same complex object.
    /// </summary>
    public interface IOrderBuilder
    {
        public OrderBuilder AddProduct(OrderItem product);
        public OrderBuilder SetCustomer(string customerId);
        public OrderBuilder SetShippingAddress(string address);
        public OrderBuilder SetBillingAddress(string address);
        public OrderBuilder AsGift(string giftMessage);
        public OrderBuilder CalculateTotal();
        public Order Build();
    }
    /// <summary>
    /// So, the Builder Design Pattern is about separating the construction process of a complex object from its representation, allowing the same construction process to create different representations. 
    /// When the construction process of the object is very complex, we only need to use the Builder Design Pattern.
    /// </summary>
    public class OrderBuilder : IOrderBuilder
    {
        private Order _order = new Order();

        public OrderBuilder AddProduct(OrderItem product)
        {
            _order.Items.Add(product);
            return this;
        }
        public OrderBuilder SetCustomer(string customerId)
        {
            _order.CustomerId = customerId;
            return this;
        }

        public OrderBuilder SetShippingAddress(string address)
        {
            _order.ShippingAddress = address;
            return this;
        }
        public OrderBuilder SetBillingAddress(string address)
        {
            _order.BillingAddress = address;
            return this;
        }
        public OrderBuilder AsGift(string giftMessage)
        {
            _order.SetGiftOption(true, giftMessage);
            return this;
        }

        public OrderBuilder CalculateTotal()
        {
            _order.CalculateTotal();
            return this;
        }
        public Order Build()
        {
            // Add any final steps needed before returning the built order.
            return _order;
        }
    }

}
