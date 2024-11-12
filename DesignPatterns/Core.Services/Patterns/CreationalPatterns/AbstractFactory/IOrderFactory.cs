using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.CreationalPatterns.AbstractFactory
{
    /// <summary>
    /// Difference between Abstract Factory and Factory Patterns
    /// 1. Abstract factory pattern adds a layer of abstraction to the factory pattern
    /// 2. Abstract factory pattern implementation can have multiple factory methods
    /// 3. Similar products of a factory implementation are grouped in Abstract factory pattern
    /// 4. Abstract factory pattern uses object composition to decouple application from specific implementations
    /// 5. Factory Method uses inheritance to decouple applications from specific implementation
    /// </summary>
    public interface IOrderFactory
    {
        IOrder CreateOrder();
        IShipping CreateShipping();
    }

    public class StandardOrderFactory : IOrderFactory
    {
        public IOrder CreateOrder() => new StandardOrder();
        public IShipping CreateShipping() => new StandardShipping();
    }

    public class PremiumOrderFactory : IOrderFactory
    {
        public IOrder CreateOrder() => new PremiumOrder();
        public IShipping CreateShipping() => new ExpressShipping();
    }

    public interface IOrder
    {
        void ProcessOrder(Order order);
    }
    public class StandardOrder : IOrder
    {
        public void ProcessOrder(Order order)
        {
            // Implementation for processing a standard order
            Console.WriteLine($"Processing standard order with ID: {order.Id}");
            // Additional logic for processing standard orders can be added here
        }
    }
    public class PremiumOrder : IOrder
    {
        public void ProcessOrder(Order order)
        {
            // Implementation for processing a premium order
            Console.WriteLine($"Processing premium order with ID: {order.Id}");
            // Additional logic for processing premium orders can be added here
        }
    }

    public interface IShipping
    {
        void ShipOrder(Order order);
    }
    public class StandardShipping : IShipping
    {
        public void ShipOrder(Order order)
        {
            // Implementation for standard shipping
            Console.WriteLine($"Shipping standard order with ID: {order.Id}");
            // Additional logic for standard shipping can be added here
        }
    }
    public class ExpressShipping : IShipping
    {
        public void ShipOrder(Order order)
        {
            // Implementation for express shipping
            Console.WriteLine($"Express shipping order with ID: {order.Id}");
            // Additional logic for express shipping can be added here
        }
    }

}
