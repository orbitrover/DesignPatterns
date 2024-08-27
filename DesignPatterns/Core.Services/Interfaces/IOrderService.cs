using Core.Data;
using Core.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IOrderService
    {
        void HandleOrder(Order order);
        void PlaceOrder(OrderViewModel orderViewModel);
    }
}
