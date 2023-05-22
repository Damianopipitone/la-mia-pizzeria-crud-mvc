using LaMiaPizzeria.DataBase;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LaMiaPizzeria.Controllers
{
    [Authorize]
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
        [Authorize(Roles = "ADMIN,USER")]
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

        [HttpGet]
        [Authorize(Roles = "ADMIN,USER")]
        public IActionResult Update(int id)
        {
            using (PizzaContext context = new PizzaContext())
            {
                PizzaModel pizzeToEdit = context.Pizze.Where(pizze => pizze.id == id).FirstOrDefault();

                if (pizzeToEdit == null)
                {
                    return NotFound();
                } else
                {
                    return View(pizzeToEdit);
                }
            }

        }
    }

}
