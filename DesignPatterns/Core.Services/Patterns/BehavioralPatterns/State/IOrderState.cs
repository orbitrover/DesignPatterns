using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using Core.Data.Enums;

namespace Core.Services.BehavioralPatterns.State
{
    //public interface IOrderState
    //{
    //    void Handle(Order order);
    //}

    public class OrderCreatedState : IOrderState
    {
        public void Handle(Order order)
        {
            // Handle created state
            Console.WriteLine($"Order {order.Id} is in created state.");
            order.SetState(new OrderPaidState());
        }
    }

    public class OrderPaidState : IOrderState
    {
        public void Handle(Order order)
        {
            // Handle paid state
            Console.WriteLine($"Order {order.Id} is paid.");
            order.SetState(new OrderShippedState());
        }
    }

    public class OrderShippedState : IOrderState
    {
        public void Handle(Order order)
        {
            // Handle shipped state
            Console.WriteLine($"Order {order.Id} is shipped.");
            order.SetState(new OrderDeliveredState());
        }
    }
    public class OrderDeliveredState : IOrderState
    {
        public void Handle(Order order)
        {
            // Handle delivered state
            Console.WriteLine($"Order {order.Id} is delivered.");
            // No further state transition if delivered is the final state
        }
    }
}
