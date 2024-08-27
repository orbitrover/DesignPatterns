using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.ViewModel
{
    public class OrderViewModel
    {
        public List<OrderItemViewModel> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
