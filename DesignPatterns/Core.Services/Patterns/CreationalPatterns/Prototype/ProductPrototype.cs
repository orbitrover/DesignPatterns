using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.CreationalPatterns.Prototype
{
    public abstract class ProductPrototype
    {
        public abstract ProductPrototype Clone();
    }

    public class Product : ProductPrototype
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override ProductPrototype Clone()
        {
            return (ProductPrototype)this.MemberwiseClone();
        }
    }

}
