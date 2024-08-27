using Core.Data.ViewModel;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repo.Interface
{
    public interface IOrderRepository
    {
        //void HandleOrder(Order order);
        int PlaceOrder(OrderViewModel orderViewModel);
    }
}
