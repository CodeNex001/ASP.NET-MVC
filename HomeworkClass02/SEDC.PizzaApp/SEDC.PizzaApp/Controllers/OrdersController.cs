using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                return View();
            }
            return new EmptyResult();
        }

        public IActionResult JsonData()
        {
            Orders orders = new Orders
            {
                id = 1,
                Name = "Kapricioza"
            };

            return new JsonResult(orders);
        }

        public IActionResult RedirectionHome()
        {
            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}
