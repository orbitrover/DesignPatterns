using Microsoft.AspNetCore.Mvc;

namespace Core.DesignPatternsWeb.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
