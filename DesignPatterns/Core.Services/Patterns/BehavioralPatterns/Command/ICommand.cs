using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.Services.BehavioralPatterns.Command
{
    public interface ICommand
    {
        void Execute();
    }

    public class PlaceOrderCommand : ICommand
    {
        private readonly Order _order;

        public PlaceOrderCommand(Order order)
        {
            _order = order;
        }

        public void Execute()
        {
            // Logic to place the order
            Console.WriteLine($"Order {_order.Id} placed.");
        }
    }

    public class CancelOrderCommand : ICommand
    {
        private readonly Order _order;

        public CancelOrderCommand(Order order)
        {
            _order = order;
        }

        public void Execute()
        {
            // Logic to cancel the order
            Console.WriteLine($"Order {_order.Id} cancelled.");
        }
    }

}
