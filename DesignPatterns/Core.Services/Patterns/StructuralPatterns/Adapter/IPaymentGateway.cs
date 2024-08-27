using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.StructuralPatterns.Adapter
{
    public interface IPaymentGateway
    {
        void MakePayment(decimal amount);
    }

    public class ThirdPartyPaymentService
    {
        public void Pay(decimal amount)
        {
            // Payment processing
            Console.WriteLine($"Paid {amount} using third-party service");
        }
    }

    public class PaymentGatewayAdapter : IPaymentGateway
    {
        private readonly ThirdPartyPaymentService _thirdPartyPaymentService;

        public PaymentGatewayAdapter(ThirdPartyPaymentService thirdPartyPaymentService)
        {
            _thirdPartyPaymentService = thirdPartyPaymentService;
        }

        public void MakePayment(decimal amount)
        {
            _thirdPartyPaymentService.Pay(amount);
        }
    }

}
