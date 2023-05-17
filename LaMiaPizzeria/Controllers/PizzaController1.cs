using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
