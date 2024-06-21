using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.RealTimeExamplesofIteratorDesignPattern
{
    /// <summary>
    /// Client Code
    /// </summary>
    public static class RestaurantMenu
    {
        public static void Run()
        {
            var breakfastMenu = new Menu();
            breakfastMenu.AddItem(new MenuItem { Name = "Idli", Price = 5.99 });
            breakfastMenu.AddItem(new MenuItem { Name = "Dosa", Price = 6.99 });
            var lunchMenu = new Menu();
            lunchMenu.AddItem(new MenuItem { Name = "Burger", Price = 17.49 });
            lunchMenu.AddItem(new MenuItem { Name = "Salad", Price = 14.99 });
            var menus = new List<Menu> { breakfastMenu, lunchMenu };
            foreach (var menu in menus)
            {
                var iterator = menu.CreateIterator();
                while (iterator.HasNext())
                {
                    var item = iterator.Next();
                    Console.WriteLine($"Item: {item.Name}, Price: ${item.Price}");
                }
            }

        }
    }
    //Define the MenuItem
    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    
    //Implement the Menus
    public class Menu : INextAggregate<MenuItem>
    {
        private List<MenuItem> _items = new List<MenuItem>();
        public void AddItem(MenuItem item)
        {
            _items.Add(item);
        }
        public INextIterator<MenuItem> CreateIterator()
        {
            return new MenuIterator(this);
        }
        private class MenuIterator : INextIterator<MenuItem>
        {
            private Menu _menu;
            private int _currentIndex = 0;
            public MenuIterator(Menu menu)
            {
                _menu = menu;
            }
            public bool HasNext()
            {
                return _currentIndex < _menu._items.Count;
            }
            public MenuItem Next()
            {
                return _menu._items[_currentIndex++];
            }
        }
    }
}
