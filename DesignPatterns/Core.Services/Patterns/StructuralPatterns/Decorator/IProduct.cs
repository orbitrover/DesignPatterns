using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.StructuralPatterns.Decorator
{
    public interface IProduct
    {
        string GetDescription();
        decimal GetPrice();
    }

    public class BasicProduct : IProduct
    {
        public string GetDescription() => "Basic Product";
        public decimal GetPrice() => 50;
    }

    public class GiftWrapDecorator : IProduct
    {
        private readonly IProduct _product;

        public GiftWrapDecorator(IProduct product)
        {
            _product = product;
        }

        public string GetDescription() => _product.GetDescription() + ", Gift Wrapped";
        public decimal GetPrice() => _product.GetPrice() + 5;
    }

}
