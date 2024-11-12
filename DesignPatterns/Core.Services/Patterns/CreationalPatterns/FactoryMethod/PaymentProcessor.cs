using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.CreationalPatterns.FactoryMethod
{
    #region FactoryMethod_Example1
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
    #endregion;

    #region FactoryMethod_Example2
    public interface IPaymentProcessor
    {
        void ProcessPayment(Order order);
    }
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(Order order)
        {
            // Implementation for processing credit card payment
            Console.WriteLine($"Processing credit card payment for order ID: {order.Id}");
            // Add logic for handling credit card transactions here
        }
    }
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(Order order)
        {
            // Implementation for processing PayPal payment
            Console.WriteLine($"Processing PayPal payment for order ID: {order.Id}");
            // Add logic for handling PayPal transactions here
        }
    }
    public interface IPaymentProcessorFactory
    {
        IPaymentProcessor CreatePaymentProcessor(string type);
    }
    //public class CreditCardPaymentProcessorFactory : IPaymentProcessorFactory
    //{
    //    public IPaymentProcessor CreatePaymentProcessor()
    //    {
    //        return new CreditCardPaymentProcessor();
    //    }
    //}
    //public class PayPalPaymentProcessorFactory : IPaymentProcessorFactory
    //{
    //    public IPaymentProcessor CreatePaymentProcessor()
    //    {
    //        return new PayPalPaymentProcessor();
    //    }
    //}
    public class OrderPaymentProcessorFactory : IPaymentProcessorFactory
    {
        public IPaymentProcessor CreatePaymentProcessor(string type)
        {
            switch (type)
            {
                case "CreditCard":
                    return new CreditCardPaymentProcessor();
                case "PayPal":
                    return new PayPalPaymentProcessor();
                default:
                    throw new ArgumentException("Invalid payment processor type");
            }
        }
    }
    #endregion;
}
