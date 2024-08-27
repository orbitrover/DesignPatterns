using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.StructuralPatterns.Composite
{
    public interface ICategoryComponent
    {
        void Display();
    }

    public class Category : ICategoryComponent
    {
        public string Name { get; set; }
        private readonly List<ICategoryComponent> _subCategories = new List<ICategoryComponent>();

        public void Add(ICategoryComponent category) => _subCategories.Add(category);
        public void Remove(ICategoryComponent category) => _subCategories.Remove(category);

        public void Display()
        {
            Console.WriteLine($"Category: {Name}");
            foreach (var subCategory in _subCategories)
            {
                subCategory.Display();
            }
        }
    }

}
