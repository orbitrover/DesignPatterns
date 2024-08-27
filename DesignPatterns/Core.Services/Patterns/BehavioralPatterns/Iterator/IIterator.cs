using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.Services.BehavioralPatterns.Iterator
{
    public interface IIterator
    {
        bool HasNext();
        Product Next();
    }

    public class ProductIterator : IIterator
    {
        private readonly List<Product> _products;
        private int _position = 0;

        public ProductIterator(List<Product> products)
        {
            _products = products;
        }

        public bool HasNext() => _position < _products.Count;

        public Product Next() => _products[_position++];
    }

}
