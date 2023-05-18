using LaMiaPizzeria.DataBase;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {   
            using (PizzaContext db = new PizzaContext())
            {
                List<PizzaModel> pizze = db.Pizze.ToList();
                
                return View(pizze);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            using (PizzaContext context = new PizzaContext())
            {
                

                context.Pizze.Add(data);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }

}
