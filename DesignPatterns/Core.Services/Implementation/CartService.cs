using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.Services.Implementation
{
    internal class CartService : ICartService
    {
        public CartService() { }
        public int AddItemToCart(int itemID, int Quantity)
        {
            Console.WriteLine("\t SubSystem Cart : AddItemToCart");
            return 15;
        }
        public bool CheckItemAvailability(Product product)
        {
            Console.WriteLine("\t SubSystem Cart : CheckItemAvailability");
            return true;
        }

        public double GetCartPrice(int cartID)
        {
            Console.WriteLine("\t SubSystem Cart : GetCartPrice");
            return 15;
        }
        public Product GetItemDetails(int itemID)
        {
            Console.WriteLine("\t SubSystem Cart : GetItemDetails");
            return new Product();
        }
        public bool LockItemInStock(int itemID, int quantity)
        {
            Console.WriteLine("\t SubSystem Cart : LockItemInStock");
            return true;
        }
    }
}
