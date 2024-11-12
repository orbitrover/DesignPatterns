using Core.Data;
using Core.Data.ViewModel;
using Core.Repo.Interface;
using Core.Services.BehavioralPatterns.Command;
using Core.Services.CreationalPatterns.AbstractFactory;
using Core.Services.CreationalPatterns.Builder;
using Core.Services.CreationalPatterns.FactoryMethod;
using Core.Services.CreationalPatterns.Singleton;
using Core.Services.Interfaces;


namespace Core.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly LogService _logService;
        private readonly IOrderFactory _orderFactory;
        private readonly IPaymentProcessorFactory _paymentProcessorFactory;
        public OrderService(IOrderRepository repo, LogService logService, IOrderFactory orderFactory, IPaymentProcessorFactory paymentProcessorFactory)
        {
            _repo = repo;
            _logService = logService;
            _orderFactory = orderFactory;
            _paymentProcessorFactory = paymentProcessorFactory;
        }
        public void HandleOrder(Order order, string paymentType = "CreditCard")
        {
            IOrderBuilder builder = new OrderBuilder();
            order = builder
            .AddProduct(new OrderItem { Id= 1, ProductId= 1, Cost= 1000.00, Price=999.00m, Quantity = 1, TaxPercentage=25 })
            .AddProduct(new OrderItem { Id = 2, ProductId = 2, Cost = 1200.00, Price = 1199.00m, Quantity = 1, TaxPercentage = 25 })
            .SetShippingAddress("123 Main St, Anytown, USA")
            .SetBillingAddress("456 Elm St, Othertown, USA")
            .AsGift("Happy Birthday!")
            .CalculateTotal()
            .Build();
            var orderProcessor = _orderFactory.CreateOrder();
            orderProcessor.ProcessOrder(order);  // Process the order using the appropriate order type

            var shippingProcessor = _orderFactory.CreateShipping();
            shippingProcessor.ShipOrder(order);  // Ship the order using the appropriate shipping type

            var paymentProcessor = _paymentProcessorFactory.CreatePaymentProcessor(paymentType);
            paymentProcessor.ProcessPayment(order);  // Process payment for the order
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
