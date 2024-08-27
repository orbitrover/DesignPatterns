using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.CreationalPatterns.FactoryMethod
{
    public abstract class PaymentProcessor
    {
        public abstract void ProcessPayment(decimal amount);
    }

    public class CreditCardProcessor : PaymentProcessor
    {
        public override void ProcessPayment(decimal amount)
        {
            // Implement credit card payment processing
            Console.WriteLine($"Processed credit card payment of {amount}");
        }
    }

    public class PayPalProcessor : PaymentProcessor
    {
        public override void ProcessPayment(decimal amount)
        {
            // Implement PayPal payment processing
            Console.WriteLine($"Processed PayPal payment of {amount}");
        }
    }

    public class PaymentProcessorFactory
    {
        public static PaymentProcessor GetPaymentProcessor(string type)
        {
            switch (type)
            {
                case "CreditCard":
                    return new CreditCardProcessor();
                case "PayPal":
                    return new PayPalProcessor();
                default:
                    throw new ArgumentException("Invalid payment processor type");
            }
        }
    }

}
