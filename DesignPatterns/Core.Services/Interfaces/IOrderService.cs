using Core.Data;
using Core.Data.ViewModel;

namespace Core.Services.Interfaces
{
    public interface IOrderService
    {
        void HandleOrder(Order order);
        void PlaceOrder(OrderViewModel orderViewModel);
    }
}
