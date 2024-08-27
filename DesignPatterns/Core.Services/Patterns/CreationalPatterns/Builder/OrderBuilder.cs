using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.Services.CreationalPatterns.Builder
{
    public class OrderBuilder
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

        public Order Build()
        {
            return _order;
        }
    }

}
