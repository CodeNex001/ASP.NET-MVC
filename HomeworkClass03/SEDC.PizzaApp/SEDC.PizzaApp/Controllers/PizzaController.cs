using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "List of pizzas";
            ViewData.Add("Message", $"The numbers of pizzas is: {StaticDb.Pizzas.Count}");
            ViewData["User"] = StaticDb.Users.First();
            List<Pizza> pizzas = StaticDb.Pizzas;
            List<PizzaViewModel> pizzaViewModels = new List<PizzaViewModel>();
            foreach (Pizza pizza in pizzas)
            {
                pizzaViewModels.Add(PizzaMapper.PizzaViewModel(pizza));
            }
            return View(pizzaViewModels); // returns ViewResult
        }

        public IActionResult JsonData()
        {
            Pizza pizza = new Pizza
            {
                Id = 1,
                Name = "Capri"
            };
            return new JsonResult(pizza); // returns JsonResult
        }

        public IActionResult BackToHome()
        {
            return RedirectToAction("Index", "Home"); //redirects to Action Index in Home Controller
        }

        public IActionResult Details(int? id) // localhost:port/Pizza/Details/1 or  localhost:port/Pizza/Details
        {
            ViewBag.Pizza = StaticDb.Pizzas.First();
            ViewBag.Title = "Pizza Details";
            if (id != null)
            {
                Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
                PizzaViewModel pizzaViewModel = PizzaMapper.PizzaViewModel(pizza);
                return View(pizzaViewModel);
            }
            return new EmptyResult();
        }
    }
}