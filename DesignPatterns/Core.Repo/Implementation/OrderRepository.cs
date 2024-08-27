using Core.Repo.Interface;
using Core.Repo.Data;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data.ViewModel;
using Core.Data.Enums;

namespace Core.Repo.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public int PlaceOrder(OrderViewModel orderViewModel)
        {
            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                TotalAmount = orderViewModel.TotalAmount,
                Items = orderViewModel.Items.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = _context.Products.Find(item.ProductId).Price
                }).ToList(),
                Status = OrderStatus.Created
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.Id;
        }
    }
}
