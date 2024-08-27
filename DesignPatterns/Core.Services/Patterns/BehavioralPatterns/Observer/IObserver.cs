using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.Services.BehavioralPatterns.Observer
{
    public interface IObserver
    {
        void Update(Order order);
    }

    public class InventoryObserver : IObserver
    {
        public void Update(Order order)
        {
            // Update inventory
            Console.WriteLine("Inventory updated for order: " + order.Id);
        }
    }

    public class EmailNotificationObserver : IObserver
    {
        public void Update(Order order)
        {
            // Send email notification
            Console.WriteLine("Email sent for order: " + order.Id);
        }
    }

    public class OrderSubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers.Remove(observer);

        public void Notify(Order order)
        {
            foreach (var observer in _observers)
            {
                observer.Update(order);
            }
        }
    }

}
