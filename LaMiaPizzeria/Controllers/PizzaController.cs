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
    }

    public class FormController : Controller
    {
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
                PizzaModel newPizza = new PizzaModel();
                newPizza.Name = data.Name;
                newPizza.id = data.id;
                newPizza.ImgSource = data.ImgSource;
                newPizza.Description = data.Description;

                context.Pizze.Add(newPizza);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
