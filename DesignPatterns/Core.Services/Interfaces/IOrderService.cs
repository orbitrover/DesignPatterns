using Core.Data;
using Core.Data.ViewModel;

namespace Core.Services.Interfaces
{
    public interface IOrderService
    {
        void HandleOrder(Order order, string paymentType = "CreditCard");
        void PlaceOrder(OrderViewModel orderViewModel);
    }
}
