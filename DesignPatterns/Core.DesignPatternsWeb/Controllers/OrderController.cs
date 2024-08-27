using Microsoft.AspNetCore.Mvc;

namespace Core.DesignPatternsWeb.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
