using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.Services.BehavioralPatterns.Strategy
{
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(Order order);
    }

    public class StandardShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(Order order)
        {
            return 10; // Flat rate
        }
    }

    public class ExpressShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(Order order)
        {
            return 25; // Flat rate for express shipping
        }
    }

}
