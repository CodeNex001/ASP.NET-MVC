using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JsonData()
        {
            Pizza pizza = new Pizza
            {
                id = 1,
                Name = "Vegetarianska"
            };

            return new JsonResult(pizza);
        }

        public IActionResult BackToHome()
        { 
            return RedirectToAction("Index", controllerName: "Home");
        }

        public IActionResult Details(int? id)
        {
            if(id != null)
            {
                return View();
            }
            return new EmptyResult();
        }
    };
}
