using Core.Services.CreationalPatterns.Singleton;
using Core.Services.CreationalPatterns.AbstractFactory;
using Core.Data.ViewModel;
using Core.Data;
using Core.Data.Enums;
using Core.Services.Interfaces;
using Core.Repo.Interface;
using Core.Services.BehavioralPatterns.Command;


namespace Core.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly LogService _logService;
        private readonly IOrderFactory _orderFactory;
        public OrderService(IOrderRepository repo, LogService logService, IOrderFactory orderFactory)
        {
            _repo = repo;
            _logService = logService;
            _orderFactory = orderFactory;
        }
        public void HandleOrder(Order order)
        {
            var orderProcessor = _orderFactory.CreateOrder();
            orderProcessor.ProcessOrder(order);  // Process the order using the appropriate order type

            var shippingProcessor = _orderFactory.CreateShipping();
            shippingProcessor.ShipOrder(order);  // Ship the order using the appropriate shipping type
        }
        public void PlaceOrder(OrderViewModel orderViewModel)
        {
            ICommand command = new PlaceOrderCommand(new Order());
            var id = _repo.PlaceOrder(orderViewModel);
            // Log the action
            _logService.Log($"Order {id} placed successfully.");
        }
        public void CancelOrder(OrderViewModel orderViewModel)
        {
            ICommand command = new CancelOrderCommand(new Order());
            var id = _repo.PlaceOrder(orderViewModel);
            // Log the action
            _logService.Log($"Order {id} placed successfully.");
        }
    }


}
