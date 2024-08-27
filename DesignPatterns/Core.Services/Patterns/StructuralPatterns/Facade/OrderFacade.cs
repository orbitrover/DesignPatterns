using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using Core.Services.Implementation;

namespace Core.Services.StructuralPatterns.Facade
{
    public class OrderFacade
    {
        private readonly OrderService _orderService;
        private readonly PaymentService _paymentService;
        private readonly AddressService _shippingService;

        public OrderFacade()
        {
            //_orderService = new OrderService(null,null,null);
            //_paymentService = new PaymentService();
            //_shippingService = new AddressService();
        }

        public void PlaceOrder(Order order, PaymentDetails paymentDetails)
        {
            //_orderService.ProcessOrder(order);
            //_paymentService.ProcessPayment(paymentDetails);
            //_shippingService.ShipOrder(order);
        }
    }

}
